using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    class Plateau
    {
        private Rover[,] matrix;
        private int MaxXCoordinate { get; set; }
        private int MaxYCoordinate { get; set; }
        private List<Rover> rovers { get; set; } 

        public Plateau(int RightXCoordinate, int RightYCoordinate)
        {
            MaxXCoordinate = RightXCoordinate;
            MaxYCoordinate = RightYCoordinate;
            matrix = new Rover[RightXCoordinate, RightYCoordinate];
            //for (int x = 0; x < RightXCoordinate; x++)
            //{
            //    for (int y = 0; y < RightYCoordinate; y++)
            //    {
            //        matrix[x, y] = 
            //    }
            //}
        }

        public bool AddRover(Rover rover)
        {
            if (!AreCoordinatesValid(rover.XCoordinate, rover.YCoordinate))
            {                 
                 return false;
            }

            this.matrix[rover.XCoordinate, rover.YCoordinate] = rover;
            return true;
        }

        public bool MoveRover(Rover rover)
        {
            int oldXCoordinate = rover.XCoordinate;
            int oldYCoordinate = rover.YCoordinate;

            int newXCoordinate = oldXCoordinate;
            int newYCoordinate = oldYCoordinate;
            
            switch (rover.RoverDirection)
            {
                case Common.Direction.E:
                    ++newXCoordinate;
                    break;
                case Common.Direction.N:
                    ++newYCoordinate;
                    break;
                case Common.Direction.W:
                    --newXCoordinate;
                    break;
                case Common.Direction.S:
                    --newYCoordinate;
                    break;
            }

            if (!AreCoordinatesValid(newXCoordinate, newYCoordinate))
            {
                Console.WriteLine("Cannot Move. New coordinates are not valid");
                return false;
            }
                                    
            rover.XCoordinate = newXCoordinate;
            rover.YCoordinate = newYCoordinate;
            this.matrix[oldXCoordinate, oldYCoordinate] = null;
            this.matrix[newXCoordinate, newYCoordinate] = rover;
            return true;
        }

        public void TurnRover(Rover rover, MarsRovers.Common.MoveDirection direction)
        {
            int newDirection = 0;
            if (direction == Common.MoveDirection.L)
            {
                newDirection = (int)rover.RoverDirection + 1;
            }
            else
            {
                newDirection = (int)rover.RoverDirection - 1;
            }

            if (newDirection < 0)
            {
                rover.RoverDirection = Common.Direction.W;
            }
            else if (newDirection > 3)
            {
                rover.RoverDirection = Common.Direction.E;
            }
            else
            {
                rover.RoverDirection = (Common.Direction)newDirection;
            }
        }

        private bool AreCoordinatesValid(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || yCoordinate < 0)
            {
                Console.WriteLine("Invalid coordinates: None of the coordinates can be negative.");
                return false;
            }

            if (xCoordinate > MaxXCoordinate || yCoordinate > MaxYCoordinate)
            {
                Console.WriteLine("Invalid Coordinates: Out of boundary");
                return false;
            }

            if (this.matrix[xCoordinate, yCoordinate] != null)
            {
                Console.WriteLine("There is already a rover at these coordinates");
                return false;
            }

            return true;
        }
    }
}
