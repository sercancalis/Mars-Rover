using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            RoverPosition roverPosition = new RoverPosition();
            RoverDirection directions = new RoverDirection();
            Plateau plateau = new Plateau();
            string Coordinate;
            Console.WriteLine("Enter the Plateau X Y coordinate");
            Coordinate = Console.ReadLine();
            plateau.xCoordinate = int.Parse(Coordinate.Split(' ')[0]);
            plateau.yCoordinate = int.Parse(Coordinate.Split(' ')[1]);
            try
            {
                Console.WriteLine("Enter the X Y Direction coordinate");
                Coordinate = Console.ReadLine();
                roverPosition.xCoordinate = int.Parse(Coordinate.Split(' ')[0]);
                roverPosition.yCoordinate = int.Parse(Coordinate.Split(' ')[1]);
                directions.Direction = (Directions)Enum.Parse(typeof(Directions), Coordinate.Split(' ')[2]);

                Console.WriteLine("Enter the Command LRM(Left-Right-Move)");
                string commands = Console.ReadLine();

                Process(commands, directions, roverPosition);
                Console.WriteLine($"{roverPosition.xCoordinate} {roverPosition.yCoordinate} {directions.Direction}");
                Console.ReadKey();
            }
            catch (Exception)
            {
            }

        }

        static void Process(string commands, RoverDirection directions, RoverPosition roverPosition)
        {
            foreach (char item in commands)
            {
                switch (item)
                {
                    case ('L'):
                        directions = TurnLeft(directions);
                        break;
                    case ('R'):
                        directions = TurnRight(directions);
                        break;
                    case ('M'):
                        roverPosition = Move(directions, roverPosition);
                        break;
                    default:
                        throw new ArgumentException(string.Format("Error: {0}", item));
                }
            }
        }

        static RoverDirection TurnLeft(RoverDirection direction)
        {
            direction.Direction = (direction.Direction - 1) < Directions.N ? Directions.W : (direction.Direction - 1);
            return direction;
        }

        static RoverDirection TurnRight(RoverDirection direction)
        {
            direction.Direction = (direction.Direction + 1) > Directions.W ? Directions.N : (direction.Direction + 1);
            return direction;
        }

        static RoverPosition Move(RoverDirection direction, RoverPosition roverPosition)
        {
            if (direction.Direction == Directions.N)
            {
                roverPosition.yCoordinate++;
            }
            else if (direction.Direction == Directions.E)
            {
                roverPosition.xCoordinate++;
            }
            else if (direction.Direction == Directions.S)
            {
                roverPosition.yCoordinate--;
            }
            else if (direction.Direction == Directions.W)
            {
                roverPosition.xCoordinate--;
            }

            return roverPosition;
        }
    }
}
