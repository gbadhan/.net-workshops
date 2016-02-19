using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(1, 2, Common.Direction.N);
            if (plateau.AddRover(rover)) 
            {
                Console.WriteLine(string.Format("Initial rover location- X:{0}, Y:{1}, Direction:{2}", rover.XCoordinate, rover.YCoordinate, rover.RoverDirection.ToString()));
                // LMLMLMLMM
                plateau.TurnRover(rover, Common.MoveDirection.L);
                plateau.MoveRover(rover);
                plateau.TurnRover(rover, Common.MoveDirection.L);
                plateau.MoveRover(rover);
                plateau.TurnRover(rover, Common.MoveDirection.L);
                plateau.MoveRover(rover);
                plateau.TurnRover(rover, Common.MoveDirection.L);
                plateau.MoveRover(rover);
                plateau.MoveRover(rover);

                Console.WriteLine(string.Format("Final rover location- X:{0}, Y:{1}, Direction:{2}", rover.XCoordinate, rover.YCoordinate, rover.RoverDirection.ToString()));
            }
            else
            {
                Console.WriteLine("Could not add rover to plateau. Spacecraft turned upside down.");
            }

            Console.ReadLine();
        }        
    }
}
