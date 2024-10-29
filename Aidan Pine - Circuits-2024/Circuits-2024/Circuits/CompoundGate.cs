using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// Represents a compound gate that can contain multiple gates.
    /// </summary>
    class CompoundGate : Gate
    {
        // Brushes for drawing the gate
        private Brush selectedBrush = new SolidBrush(Color.Red);
        private Brush normalBrush = new SolidBrush(Color.LightGray);

        /// <summary>
        /// List of gates contained within this compound gate.
        /// </summary>
        public List<Gate> gates = new List<Gate>();

        /// <summary>
        /// Initializes a new instance of the CompoundGate class.
        /// </summary>
        /// <param name="x">The x-coordinate of the gate's position.</param>
        /// <param name="y">The y-coordinate of the gate's position.</param>
        public CompoundGate(int x, int y) : base(x, y)
        {
            MoveTo(x, y);
        }

        /// <summary>
        /// Draws the compound gate and its contained gates.
        /// </summary>
        /// <param name="paper">The Graphics object to draw on.</param>
        public override void Draw(Graphics paper)
        {

            // Set the selected state for all contained gates
            foreach (Gate gate in gates)
            {
                gate.Selected = selected;
            }

            // Draw all contained gates
            foreach (Gate gate in gates)
            {
                gate.Draw(paper);
            }

            // Draw wires for all pins of contained gates
            foreach (Gate gate in gates)
            {
                foreach (Pin pin in gate.pins)
                {
                    pin.InputWire?.Draw(paper);
                }
            }

            Pen pen = new Pen(Color.Black, 2);
            paper.DrawRectangle(pen, left, top, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Moves the compound gate and all its contained gates to a new position.
        /// </summary>
        /// <param name="x">The new x-coordinate.</param>
        /// <param name="y">The new y-coordinate.</param>
        public override void MoveTo(int x, int y)
        {
            // Calculate the distance to move
            int xDistance = x - left;
            int yDistance = y - top;

            // Move the base gate
            base.MoveTo(x, y);

            // Move all contained gates
            foreach (Gate gate in gates)
            {
                gate.MoveTo(gate.left + xDistance, gate.top + yDistance);
            }
        }

        /// <summary>
        /// Calculates the compound gate.
        /// </summary>
        /// <returns>The result of the Calculation.</returns>
        public override bool Evaluate()
        {
            // Evaluate all gates in the compound gate
            foreach (Gate gate in gates)
            {
                gate.Evaluate();
            }

            // Return the result of the last gate in the list
            // Assuming the last gate represents the final output of the compound gate
            if (gates.Count > 0)
            {
                return gates[gates.Count - 1].Evaluate();
            }

            // If there are no gates, return false
            return false;
        }

        /// <summary>
        /// Creates a deep clone of the compound gate.
        /// </summary>
        /// <returns>A new instance of Compound Gate with cloned gates and wires.</returns>
        public override Gate Clone()
        {
            CompoundGate newGate = new CompoundGate(left, top);
            Dictionary<Pin, Pin> pinMapping = new Dictionary<Pin, Pin>();

            // Clone gates and create pin mapping
            for (int i = 0; i < gates.Count; i++)
            {
                Gate clonedGate = gates[i].Clone();
                newGate.AddGate(clonedGate);

                for (int p = 0; p < gates[i].pins.Count; p++)
                {
                    pinMapping[gates[i].pins[p]] = clonedGate.pins[p];
                }
            }

            // Clone wires using the pin mapping
            foreach (Gate originalGate in gates)
            {
                foreach (Pin originalPin in originalGate.pins)
                {
                    if (originalPin.InputWire != null)
                    {
                        Pin newFromPin = pinMapping[originalPin.InputWire.FromPin];
                        Pin newToPin = pinMapping[originalPin.InputWire.ToPin];
                        Wire newWire = new Wire(newFromPin, newToPin);
                        pinMapping[originalPin].InputWire = newWire;
                    }
                }
            }

            return newGate;
        }

        /// <summary>
        /// Adds a gate to the compound gate.
        /// </summary>
        /// <param name="gate">The gate to be added.</param>
        public void AddGate(Gate gate)
        {
            // Don't add InputSource gates
            if (gate is InputSource)
                return;

            gates.Add(gate);

            // Recalculate compound gate dimensions
            RecalculateDimensions();
        }

        /// <summary>
        /// Recalculates the dimensions of the compound gate based on its contained gates.
        /// </summary>
        private void RecalculateDimensions()
        {
            // If there are no gates, exit the method
            if (gates.Count == 0) return;

            // Find the leftmost x-coordinate of all gates
            int minX = gates.Min(g => g.Left);
            // Find the rightmost x-coordinate of all gates (including their width)
            int maxX = gates.Max(g => g.Left + g.WIDTH);
            // Find the topmost y-coordinate of all gates
            int minY = gates.Min(g => g.Top);
            // Find the bottommost y-coordinate of all gates (including their height)
            int maxY = gates.Max(g => g.Top + g.HEIGHT);

            // Set the compound gate's left coordinate to the leftmost gate
            left = minX;
            // Set the compound gate's top coordinate to the topmost gate
            top = minY;
            // Calculate the compound gate's width
            WIDTH = maxX - minX;
            // Calculate the compound gate's height
            HEIGHT = maxY - minY;
        }
    }
}