using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// This class implements an Or gate with two inputs and one output.
    /// </summary>
    class OrGate : Gate
    {
        /// <summary>
        /// Initializes the Or Gate.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public OrGate(int x, int y) : base(x, y)
        {
            // Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            // Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));

            base.MoveTo(x, y);
            base.WIDTH = 70;
        }

        /// <summary>
        /// Draws the Or gate.
        /// </summary>
        /// <param name="paper">The Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            base.Draw(paper);

            // Check if the gate has been selected and draw the gate red if it has, else draw the gate normally
            if (selected)
            {
                paper.DrawImage(Properties.Resources.OrGateAllRed, Left, Top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.OrGate, Left, Top);
            }
        }

        /// <summary>
        /// Moves the OR gate to the specified position.
        /// </summary>
        /// <param name="x">The new x position of the gate</param>
        /// <param name="y">The new y position of the gate</param>
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // Move the pins to their new positions
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT - GAP;
            pins[2].X = x + WIDTH + GAP;
            pins[2].Y = y + HEIGHT / 2;
        }

        /// <summary>
        /// Calculates the output of the Or gate based on its inputs.
        /// </summary>
        /// <returns>A boolean result of the calculation</returns>
        public override bool Evaluate()
        {
            Gate gateA = pins[0].InputWire.FromPin.Owner;
            Gate gateB = pins[1].InputWire.FromPin.Owner;
            return gateA.Evaluate() || gateB.Evaluate();
        }

        /// <summary>
        /// Creates a clone of the Or gate.
        /// </summary>
        /// <returns>A new instance of Or Gate with the same position</returns>
        public override Gate Clone()
        {
            Gate newGate = new OrGate(left, top);
            return newGate;
        }
    }
}