using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary.GameObjects;

public class Paddle : IGameObject
{
    private int _y = Console.WindowHeight / 2;
    public int Y { get => _y; set { if (value <= 4) { _y = 4; } else if (value >= 47) { _y = 47; } else { _y = value; } } }
    public int X { get; set; }

    public int Score { get; set; } = 0;

    public void Draw()
    {
        int topY = Y - 4;
        int[] _positions = new int[7];
        for (int i = 0; i < 7; i++)
        {
            _positions[i] = topY + i;
        }
        foreach (int yPos in _positions)
            ScreenBuffer.Draw('\u2588', yPos, X);

    }

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
