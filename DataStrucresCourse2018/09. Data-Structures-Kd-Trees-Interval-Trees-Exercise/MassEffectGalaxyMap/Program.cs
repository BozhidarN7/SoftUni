using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int startClusters = int.Parse(Console.ReadLine());
        int numberOfReports = int.Parse(Console.ReadLine());
        int size = int.Parse(Console.ReadLine());
        List<Point2D> points = new List<Point2D>();
        //KdTree tree = new KdTree(size, size);

        for (int i = 0; i < startClusters; i++)
        {
            var line = Console.ReadLine().Split(' ');
            int x = int.Parse(line[1]);
            int y = int.Parse(line[2]);
            Point2D point = new Point2D(x, y);
            //tree.Insert(point);
            points.Add(point);

        }

        KdTree tree1 = new KdTree(size, size);
        tree1.BuildFromList(points);

        for (int i = 0; i < numberOfReports; i++)
        {
            var line = Console.ReadLine().Split(' ');
            int x = int.Parse(line[1]);
            int y = int.Parse(line[2]);
            int width = int.Parse(line[3]);
            int height = int.Parse(line[4]);

            Rectangle area = new Rectangle(x, y, width, height);
            List<Point2D> result = tree1.RangeSearch(area).ToList();
            Console.WriteLine(result.Count);
        }
    }
}

