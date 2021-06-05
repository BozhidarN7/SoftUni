using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)

    {
        List<Coordinate> objects = new List<Coordinate>();
        Dictionary<string, Coordinate> byId = new Dictionary<string, Coordinate>();

        int tickes = 1;

        string commands = Console.ReadLine();
        while (commands != "end")
        {
            var tokens = commands.Split(' ');
            switch (tokens[0])
            {
                case "add":
                    {
                        Add(objects, byId, tokens);
                        break;
                    }
                case "start":
                    {
                        while (true)
                        {
                            commands = Console.ReadLine();
                            tokens = commands.Split(' ');
                            if (commands == "end")
                            {
                                return;
                            }

                            if (tokens[0] == "move")
                            {
                                string name = tokens[1];
                                int x = int.Parse(tokens[2]);
                                int y = int.Parse(tokens[3]);
                                byId[name].X1 = x;
                                byId[name].Y1 = y;
                            }

                            Sweep(tickes++, objects);
                        }
                    }
            }

            commands = Console.ReadLine();
        }
    }

    private static void Sweep(int tickes, List<Coordinate> objects)
    {
        InsertionSort(objects);

        for (int i = 0; i < objects.Count; i++)
        {
            var current = objects[i];
            for (int j = i + 1; j < objects.Count; j++)
            {
                var coordinate = objects[j];

                if (coordinate.X1 > current.X2)
                {
                    break;
                }

                if (current.Intersects(coordinate))
                {
                    Console.WriteLine("({0}) {1} collides with {2}", tickes, current.Name, coordinate.Name);
                }
            }
        }
    }
    private static void InsertionSort(List<Coordinate> objects)
    {
        for (int i = 1; i < objects.Count; i++)
        {
            var j = i;
            while (j > 0 && objects[j - 1].X1 > objects[j].X1)
            {
                var temp = objects[j - 1];
                objects[j - 1] = objects[j];
                objects[j] = temp;
                j--;
            }
        }
    }

    private static void Add(List<Coordinate> objects, Dictionary<string, Coordinate> byId, string[] tokens)
    {
        string name = tokens[1];
        int x = int.Parse(tokens[2]);
        int y = int.Parse(tokens[3]);
        Coordinate coordinae = new Coordinate(name, x, y);
        objects.Add(coordinae);
        byId[name] = coordinae;
    }
}

