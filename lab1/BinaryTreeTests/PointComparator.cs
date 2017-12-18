using System.Collections.Generic;

namespace BinaryTreeUnitTests
{
    public class PointComparator : IComparer<Point>
    {
        public int Compare(Point point1, Point point2)
        {
            return point1.x.CompareTo(point1.x);
        }
    }
}
