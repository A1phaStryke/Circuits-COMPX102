using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// This class implements an And gate with two inputs and one output.
    /// </summary>
    class AndGate : Gate
    {
        /// <summary>
        /// Initializes the And gate.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y) : base(x, y)
        {
            // Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            // Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));

            // Move the gate to the specified position
            base.MoveTo(x, y);
        }

        /// <summary>
        /// Draws the And gate on the specified Graphics object.
        /// </summary>
        /// <param name="paper">The Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            base.Draw(paper);

            // Check if the gate has been selected
            if (selected)
            {
                paper.DrawImage(Properties.Resources.AndGateAllRed, Left, Top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.AndGate, Left, Top);
            }
        }

        /// <summary>
        /// Moves the gate and its pins to the specified position.
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // Move the pins relative to the gate's new position
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT - GAP;
            pins[2].X = x + WIDTH + GAP;
            pins[2].Y = y + HEIGHT / 2;
        }

        /// <summary>
        /// Calculatesthe output of the And gate based on its inputs.
        /// </summary>
        /// <returns>A boolean result based on if both inputs are true or not (If both are true return true, else return false)</returns>
        public override bool Evaluate()
        {
            // Get the gates connected to the input pins
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            Gate gateB = pins[1].InputWire.FromPin.Owner;
            // Return the result of AND operation on the inputs
            return gateA.Evaluate() && gateB.Evaluate();
        }

        /// <summary>
        /// Creates a clone of the And gate.
        /// </summary>
        /// <returns>A new instance of And Gate with the same position</returns>
        public override Gate Clone()
        {
            return new AndGate(left, top);
        }
    }
}