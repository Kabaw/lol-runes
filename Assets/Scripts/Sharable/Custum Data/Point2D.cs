using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLRunes.CustumData
{
    [Serializable]
    public struct Point2D
    {
        public int x;
        public int y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #region Operators Overload
        public static Point2D operator +(Point2D p1, Point2D p2)
        {
            p1.x += p2.x;
            p1.y += p2.y;

            return p1;
        }

        public static Point2D operator -(Point2D p1, Point2D p2)
        {
            p1.x -= p2.x;
            p1.y -= p2.y;

            return p1;
        }

        public static bool operator ==(Point2D p1, Point2D p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        public static bool operator !=(Point2D p1, Point2D p2)
        {
            return p1.x != p2.x || p1.y != p2.y;
        }
        #endregion
    }
}
