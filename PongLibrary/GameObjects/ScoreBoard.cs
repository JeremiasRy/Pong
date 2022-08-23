using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary.GameObjects;

public class ScoreBoard : IGameObject
{
    public int X { get; set; } = Console.WindowWidth / 4;
    public int Y { get; set; } = 5;

    readonly char _block = '\u2588';

    public void Draw()
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                int[] pos = new int[2] { y, x };
                if (!numbers[GameState._human.Score].Where(x => x[0] == pos[0] && x[1] == pos[1]).Any())
                {
                    ScreenBuffer.Draw(_block, Y + y, X + x);
                }
                if (!numbers[GameState._computer.Score].Where(x => x[0] == pos[0] && x[1] == pos[1]).Any())
                {
                    ScreenBuffer.Draw(_block, Y + y, X * 3 + x);
                }
                
                
            }
        }
    }
    Dictionary<int, List<int[]>> numbers = new Dictionary<int, List<int[]>>();

    readonly List<int[]> zero = new List<int[]>()
    {
        new int[2] {1,1},
        new int[2] {2,1},
        new int[2] {3,1},
    };
    readonly List<int[]> one = new List<int[]>()
    {
        new int[2] {0,0},
        new int[2] {1,0},
        new int[2] {2,0},
        new int[2] {3,0},
        new int[2] {4,0},
        new int[2] {0,2},
        new int[2] {1,2},
        new int[2] {2,2},
        new int[2] {3,2},
        new int[2] {4,2},
    };
    readonly List<int[]> two = new List<int[]>()
    {
        new int[2] {1,0},
        new int[2] {1,1},
        new int[2] {3,1},
        new int[2] {3,2},
    };
    readonly List<int[]> three = new List<int[]>()
    {
        new int[2] {1,0},
        new int[2] {1,1},
        new int[2] {3,0},
        new int[2] {3,1},
    };
    readonly List<int[]> four = new List<int[]>()
    {
        new int[2] {0,1},
        new int[2] {1,1},
        new int[2] {3,1},
        new int[2] {4,1},
        new int[2] {3,0},
        new int[2] {4,0},
    };
    readonly List<int[]> five = new List<int[]>()
    {
        new int[2] {1,1},
        new int[2] {1,2},
        new int[2] {3,0},
        new int[2] {3,1},
    };
    readonly List<int[]> six = new List<int[]>()
    {
        new int[2] {0,1},
        new int[2] {1,1},
        new int[2] {3,1},
        new int[2] {4,1},
        new int[2] {3,0},
        new int[2] {4,0},
    };
    readonly List<int[]> seven = new List<int[]>()
    {
        new int[2] {1,0},
        new int[2] {1,1},
        new int[2] {2,0},
        new int[2] {2,1},
        new int[2] {3,0},
        new int[2] {3,1},
        new int[2] {4,0},
        new int[2] {4,1},
    };
    readonly List<int[]> eight = new List<int[]>()
    {
        new int[2] {1,1},
        new int[2] {3,1},
    };
    readonly List<int[]> nine = new List<int[]>()
    {
        new int[2] {1,1},
        new int[2] {3,1},
        new int[2] {3,0},
    };


    public ScoreBoard()
    {
        numbers.Add(0, zero);
        numbers.Add(1, one);
        numbers.Add(2, two);
        numbers.Add(3, three);
        numbers.Add(4, four);
        numbers.Add(5, five);
        numbers.Add(6, six);
        numbers.Add(7, seven);
        numbers.Add(8, eight);
        numbers.Add(9, nine);
    }
}
