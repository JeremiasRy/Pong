using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary;

public class Paddle
{
    private int _y = Console.WindowHeight / 2;

    public int Y { get => _y; set { if (value <= 2) { _y = 2; } else if (value >= 47) { _y = 47; } else { _y = value; } } }
    public int X { get; set; }

    public int TopY { get => Y - 2; }

    public Paddle(bool human)
    {
        if (human)
        {
            X = 1;
        }
        else
        {
            X = Console.WindowWidth - 2;
        }

    }
}
