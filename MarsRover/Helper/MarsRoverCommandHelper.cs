using MarsRovers.Enums;
using MarsRovers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRovers.Helper
{
    /// <summary>
    /// The mars rover command helper
    /// </summary>
    public static class MarsRoverCommandHelper
    {
        /// <summary>
        /// Populate the coordinate from the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The coordinate generated from input. Returns the default value if the input is not valid.</returns>
        public static Coordinate PopulateCoordinate(string input)
        {
            if (input.Length > 2) return default;
            Coordinate coordinate = new Coordinate();

            try
            {
                coordinate.X = int.Parse(input[0].ToString());
                coordinate.Y = int.Parse(input[1].ToString());
            }
            catch (FormatException)
            {
                return default;
            }

            return coordinate;
        }

        /// <summary>
        /// Populate the rover position from the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The rover position generated from input. Returns the default value if the input is not valid.</returns>
        public static RoverPosition PopulateRoverPosition(string input)
        {
            if (input.Length > 3) return default;
            RoverPosition roverPosition = new RoverPosition();

            try
            {
                roverPosition.Coordinate.X = int.Parse(input[0].ToString());
                roverPosition.Coordinate.Y = int.Parse(input[1].ToString());
                roverPosition.Direction = PopulateRoverDirection(input[2]);

                if (roverPosition.Direction == RoverDirectionEnum.NotFound) return default;
            }
            catch (FormatException)
            {
                return default;
            }

            return roverPosition;
        }

        /// <summary>
        /// Populate the moving direction list from the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The moving direction list generated from input. Returns an empty list if the input is not valid.</returns>
        public static IEnumerable<MovingDirectionEnum> PopulateMovingDirectionList(string input)
        {
            var movingDirectionList = new List<MovingDirectionEnum>();
            for (int i = 0; i < input.Length; i++)
            {
                movingDirectionList.Add(PopulateMovingDirection(input[i]));
            }

            return movingDirectionList.Any(x => x == MovingDirectionEnum.NotFound) ? new List<MovingDirectionEnum>() : movingDirectionList;
        }

        /// <summary>
        /// Populate rover direction from the input char
        /// </summary>
        /// <param name="input">The input char</param>
        /// <returns>The rover direction generated from input. Returns the undefined value if the input is not valid.</returns>
        static RoverDirectionEnum PopulateRoverDirection(char input)
        {
            switch (input.ToString().ToUpper())
            {
                case "N":
                    return RoverDirectionEnum.N;
                case "S":
                    return RoverDirectionEnum.S;
                case "E":
                    return RoverDirectionEnum.E;
                case "W":
                    return RoverDirectionEnum.W;
                default:
                    return RoverDirectionEnum.NotFound;
            }
        }

        /// <summary>
        /// Populate moving direction from the input char
        /// </summary>
        /// <param name="input">The input char</param>
        /// <returns>The moving direction generated from input. Returns the undefined value if the input is not valid.</returns>
        static MovingDirectionEnum PopulateMovingDirection(char data)
        {
            switch (data.ToString().ToUpper())
            {
                case "M":
                    return MovingDirectionEnum.F;
                case "L":
                    return MovingDirectionEnum.L;
                case "R":
                    return MovingDirectionEnum.R;
                default:
                    return MovingDirectionEnum.NotFound;
            }
        }
        /// <summary>
        /// Calculates rover's next position with the moving direction
        /// </summary>
        /// <param name="currentPosition">Rover's current position</param>
        /// <param name="direction">Direction that rover want to go</param>
        /// <returns>The rover's new position</returns>
        public static RoverPosition CalculateNextPosition(RoverPosition currentPosition, MovingDirectionEnum direction)
        {
            switch (direction)
            {
                case MovingDirectionEnum.F:
                    switch (currentPosition.Direction)
                    {
                        case RoverDirectionEnum.N:
                            currentPosition.Coordinate.Y = currentPosition.Coordinate.Y + 1;
                            break;
                        case RoverDirectionEnum.S:
                            currentPosition.Coordinate.Y = currentPosition.Coordinate.Y - 1;
                            break;
                        case RoverDirectionEnum.E:
                            currentPosition.Coordinate.X = currentPosition.Coordinate.X + 1;
                            break;
                        case RoverDirectionEnum.W:
                            currentPosition.Coordinate.X = currentPosition.Coordinate.X - 1;
                            break;
                    }
                    break;
                case MovingDirectionEnum.L:
                    switch (currentPosition.Direction)
                    {
                        case RoverDirectionEnum.N:
                            currentPosition.Direction = RoverDirectionEnum.W;
                            break;
                        case RoverDirectionEnum.S:
                            currentPosition.Direction = RoverDirectionEnum.E;
                            break;
                        case RoverDirectionEnum.E:
                            currentPosition.Direction = RoverDirectionEnum.N;
                            break;
                        case RoverDirectionEnum.W:
                            currentPosition.Direction = RoverDirectionEnum.S;
                            break;
                    }
                    break;
                case MovingDirectionEnum.R:
                    switch (currentPosition.Direction)
                    {
                        case RoverDirectionEnum.N:
                            currentPosition.Direction = RoverDirectionEnum.E;
                            break;
                        case RoverDirectionEnum.S:
                            currentPosition.Direction = RoverDirectionEnum.W;
                            break;
                        case RoverDirectionEnum.E:
                            currentPosition.Direction = RoverDirectionEnum.S;
                            break;
                        case RoverDirectionEnum.W:
                            currentPosition.Direction = RoverDirectionEnum.N;
                            break;
                    }
                    break;
            }
            return currentPosition;
        }
    }
}

