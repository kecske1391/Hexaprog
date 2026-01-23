using System.Drawing;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hexaprog
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public char Symbol { get; set; }
        public int Page { get; set; }

        public string ToCSV()
        {
            return $"{X},{Y},{(int)Color},{Symbol},{Page}";
        }
        public static Point FromCSV(string csv)
        {
            string[] strings = csv.Split(',');
            return new Point()
            {
                X = int.Parse(strings[0]),
                Y = int.Parse(strings[1]),
                Color = (ConsoleColor)int.Parse(strings[2]),
                Symbol = strings[3][0],
                Page = int.Parse(strings[4])
            };
        }

        public static void DrawPoint(Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.ForegroundColor = point.Color;
            Console.Write(point.Symbol);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rajzolas();
        }
        static void Frame3()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write('┌');
            Console.Write("─".PadLeft(Console.WindowWidth - 2, '─'));
            Console.Write('┐');
            Console.WriteLine();

            for (int i = 0; i < Console.WindowHeight - 3; i++)
            {
                Console.Write('│');
                Console.Write(" ".PadRight(Console.WindowWidth - 2));
                Console.Write("│");
            }

            Console.Write('└');
            Console.Write("─".PadRight(Console.WindowWidth - 2, '─'));
            Console.Write('┘');
        }
        static void SaveFile(List<Point> points)
        {
            Stream streamD = new FileStream("draw.txt", FileMode.Truncate);

            StreamWriter writerD = new StreamWriter(streamD);

            writerD.AutoFlush = true;

            for (int i = 0; i < points.Count; i++)
            {
                writerD.Write($"{points[i].ToCSV()}\r\n");
            }
            writerD.Close();

        }
        static List<Point> LoadFile(string pathD, int pagenum)
        {
            Console.Clear();
            Frame3();
            Console.SetCursorPosition(0, 1);
            List<Point> points = new List<Point>();

            string[] lines = File.ReadAllLines(pathD);

            for (int i = 0; i < lines.Length; i++)
            {
                points.Add(Point.FromCSV(lines[i]));
                if (points[i].Page == pagenum)
                {
                    Point.DrawPoint(points[i]);
                }
            }

            return points;
        }
        static void LoadPoints(List<Point> points, int pagenum)
        {
            Console.Clear();
            Frame3();

            Console.SetCursorPosition(0, 1);

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Page == pagenum)
                {
                    Point.DrawPoint(points[i]);
                }
            }
        }
        public struct Status
        {
            public ConsoleColor color;
            public char intensity;
            public char mode;
            public char save;
            public string text;
            public int page;
            public void DrawStatus()
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = color;
                Console.Write(intensity);
                Console.ForegroundColor = (ConsoleColor)15;
                Console.Write($" {mode} {save} {page} {text}");
            }
        }
        static void PointDraw(int x, int y, string ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }
        static void PointDraw(int x, int y, char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }
        static void Rajzolas()
        {
            #region Setup
            string pixel = "██";
            char[] ch = ['░', '▒', '▓', '█', ' '];
            (int, int) pos = (0, 0);
            int intensity = 3;
            int color = 15;
            int pagenum = 0;
            Console.ForegroundColor = (ConsoleColor)color;
            bool help = false;
            ((int, int), bool) square = ((0, 0), false);
            ((int, int), bool) circle = ((0, 0), false);
            ((int, int), bool) hazard = ((0, 0), false);
            List<Point> points = new List<Point>();
            Status status = new Status();
            status.color = (ConsoleColor)color;
            status.intensity = ch[intensity];
            status.mode = 'D';
            status.save = 'U';
            status.page = pagenum + 1;
            status.text = "Press F1 for help (your progress will be saved)";
            status.DrawStatus();
            Frame3();

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            pos = Console.GetCursorPosition();
            #endregion

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        if (pos.Item2 > 2 && Console.CapsLock)
                        {
                            
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                X = pos.Item1,
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                            Console.CursorTop--;
                            Console.CursorLeft--;
                        }
                        else if (pos.Item2 > 2)
                        {
                            Console.CursorTop--;
                        }
                        pos = Console.GetCursorPosition();
                        break;
                    case ConsoleKey.DownArrow:
                        if (pos.Item2 < Console.WindowHeight - 2 && Console.CapsLock)
                        {
                            
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                X = pos.Item1,
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                            Console.CursorTop++;
                            Console.CursorLeft--;
                        }
                        else if (pos.Item2 < Console.WindowHeight - 2)
                        {
                            Console.CursorTop++;
                        }
                        pos = Console.GetCursorPosition();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (pos.Item1 > 1 && Console.CapsLock)
                        {
                            
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                X = pos.Item1,
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                            Console.CursorLeft--;
                            Console.CursorLeft--;
                        }
                        else if (pos.Item1 > 1)
                        {
                            Console.CursorLeft--;
                        }
                        pos = Console.GetCursorPosition();
                        break;
                    case ConsoleKey.RightArrow:
                        if (pos.Item1 < Console.WindowWidth - 2 && Console.CapsLock)
                        {
                            
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                X = pos.Item1,
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                        }
                        else if (pos.Item1 < Console.WindowWidth - 2)
                        {
                            Console.CursorLeft++;
                        }
                        pos = Console.GetCursorPosition();
                        break;
                    case ConsoleKey.NumPad1:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 0);
                        color = 15;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.NumPad2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0, 0);
                        color = 12;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;

                        break;
                    case ConsoleKey.NumPad3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(0, 0);
                        color = 9;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;

                        break;
                    case ConsoleKey.NumPad4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        color = 10;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.NumPad5:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(0, 0);
                        color = 11;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.NumPad6:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(0, 0);
                        color = 7;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.NumPad7:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.SetCursorPosition(0, 0);
                        color = 1;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.NumPad8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        color = 14;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;

                        break;
                    case ConsoleKey.NumPad9:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(0, 0);
                        color = 13;
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;

                        break;
                    case ConsoleKey.NumPad0:
                        Console.ForegroundColor = ConsoleColor.Black;
                        color = 0;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(ch[intensity]);
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.E:
                        if (intensity < 4)
                        {
                            intensity = 4;
                            Console.SetCursorPosition(3, 0);
                            Console.Write('E');
                            Console.SetCursorPosition(pos.Item1, pos.Item2);
                        }
                        else
                        {
                            intensity = 3;
                            Console.SetCursorPosition(3, 0);
                            Console.Write('D');
                            Console.SetCursorPosition(pos.Item1, pos.Item2);
                        }
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.R:
                        Console.Clear();
                        for (int i = 0; i < points.Count; i++)
                        {
                            if (points[i].Page == pagenum)
                            {
                                points.Remove(points[i]);
                            }
                        }
                        status.DrawStatus();
                        Frame3();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        pos = Console.GetCursorPosition();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case ConsoleKey.Add:
                        if (intensity < 3)
                        {
                            intensity++;
                            Console.SetCursorPosition(0, 0);
                            Console.Write(ch[intensity]);
                            Console.SetCursorPosition(pos.Item1, pos.Item2);
                        }
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.Subtract:
                        if (intensity > 0)
                        {
                            intensity--;
                            Console.SetCursorPosition(0, 0);
                            Console.Write(ch[intensity]);
                            Console.SetCursorPosition(pos.Item1, pos.Item2);
                        }
                        Console.CursorLeft--;
                        Console.Write(' ');
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.Spacebar:
                        points.Add(new Point()
                        {
                            X = pos.Item1,
                            Y = pos.Item2,
                            Color = (ConsoleColor)color,
                            Symbol = ch[intensity],
                            Page = pagenum
                        });
                        Console.Write(ch[intensity]);
                        pos = Console.GetCursorPosition();
                        break;
                    case ConsoleKey.S:
                        SaveFile(points);
                        Console.SetCursorPosition(4, 0);
                        Console.Write('S');
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        break;
                    case ConsoleKey.L:
                        points = LoadFile("draw.txt", pagenum);
                        status.DrawStatus();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;
                    case ConsoleKey.F1:
                        if (!help)
                        {
                            SaveFile(points);
                            Console.Clear();
                            Frame3();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Wellcome to the help screen of this program! I recomend double tapping commands for consistency. Press F1 to leave.");
                            Console.SetCursorPosition(1, 2);
                            Console.Write("Use the arrows for movement.");
                            Console.SetCursorPosition(1, 3);
                            Console.Write("Press space to draw or toggle wiht caps lock.");
                            Console.SetCursorPosition(1, 4);
                            Console.Write("Use the numpad to change the color of the brush.");
                            Console.SetCursorPosition(1, 5);
                            Console.Write("Press S to save and L to load your drawing.");
                            Console.SetCursorPosition(1, 6);
                            Console.Write("Press E to switch to eraser mode.");
                            Console.SetCursorPosition(1, 7);
                            Console.Write("Press R to reset your current page.");
                            Console.SetCursorPosition(1, 8);
                            Console.Write("Use the add and subtract buttons to change your brush intesity.");
                            Console.SetCursorPosition(1, 9);
                            Console.Write("Use the O button to determain a circle center point, then press it again in a different place to add the radius.");
                            Console.SetCursorPosition(1, 10);
                            Console.Write("Use the C button the same way as the O button to generate a cognito hazard. It is also recommended to resize the");
                            Console.SetCursorPosition(1, 11);
                            Console.Write("console to a bigger resolution. It is not recommended to save it, or do not forget to resize the console.");
                            Console.SetCursorPosition(1, 12);
                            Console.Write("Press F3 to change the page upwards, or create a new one.");
                            Console.SetCursorPosition(1, 13);
                            Console.Write("Press F2 to change the page downwards.");
                            Console.SetCursorPosition(1, 15);
                            Console.Write("On the top left is the status bar, the simbols from left to right: The character and color");
                            Console.SetCursorPosition(1, 16);
                            Console.Write("                                                                   The drawing mode: D = draw, E = erase");
                            Console.SetCursorPosition(1, 17);
                            Console.Write("                                                                   The save status: U = unsaved, s = saved");
                            Console.SetCursorPosition(1, 18);
                            Console.Write("                                                                   The page number");
                            Console.SetCursorPosition(1, 20);
                            Console.Write("Colors on the num pad: 0 = Black, 1 = White, 2 = Red, 3 = Blue, 4 = Green, 5 = Cyan");
                            Console.SetCursorPosition(1, 21);
                            Console.Write("                       6 = Gray, 7 = Dark blue, 8 = Yellow, 9 = Magenta");
                            help = true;
                        }
                        else
                        {
                            Console.Clear();
                            LoadFile("draw.txt", pagenum);
                            status.DrawStatus();
                            Console.SetCursorPosition(pos.Item1, pos.Item2);
                            help = false;
                        }

                        break;
                    case ConsoleKey.X:
                        if (!square.Item2)
                        {
                            square.Item1 = pos;
                            square.Item2 = true;
                        }
                        else
                        {
                            for (int i = Math.Min(square.Item1.Item2, pos.Item2); i <= Math.Max(square.Item1.Item2, pos.Item2); i++)
                            {
                                for (int j = Math.Min(square.Item1.Item1, pos.Item1); j <= Math.Max(square.Item1.Item1, pos.Item1); j++)
                                {
                                    points.Add(new Point()
                                    {
                                        X = j,
                                        Y = i,
                                        Color = (ConsoleColor)color,
                                        Symbol = ch[intensity],
                                        Page = pagenum
                                    });
                                    Console.SetCursorPosition(j, i);
                                    Console.Write(ch[intensity]);
                                }
                            }
                            Console.SetCursorPosition(pos.Item1, pos.Item2);
                            square.Item2 = false;
                        }
                        break;               
                    case ConsoleKey.C:
                        int rc;
                        int rcpow;
                        if (!hazard.Item2)
                        {
                            hazard.Item1 = pos;
                            hazard.Item2 = true;
                        }
                        else
                        {
                            hazard.Item2 = false;
                            rc = hazard.Item1.Item1 - pos.Item1;
                            rcpow = rc * rc;
                            Console.Write(ch[intensity]);
                            Console.SetCursorPosition(pos.Item1 + 1, pos.Item2);
                            Console.Write(ch[intensity]);
                            pos = hazard.Item1;
                            Console.SetCursorPosition(pos.Item1 - (int)(rc * 1.6), pos.Item2);
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                X = pos.Item1 - (int)(rc * 1.6),
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                X = pos.Item1 - (int)(rc * 1.6) + 1,
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                            pos.Item1++;
                            for (int j = 1; j <= rc; j++)
                            {
                                for (int i = 0; i < rc * 2 - (rc / 2.8); i++)
                                {
                                    if (Math.Pow((double)(hazard.Item1.Item1 - pos.Item1), 2) + Math.Pow((double)(hazard.Item1.Item2 - pos.Item2), 2) <= (rcpow - j * rc) * Math.Cos(i * j) * Math.Tanh(i * j))
                                    {
                                        PointDraw(pos.Item1, pos.Item2, ch[intensity]);

                                        points.Add(new Point()
                                        {
                                            X = pos.Item1,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });

                                        PointDraw(pos.Item1 - i * 2, pos.Item2, ch[intensity]);

                                        points.Add(new Point()
                                        {
                                            X = pos.Item1 - i * 2,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });
                                        pos.Item1++;
                                    }
                                }
                                pos = hazard.Item1;
                                pos.Item2 -= 1 * j;
                            }
                            pos = (pos.Item1 + rc, pos.Item2);

                            for (int j = 1; j <= rc; j++)
                            {
                                for (int i = 0; i < rc * 2 - (rc / 2.8); i++)
                                {
                                    if (Math.Pow((double)(hazard.Item1.Item1 - pos.Item1), 2) + Math.Pow((double)(hazard.Item1.Item2 - pos.Item2), 2) <= (rcpow - j * rc) * Math.Cos(i * j) * Math.Tanh(i * j) && hazard.Item1.Item2 + pos.Item2 > hazard.Item1.Item2 + rc)
                                    {

                                        PointDraw(pos.Item1, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            X = pos.Item1,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });
                                        PointDraw(pos.Item1 - i * 2, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            X = pos.Item1 - i * 2,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });
                                        pos.Item1++;
                                    }
                                }
                                pos = hazard.Item1;

                                pos.Item2 += 1 * j;


                            }
                        }
                        break;
                    case ConsoleKey.O:
                        int r;
                        int rpow;
                        if (!circle.Item2)
                        {
                            circle.Item1 = pos;
                            circle.Item2 = true;
                        }
                        else
                        {
                            circle.Item2 = false;
                            r = circle.Item1.Item1 - pos.Item1;
                            rpow = r * r;
                            Console.SetCursorPosition(pos.Item1 + 1, pos.Item2);
                            Console.Write(ch[intensity]);
                            Console.Write(ch[intensity]);
                            Console.Write(ch[intensity]);
                            pos = circle.Item1;
                            Console.SetCursorPosition(pos.Item1 - (int)(r * 1.6), pos.Item2);
                            points.Add(new Point()
                            {
                                X = pos.Item1 - (int)(r * 1.6),
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                            points.Add(new Point()
                            {
                                X = pos.Item1 - (int)(r * 1.6) + 1,
                                Y = pos.Item2,
                                Color = (ConsoleColor)color,
                                Symbol = ch[intensity],
                                Page = pagenum
                            });
                            pos.Item1++;
                            for (int j = 0; j < r; j++)
                            {
                                for (int i = 0; i < r; i++)
                                {
                                    if (Math.Pow((double)(circle.Item1.Item1 - pos.Item1), 2) - r + Math.Pow((double)(circle.Item1.Item2 - pos.Item2), 2) - r <= (rpow - j * r))
                                    {
                                        PointDraw(pos.Item1, pos.Item2, pixel);
                                        points.Add(new Point()
                                        {
                                            X = pos.Item1,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });
                                        PointDraw(pos.Item1 - i * 2 * 2, pos.Item2, pixel);
                                        points.Add(new Point()
                                        {
                                            X = pos.Item1 - i * 2,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });
                                        pos.Item1++;
                                        pos.Item1++;

                                    }
                                }
                                pos = circle.Item1;
                                pos.Item2 -= 1 * j;
                            }
                            pos = (pos.Item1 + r, pos.Item2);

                            for (int j = 0; j < r; j++)
                            {
                                for (int i = 0; i < r; i++)
                                {
                                    if (Math.Pow((double)(circle.Item1.Item1 - pos.Item1), 2) - r + Math.Pow((double)(circle.Item1.Item2 - pos.Item2), 2) - r <= (rpow - j * r))
                                    {

                                        PointDraw(pos.Item1, pos.Item2, pixel);
                                        points.Add(new Point()
                                        {
                                            X = pos.Item1,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });
                                        PointDraw(pos.Item1 - i * 2 * 2, pos.Item2, pixel);
                                        points.Add(new Point()
                                        {
                                            X = pos.Item1 - i * 2,
                                            Y = pos.Item2,
                                            Color = (ConsoleColor)color,
                                            Symbol = ch[intensity],
                                            Page = pagenum
                                        });
                                        pos.Item1++;
                                        pos.Item1++;
                                    }
                                }
                                pos = circle.Item1;
                                pos.Item2 += 1 * j;
                            }
                        }
                        break;
                    case ConsoleKey.F3:
                        pos = Console.GetCursorPosition();
                        SaveFile(points);
                        Console.Clear();
                        pagenum++;
                        LoadPoints(points, pagenum);
                        status.page = pagenum + 1;
                        status.DrawStatus();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;
                    case ConsoleKey.F2:
                        if (pagenum != 0)
                        {
                            pos = Console.GetCursorPosition();
                            SaveFile(points);
                            Console.Clear();
                            pagenum--;
                            status.page = pagenum + 1;
                            LoadPoints(points, pagenum);
                            status.DrawStatus();
                            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        }
                        break;
                }
            }
        }
    }
}
