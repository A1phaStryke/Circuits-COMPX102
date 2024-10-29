using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// This class implements a generic gate with inputs and outputs.
    /// It serves as a base class for specific gate types.
    /// </summary>
    abstract class Gate
    {
        // Position properties
        /// <summary>
        /// The left-hand edge of the main part of the gate.
        /// Input pins are further left than this value.
        /// </summary>
        public int left;

        /// <summary>
        /// The top edge of the whole gate.
        /// </summary>
        public int top;

        // Dimensions
        /// <summary>
        /// Width of the main part of the gate.
        /// </summary>
        public int WIDTH = 50;

        /// <summary>
        /// Height of the main part of the gate.
        /// </summary>
        public int HEIGHT = 50;

        /// <summary>
        /// Length of the connector legs sticking out left and right.
        /// </summary>
        protected const int GAP = 10;

        /// <summary>
        /// List of all pins (inputs and outputs) for this gate.
        /// </summary>
        public List<Pin> pins = new List<Pin>();

        /// <summary>
        /// Indicates whether the gate is currently selected.
        /// </summary>
        protected bool selected = false;

        /// <summary>
        /// Initializes a new instance of the Gate class.
        /// </summary>
        /// <param name="x">The x-coordinate of the gate's position.</param>
        /// <param name="y">The y-coordinate of the gate's position.</param>
        public Gate(int x, int y)
        {

        }

        /// <summary>
        /// Gets or sets whether the gate is selected.
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// Gets the left-hand edge of the gate.
        /// </summary>
        public int Left
        {
            get { return left; }
        }

        /// <summary>
        /// Gets the top edge of the gate.
        /// </summary>
        public int Top
        {
            get { return top; }
        }

        /// <summary>
        /// Gets the list of pins for the gate.
        /// </summary>
        public List<Pin> Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// Checks if the given coordinates are within the gate's bounds.
        /// </summary>
        /// <param name="x">The x-coordinate to check.</param>
        /// <param name="y">The y-coordinate to check.</param>
        /// <returns>True if the coordinates are inside the gate; otherwise, false.</returns>
        public bool IsMouseOn(int x, int y)
        {
            return (left <= x && x < left + WIDTH && top <= y && y < top + HEIGHT);
        }

        /// <summary>
        /// Draws the gate and its pins on the specified graphics surface.
        /// </summary>
        /// <param name="paper">The graphics surface to draw on.</param>
        public virtual void Draw(Graphics paper)
        {
            // Draw all pins
            foreach (Pin p in pins)
                p.Draw(paper);

            // The gate itself is drawn in its own subclass
        }

        /// <summary>
        /// Moves the gate to the specified position.
        /// </summary>
        /// <param name="x">The new x-coordinate for the gate.</param>
        /// <param name="y">The new y-coordinate for the gate.</param>
        public virtual void MoveTo(int x, int y)
        {
            left = x;
            top = y;
            // Note: Pin positions should be updated in derived classes
        }

        /// <summary>
        /// Calculates the output of the gate based on its inputs.
        /// </summary>
        /// <returns>The boolean result of the gate's operation.</returns>
        abstract public bool Evaluate();

        /// <summary>
        /// Creates a deep copy of the gate.
        /// </summary>
        /// <returns>A new instance of the gate with the same properties.</returns>
        abstract public Gate Clone();
    }
}