using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// The main GUI for the COMPX102 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int startX, startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        Pin startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int currentX, currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        List<Gate> gatesList = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        List<Wire> wiresList = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        Gate current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit
        /// </summary>
        Gate newGate = null;

        CompoundGate newCompound = null;

        List<Gate> removeGates = new List<Gate>();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Finds the pin that is close to (x,y), or returns
        /// null if there are no pins close to the position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The pin that has been selected</returns>
        Pin findPin(int x, int y)
        {
            foreach (Gate g in gatesList)
            {
                if (g is CompoundGate compoundGate)
                {
                    foreach (Gate innerGate in compoundGate.gates)
                    {
                        foreach (Pin p in innerGate.Pins)
                        {
                            if (p.isMouseOn(x, y) && (p.IsOutput || p.InputWire == null))
                            {
                                return p;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Pin p in g.Pins)
                    {
                        if (p.isMouseOn(x, y) && (p.IsOutput || p.InputWire == null))
                        {
                            return p;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Handles all events when the mouse is moving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                Console.WriteLine("wire from " + startPin + " to " + e.X + "," + e.Y);
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();  // this will draw the line
            }
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                Console.WriteLine("mouse move to " + e.X + "," + e.Y);
                current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));
                this.Invalidate();
            }
            else if (newGate != null)
            {
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Handles all events when the mouse button is released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);
                if (endPin != null)
                {
                    Console.WriteLine("Trying to connect " + startPin + " to " + endPin);
                    Pin input, output;
                    if (startPin.IsOutput)
                    {
                        input = endPin;
                        output = startPin;
                    }
                    else
                    {
                        input = startPin;
                        output = endPin;
                    }
                    if (input.IsInput && output.IsOutput)
                    {
                        if (input.InputWire == null)
                        {
                            Wire newWire = new Wire(output, input);
                            input.InputWire = newWire;
                            wiresList.Add(newWire);
                        }
                        else
                        {
                            MessageBox.Show("That input is already used.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");
                    }
                }
                startPin = null;
                this.Invalidate();
            }
            // We have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;
        }

        /// <summary>
        /// This will create a new And gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAnd_Click(object sender, EventArgs e)
        {
            newGate = new AndGate(0, 0);
        }

        /// <summary>
        /// Creates a new Not gate when the Not Gate button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonNot_Click(object sender, EventArgs e)
        {
            newGate = new NotGate(0, 0); // Create a new Not gate
        }

        /// <summary>
        /// Creates a new Or gate when the Or Gate button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonOr_Click(object sender, EventArgs e)
        {
            newGate = new OrGate(0, 0); // Create a new Or gate
        }

        /// <summary>
        /// Creates a new Pad gate when the Pad Gate button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonPad_Click(object sender, EventArgs e)
        {
            newGate = new PadGate(0, 0); // Create a new Pad gate
        }

        /// <summary>
        /// Creates a new Input Source when the Input Source button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonInput_Click(object sender, EventArgs e)
        {
            newGate = new InputSource(0, 0); // Create a new Input Source
        }

        /// <summary>
        /// Creates a new Output Lamp when the Output Lamp button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonLamp_Click(object sender, EventArgs e)
        {
            newGate = new OutputLamp(0, 0); // Create a new Output Lamp
        }

        /// <summary>
        /// Calculates the output of the circuit when the Evaluate button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonEvaluate_Click(object sender, EventArgs e)
        {
            foreach (Gate g in gatesList)
            {
                if (g is OutputLamp)
                {
                    try
                    {
                        g.Evaluate(); // Calculates the output of the circuit
                        this.Invalidate(); // Redraw the form to show updated states
                    }
                    catch (Exception ex)
                    { 
                        Console.WriteLine("Exception: " + ex.ToString());
                    } // catch any exceptions during calculation and print them to the console
                }
            }
        }

        /// <summary>
        /// Copies the selected gate when the Copy Gate button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            foreach (Gate g in gatesList)
            {
                if (g.Selected)
                {
                    newGate = g.Clone(); // Create a clone of the selected gate
                    this.Invalidate(); // Redraw the form to show the cloned gate
                }
            }
        }

        /// <summary>
        /// Starts creating a new compound gate when the Start Compound Gate button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonStartCompound_Click(object sender, EventArgs e)
        {
            newCompound = new CompoundGate(this.Width, this.Height); // Create a new compound gate
        }

        /// <summary>
        /// Finalizes the creation of a compound gate when the End Compound Gate button is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonEndCompound_Click(object sender, EventArgs e)
        {
            newGate = newCompound; // Set the new gate to the compound gate

            foreach (Gate g in removeGates)
            {
                gatesList.Remove(g); // Remove the gates that were added to the compound gate
            }
            removeGates.Clear(); // Clear the list of gates to be removed

            newCompound = null; // Reset the compound gate
        }

        /// <summary>
        /// Removes the currently selected gate and its connected wires from the circuit.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            // If no gate is currently selected, exit the method
            if (current == null) return;

            // Check if the current gate is a CompoundGate
            if (current is CompoundGate compoundGate)
            {
                // If it is, remove all gates within the compound gate
                foreach (Gate g in compoundGate.gates.ToList())
                {
                    RemoveGateAndWires(g);
                }
            }

            // Remove the current gate and its connected wires
            RemoveGateAndWires(current);

            // Clear the current selection
            current = null;

            // Redraw the form to reflect the changes
            this.Invalidate();
        }

        /// <summary>
        /// Removes a gate and all wires connected to it from the circuit.
        /// </summary>
        /// <param name="gate">The gate to be removed.</param>
        private void RemoveGateAndWires(Gate gate)
        {
            // Remove all wires connected to this gate
            wiresList.RemoveAll(wire => wire.FromPin.Owner == gate || wire.ToPin.Owner == gate);

            // Remove all wires from the gate's pins
            foreach (Pin p in gate.Pins)
            {
                p.InputWire = null;
            }

            // Remove the gate from the gates list
            gatesList.Remove(gate);
        }

        /// <summary>
        /// Redraws all the graphics for the current circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draw all of the gates
            foreach (Gate g in gatesList)
            {
                g.Draw(e.Graphics);
            }
            //Draw all of the wires
            foreach (Wire w in wiresList)
            {
                w.Draw(e.Graphics);
            }

            if (startPin != null)
            {
                e.Graphics.DrawLine(Pens.White,
                    startPin.X, startPin.Y,
                    currentX, currentY);
            }
            if (newGate != null)
            {
                // show the gate that we are dragging into the circuit
                newGate.MoveTo(currentX, currentY);
                newGate.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// Handles events while the mouse button is pressed down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
            }
            else if (current.IsMouseOn(e.X, e.Y))
            {
                // start dragging the current object around
                startX = e.X;
                startY = e.Y;
                currentX = current.Left;
                currentY = current.Top;
            }
        }

        /// <summary>
        /// Handles all events when a mouse is clicked in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Check if a gate is currently selected
            if (current != null)
            {
                //Unselect the selected gate
                current.Selected = false;
                current = null;
                this.Invalidate();
            }
            // See if we are inserting a new gate
            if (newGate != null)
            {
                newGate.MoveTo(e.X, e.Y);
                gatesList.Add(newGate);
                newGate = null;
                this.Invalidate();
            }
            else
            {
                // search for the first gate under the mouse position
                foreach (Gate g in gatesList)
                {
                    if (g.IsMouseOn(e.X, e.Y))
                    {
                        g.Selected = true;
                        current = g;
                        this.Invalidate();

                        if (newCompound != null)
                        {
                            newCompound.AddGate(g);
                            removeGates.Add(g);
                        }

                        break;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}




/* Question 1: Is it a better idea to fully document the Gate class or the AndGate
    subclass? Can you inherit comments?
 * Answer: Yes and no. From my understanding having a fully documented gate class can help make the code cleaner, 
 * as I do believe you can inherit most comments. However, it does make it a small bit more confusing to read the subclass code.
 * For me I personally prefer having the code documented in all sections. So this is why I have done this here.
 * 
 * Question 2: What is the advantage of making a method abstract in the superclass
    rather than just writing a virtual method with no code in the body of
    the method? Is there any disadvantage to an abstract method?
 * Answer: Cleanliness of the code. If you have a virtual method your always going to have to have these around the code { }.
 * Whereas if the method is abstract you can end it with a semi-colon (;) and allow people to read the code easier.
 * 
 * Question 3: If a class has an abstract method in it, does the class have to be abstract?
 * Answer: Yes.
 * 
 * Question 4: What would happen in your program if one of the gates added to your
    Compound Gate is another Compound Gate? Is your design robust
    enough to cope with this situation?
* Answer: Yes, the compound gate is just added as an additional gate,
* with the only issue being the input and output wires of the other compound gate being unselectable after being added.
* This could potentially be fixed by scanning if an inside gate is another compound gate and if so, picking up the unselected pins.
 */