using System;
using System.Collections.Generic;

namespace MarsRovers
{
    public class Planet
    {
        private string planetName { get; set; }

        private Rover[,] plataeu;

        private int MaxXCoordinate { get; set; }
        private int MaxYCoordinate { get; set; }
        private List<Rover> rovers { get; set; }

        public Planet(string name)
        {
            this.planetName = name;
        }

        public void SetPlataeu(int RightXCoordinate, int RightYCoordinate)
        {
            MaxXCoordinate = RightXCoordinate;
            MaxYCoordinate = RightYCoordinate;
            this.plataeu = new Rover[RightXCoordinate + 1, RightYCoordinate + 1];            
        }

        public bool AddRover(Rover rover)
        {
            if (!AreCoordinatesValid(rover.XCoordinate, rover.YCoordinate))
            {                 
                 return false;
            }

            this.plataeu[rover.XCoordinate, rover.YCoordinate] = rover;
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
                Console.WriteLine("Cannot Move. New coordinates are not valid. Skipping this movement.");
                return false;
            }
                                    
            rover.XCoordinate = newXCoordinate;
            rover.YCoordinate = newYCoordinate;
            this.plataeu[oldXCoordinate, oldYCoordinate] = null;
            this.plataeu[newXCoordinate, newYCoordinate] = rover;
            return true;
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

            if (this.plataeu[xCoordinate, yCoordinate] != null)
            {
                Console.WriteLine("There is already a rover at these coordinates");
                return false;
            }

            return true;
        }
    }
}
