using MarsRovers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Models
{
    /// <summary>
    /// The rover position
    /// </summary>
    public class RoverPosition
    {
        /// <summary>
        /// Rover's X,Y coordinate
        /// </summary>
        public Coordinate Coordinate { get; set; }

        /// <summary>
        /// Rover's facing direction
        /// </summary>
        public RoverDirectionEnum Direction { get; set; }

        /// <summary>
        /// As default, RoverPosition's coordinate is (0,0) and direction is North
        /// </summary>
        public RoverPosition()
        {
            this.Coordinate = new Coordinate(0, 0);
            this.Direction = RoverDirectionEnum.N;
        }

        /// <summary>
        /// Initializes a new instance for the RoverPosition
        /// </summary>
        /// <param name="coordinate">Sets the Rover's position</param>
        /// <param name="direction">Sets the Rover's direction</param>
        public RoverPosition(RoverDirectionEnum direction)
        {
            this.Coordinate = new Coordinate();
            this.Direction = direction;
        }
    }
}