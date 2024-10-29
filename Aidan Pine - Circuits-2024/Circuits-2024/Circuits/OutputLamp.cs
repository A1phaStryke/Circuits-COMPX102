using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// Represents an output lamp in a circuit, which visually displays the state of its input.
    /// </summary>
    class OutputLamp : Gate
    {
        // Brushes for different states of the lamp
        private readonly Brush selectedBrush = new SolidBrush(Color.Red);
        private readonly Brush normalBrush = new SolidBrush(Color.Black);
        private readonly Brush onBrush = new SolidBrush(Color.Yellow);

        // Indicates whether the lamp is receiving high voltage
        private bool isHighVoltage = false;

        /// <summary>
        /// Initializes a new instance of the Output Lamp class.
        /// </summary>
        /// <param name="x">The x-coordinate of the lamp's position.</param>
        /// <param name="y">The y-coordinate of the lamp's position.</param>
        public OutputLamp(int x, int y) : base(x, y)
        {
            // Add the input pin to the lamp
            pins.Add(new Pin(this, true, 20));

            base.MoveTo(x, y);
            base.WIDTH = 70;
        }

        /// <summary>
        /// Draws the output lamp.
        /// </summary>
        /// <param name="paper">The graphics surface to draw on.</param>
        public override void Draw(Graphics paper)
        {
            base.Draw(paper);

            // Determine which brush to use based on the lamp's state
            Brush brush = selected ? selectedBrush : (isHighVoltage ? onBrush : normalBrush);

            // Draw the lamp shape
            Pen pen = new Pen(Color.LightGray, 10);
            paper.DrawEllipse(pen, left, top, WIDTH, HEIGHT);
            paper.FillEllipse(brush, left, top, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Moves the output lamp to the specified position.
        /// </summary>
        /// <param name="x">The new x-coordinate.</param>
        /// <param name="y">The new y-coordinate.</param>
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // Update the position of the input pin
            pins[0].X = x - (GAP * 2);
            pins[0].Y = y + HEIGHT / 2;
        }

        /// <summary>
        /// Calculates the state of the output lamp based on its input.
        /// </summary>
        /// <returns>The boolean state of the lamp (true if high voltage, false otherwise).</returns>
        public override bool Evaluate()
        {
            Gate inputGate = pins[0].InputWire.FromPin.Owner;
            isHighVoltage = inputGate.Evaluate();
            return isHighVoltage;
        }

        /// <summary>
        /// Creates a clone of the output lamp.
        /// </summary>
        /// <returns>A new instance of Output Lamp with the same position as the original.</returns>
        public override Gate Clone()
        {
            return new OutputLamp(left, top);
        }
    }
}
