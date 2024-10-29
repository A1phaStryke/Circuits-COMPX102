using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// Represents a Not gate in the circuit.
    /// </summary>
    class NotGate : Gate
    {
        /// <summary>
        /// Initialises the Not Gate.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public NotGate(int x, int y) : base(x, y)
        {
            // Add the input pin to the gate
            pins.Add(new Pin(this, true, 20));
            // Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));

            // Move the gate to the specified position
            base.MoveTo(x, y);
        }

        /// <summary>
        /// Draws the Not gate on the graphics surface.
        /// </summary>
        /// <param name="paper">The graphics surface to draw on</param>
        public override void Draw(Graphics paper)
        {
            base.Draw(paper);

            // Check if the gate has been selected
            if (selected)
            {
                // Draw the selected version of the Not gate
                paper.DrawImage(Properties.Resources.NotGateAllRed, Left, Top);
            }
            else
            {
                // Draw the normal version of the Not gate
                paper.DrawImage(Properties.Resources.NotGate, Left, Top);
            }
        }

        /// <summary>
        /// Moves the Not gate to the specified position.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // Move the input pin
            pins[0].X = x - GAP;
            pins[0].Y = y + HEIGHT / 2;
            // Move the output pin
            pins[1].X = x + WIDTH + GAP;
            pins[1].Y = y + HEIGHT / 2;
        }

        /// <summary>
        /// Evaluates the output of the Not gate.
        /// </summary>
        /// <returns>The oppposite of the input</returns>
        public override bool Evaluate()
        {
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            return !gateA.Evaluate();
        }

        /// <summary>
        /// Creates a clone of the Not gate.
        /// </summary>
        /// <returns>A new instance of Not Gate with the same position</returns>
        public override Gate Clone()
        {
            Gate newGate = new NotGate(left, top);
            return newGate;
        }
    }
}