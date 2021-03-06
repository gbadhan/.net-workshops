﻿using System;
using System.Text.RegularExpressions;

namespace MarsRovers
{
    public class RoverManager
    {
        private const string roverInstructionsFormat = "^[LRM]*$";
        private const string roverPositionFormat = "[1-9] [1-9] [NEWS]";

        public static Rover GetRover(string roverPosition, string instructions)
        {
            if (Regex.IsMatch(roverPosition, roverPositionFormat) && Regex.IsMatch(instructions, roverInstructionsFormat))
            {
                string[] roverDetail = roverPosition.Split(' ');
                int x = 0;
                int y = 0;
                if (int.TryParse(roverDetail[0], out x) && int.TryParse(roverDetail[1], out y))
                {
                    Common.Direction dir = (Common.Direction)Enum.Parse(typeof(Common.Direction), roverDetail[2]);
                    Rover rover = new Rover(x, y, dir);
                    rover.Command = instructions;
                    return rover;
                }
            }

            return null;
        }

        public static void SetPlataeuGrid(Planet planet, string input)
        {
            string[] roverDetail = input.Split(' ');
            int x = 0;
            int y = 0;
            if (int.TryParse(roverDetail[0], out x) && int.TryParse(roverDetail[1], out y))
            {
                planet.SetPlataeu(x, y);
            }
        }

        public static void ExploreArea(Planet mars, Rover rover)
        {
            Console.WriteLine(string.Format("Initial rover location- X:{0}, Y:{1}, Direction:{2}", rover.XCoordinate, rover.YCoordinate, rover.RoverDirection.ToString()));
            foreach (char command in rover.Command)
            {
                Console.WriteLine("Processing : " + command);

                if (command == (char)Common.TurnDirection.L)
                {
                    rover.Turn(Common.TurnDirection.L);
                }
                else if (command == (char)Common.TurnDirection.R)
                {
                    rover.Turn(Common.TurnDirection.R);
                }
                else if (command == Common.MoveCommand)
                {
                    mars.MoveRover(rover);
                }
                else
                {
                    Console.WriteLine("Invalid Command: " + command);
                }

                Console.WriteLine(string.Format("{0}, {1}, {2}", rover.XCoordinate, rover.YCoordinate, rover.RoverDirection.ToString()));
            }

            Console.WriteLine(string.Format("Final rover location- X:{0}, Y:{1}, Direction:{2}", rover.XCoordinate, rover.YCoordinate, rover.RoverDirection.ToString()));
        }
    }
}
