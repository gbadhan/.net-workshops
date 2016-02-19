using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsRovers
{
    public class Rover
    {        
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public Common.Direction RoverDirection { get; set; }

        public Rover()
        { }

        public Rover(int xCoordinate, int yCoordinate, Common.Direction direction)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.RoverDirection = direction;
        }
    }
}
