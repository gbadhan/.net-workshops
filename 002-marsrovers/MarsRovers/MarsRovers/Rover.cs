
namespace MarsRovers
{
    public class Rover
    {        
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public Common.Direction RoverDirection { get; set; }

        public string Command { get; set; }

        public Rover()
        { }

        public Rover(int xCoordinate, int yCoordinate, Common.Direction direction)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.RoverDirection = direction;
        }
        public void Turn(Common.TurnDirection direction)
        {
            int newDirection = 0;
            if (direction == Common.TurnDirection.L)
            {
                newDirection = (int)this.RoverDirection + 1;
            }
            else
            {
                newDirection = (int)this.RoverDirection - 1;
            }

            if (newDirection < 0)
            {
                this.RoverDirection = Common.Direction.S;
            }
            else if (newDirection > 3)
            {
                this.RoverDirection = Common.Direction.E;
            }
            else
            {
                this.RoverDirection = (Common.Direction)newDirection;
            }
        }
    }
}
