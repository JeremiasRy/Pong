using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary.GameObjects;

public class BallTrail : IGameObject
{
    public int Y { get; set; }
    public int X { get; set; }


    readonly char[] shades = new char[]
        {
        '\u2593',
        '\u2592',
        '\u2591'
        };

    public void Draw()
    {
        if (X == 0)
        {
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            if (GameState.Right)
            {
                int x = X - GameState.Speed * i;
                if (x < 2)
                {
                    break;
                } else
                {
                    ScreenBuffer.Draw(shades[i], GameState.AllThePos[x], x);
                }
            } else
            {
                int x = X + GameState.Speed * i;
                if (x > 196)
                {
                    break;
                }
                else
                {
                    ScreenBuffer.Draw(shades[i], GameState.AllThePos[x], x);
                }

            }
        }
    }
}

