using MarsRovers.Enums;
using MarsRovers.Helper;
using MarsRovers.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers
{
    class Program
    {
        /// <summary> 
        /// static start position  for this project
        /// </summary>
        private static string startPosition = "1 2 N";
        /// <summary>
        /// static moving position for this project
        /// </summary>
        private static string movingPosition = "LMLMLMLMM";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the coordinates example :5 5");
            string line = Console.ReadLine().Replace(" ",string.Empty);

            Coordinate upperRightCoordinate = MarsRoverCommandHelper.PopulateCoordinate(line);

            if (upperRightCoordinate == default(Coordinate))
            {
                Console.WriteLine("The input is not valid.");
                return;
            }

            RoverPosition roverPosition = new RoverPosition(RoverDirectionEnum.N);
            while (true)
            {
                Console.Write($"Please Enter start position. example :{startPosition} {Environment.NewLine}");
                line = Console.ReadLine().Replace(" ", string.Empty).ToUpper();
                roverPosition = MarsRoverCommandHelper.PopulateRoverPosition(line);

                if (roverPosition is default(RoverPosition))
                {
                    Console.WriteLine("The input is not valid.");
                    return;
                }

                Console.Write($"Please enter rover's moving. example :{movingPosition}  {Environment.NewLine}");
                line = Console.ReadLine().Replace(" ", string.Empty).ToUpper();
                IEnumerable<MovingDirectionEnum> movingDirectionList = MarsRoverCommandHelper.PopulateMovingDirectionList(line);

                if (movingDirectionList.Any() == false)
                {
                    Console.WriteLine("The input is not valid.");
                    return;
                }

                foreach (MovingDirectionEnum direction in movingDirectionList)
                  roverPosition = MarsRoverCommandHelper.CalculateNextPosition(roverPosition, direction);

                Console.WriteLine($"Current Position is: {roverPosition.Coordinate.X} { roverPosition.Coordinate.Y} {roverPosition.Direction}");

                Console.Write(Environment.NewLine + "0: Exit \n1: continue\nSelect :");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.NumPad1)
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Current Position is: {roverPosition.Coordinate.X} { roverPosition.Coordinate.Y} {roverPosition.Direction}");
                    ////sample data for the second process 
                    startPosition = "3 3 E";
                    movingPosition = "MMRMMRMRRM";
                }
            }
        }
    }
}
