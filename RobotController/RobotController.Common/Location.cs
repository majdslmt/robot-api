using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Common
{
    public class Location : IComparable<Location>
    {
        private int x;
        private int y;

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public override string ToString()
        {
            return x + "$" + y;
        }


        public int CompareTo(Location other)
        {
            if (this.X == other.X)
                return this.Y.CompareTo(other.Y);
            return this.X.CompareTo(other.X);
        }

        public void Validate(Location bottomLeftBound, Location topRightBound)
        {
            if (bottomLeftBound != null)
            {
                if (x < bottomLeftBound.X) x = bottomLeftBound.X;
                if (y < bottomLeftBound.Y) y = bottomLeftBound.Y;
            }
            if (topRightBound != null)
            {
                if (x > topRightBound.X) x = topRightBound.X;
                if (y > topRightBound.Y) y = topRightBound.Y;
            }

        }


    }
}
