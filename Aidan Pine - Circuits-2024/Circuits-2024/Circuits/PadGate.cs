using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// This class implements a Pad gate, which acts as a pass-through gate
    /// with one input and one output.
    /// </summary>
    class PadGate : Gate
    {
        // Brushes for drawing the gate
        private Brush selectedBrush = new SolidBrush(Color.Red);
        private Brush normalBrush = new SolidBrush(Color.LightGray);

        /// <summary>
        /// Initializes a new instance of the Pad Gate class.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public PadGate(int x, int y) : base(x, y)
        {
            // Add the input pin to the gate
            pins.Add(new Pin(this, true, 20));
            // Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));

            base.MoveTo(x, y);
            base.WIDTH = 70;
        }

        /// <summary>
        /// Draws the gate.
        /// </summary>
        /// <param name="paper">The Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            base.Draw(paper);

            // Determine which brush to use based on selection state
            Brush brush = selected ? selectedBrush : normalBrush;

            // Draw the gate as a simple rectangle
            paper.FillRectangle(brush, left, top, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Moves the gate and its pins to the specified position.
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
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
        /// Passes the input to the output of the Pad gate.
        /// </summary>
        /// <returns>The boolean value of the input gate's output</returns>
        public override bool Evaluate()
        {
            // Pass through the input value
            Gate inputGate = pins[0].InputWire.FromPin.Owner;
            return inputGate.Evaluate();
        }

        /// <summary>
        /// Creates a clone of this Pad Gate.
        /// </summary>
        /// <returns>A new PadGate instance with the same position</returns>
        public override Gate Clone()
        {
            return new PadGate(left, top);
        }
    }
}
