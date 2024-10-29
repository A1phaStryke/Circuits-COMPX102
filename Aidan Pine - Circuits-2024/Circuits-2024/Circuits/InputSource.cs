using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// Represents an input source in a circuit, which can be toggled between high and low voltage / On or off.
    /// </summary>
    class InputSource : Gate
    {
        // Brushes for different states of the input source
        private Brush selectedBrush = new SolidBrush(Color.Red);
        private Brush normalBrush = new SolidBrush(Color.Black);
        private Brush onBrush = new SolidBrush(Color.Blue);

        // Indicates whether the input source is currently outputting high voltage / is activated
        private bool isHighVoltage = false;

        /// <summary>
        /// Initializes a new instance of the Input Source class.
        /// </summary>
        /// <param name="x">The x-coordinate of the input source's position.</param>
        /// <param name="y">The y-coordinate of the input source's position.</param>
        public InputSource(int x, int y) : base(x, y)
        {
            // Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));

            base.MoveTo(x, y);
            base.WIDTH = 70;
        }

        /// <summary>
        /// Draws the input source.
        /// </summary>
        /// <param name="paper">The Graphics object to draw on.</param>
        public override void Draw(Graphics paper)
        {
            base.Draw(paper);

            // Determine the brush color based on the input source's state
            Brush brush;
            if (selected)
            {
                brush = selectedBrush;
                // Toggle the voltage state when selected
                isHighVoltage = !isHighVoltage;
            }
            else if (isHighVoltage)
            {
                brush = onBrush;
            }
            else
            {
                brush = normalBrush;
            }

            // Draw the input source
            Pen pen = new Pen(Color.LightGray, 10);
            paper.DrawRectangle(pen, Left, top, WIDTH, HEIGHT);
            paper.FillRectangle(brush, left, top, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Moves the input source to the specified position.
        /// </summary>
        /// <param name="x">The new x-coordinate.</param>
        /// <param name="y">The new y-coordinate.</param>
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // Move the output pin
            pins[0].X = x + WIDTH + (GAP * 2);
            pins[0].Y = y + HEIGHT / 2;
        }

        /// <summary>
        /// Calculates the current state of the input source.
        /// </summary>
        /// <returns>True if the input source is outputting high voltage, false otherwise.</returns>
        public override bool Evaluate()
        {
            return isHighVoltage;
        }

        /// <summary>
        /// Creates a clone of this input source.
        /// </summary>
        /// <returns>A new Input Source object with the same position as the original.</returns>
        public override Gate Clone()
        {
            return new InputSource(left, top);
        }
    }
}