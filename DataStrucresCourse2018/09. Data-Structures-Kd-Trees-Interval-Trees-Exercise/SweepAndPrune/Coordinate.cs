using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Coordinate
{
    public string Name { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get { return X1 + 10; } }
    public int Y2 { get { return Y1 + 10; } }

    public Coordinate(string name, int x, int y)
    {
        this.Name = name;
        this.X1 = x;
        this.Y1 = y;
    }

    public bool Intersects(Coordinate that)
    {
        return this.X1 <= that.X2 && this.X2 > that.X1 && this.Y1 < that.Y2 && this.Y2 >= that.Y1;
    }
}

