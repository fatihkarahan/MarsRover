using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Models
{
    /// <summary>
    /// The coordinate
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Set the X and Y axises of coordinate
        /// </summary>
        /// <param name="x">Sets X coordinate</param>
        /// <param name="y">Sets Y coordinate</param>
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Initializes a new instance for the Coordinate. Default coordinates are 0 0
        /// </summary>
        public Coordinate()
        {
            this.X = 0;
            this.Y = 0;
        }
    }
}
