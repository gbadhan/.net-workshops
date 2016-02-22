using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please pass the secret command.");
                return;
            }
            
            Planet mars = new Planet("Mars");
            List<Rover> rovers =  ExtractRoverDataFromInput(args[0], mars);

            if (rovers == null)
            {
                Console.WriteLine("Could not create any rover with provided instructions");
                Console.ReadLine();
                return;
            }

            foreach (Rover rover in rovers)
            {
                Console.WriteLine("----Processing Rover------");
                if (!mars.AddRover(rover))
                {
                    Console.WriteLine("Could not add rover to plateau.");
                }
                else
                {
                    RoverManager.ExploreArea(mars, rover);
                }
            }

            Console.ReadLine();
        }

        private static List<Rover> ExtractRoverDataFromInput(string inputFile, Planet mars)
        {
            try
            {
                List<Rover> roverDataCollection = new List<Rover>();

                string[] lines = File.ReadAllLines(inputFile);
                RoverManager.SetPlataeuGrid(mars, lines[0]);

                for (int counter = 1; counter < lines.Length - 1; counter = counter + 2)
                {
                    Rover rover = RoverManager.GetRover(lines[counter], lines[counter + 1]);
                    if (rover != null)
                    {
                        roverDataCollection.Add(rover);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("A rover could not be created. Invalid Raw material: {0} {1}", lines[counter], lines[counter + 1]));
                    }
                }

                return roverDataCollection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while processing the input. Please make sure the input file is in correct format." + ex.Message);
                return null;
            }
        }              
    }
}
