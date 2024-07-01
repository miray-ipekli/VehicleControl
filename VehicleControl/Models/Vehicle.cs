using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleControl.Enums;

namespace VehicleControl.Models
{
    public class Vehicle
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public Vehicle(int x, int y, Direction direction)
        {
            Position = new Position(x, y);
            Direction = direction;
        }
    }
}
