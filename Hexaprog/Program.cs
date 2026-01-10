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
        public int x { get; set; }
        public int y { get; set; }
        public ConsoleColor color { get; set; }
        public char symbol { get; set; }

        public string ToCSV()
        {
            return $"{x},{y},{(int)color},{symbol}";
        }
        public static Point FromCSV(string csv)
        {
            string[] strings = csv.Split(',');
            return new Point()
            {
                x = int.Parse(strings[0]),
                y = int.Parse(strings[1]),
                color = (ConsoleColor)int.Parse(strings[2]),
                symbol = strings[3][0]
            };
        }

        public static void DrawPoint(Point point)
        {
            Console.SetCursorPosition(point.x, point.y);
            Console.ForegroundColor = point.color;
            Console.Write(point.symbol);
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {

            Rajzolas();

        }

        static void Frame()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write('─');
            }
            for (int i = 1; i < Console.WindowHeight; i++)
            {
                if (i == 1)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write('┌');
                }
                else if (i == Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write('└');
                }
                else
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write('│');
                }
            }
            for (int i = 1; i < Console.WindowHeight; i++)
            {
                if (i == 1)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 1, i);
                    Console.Write('┐');
                }
                else if (i == Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 1, i);
                    Console.Write('┘');
                }
                else
                {
                    Console.SetCursorPosition(Console.WindowWidth - 1, i);
                    Console.Write('│');
                }
            }
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write('─');
            }
        }

        static void Frame2()
        {
            Console.WriteLine();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                if (i == 0)
                {
                    Console.Write('┌');
                }
                else if (i == Console.WindowWidth - 1)
                {
                    Console.Write('┐');
                }
                else
                {
                    Console.Write('─');
                }
            }
            Console.WriteLine();
            for (int i = 0; i < Console.WindowHeight - 3; i++)
            {
                Console.Write('│');
                for (int j = 0; j < Console.WindowWidth - 2; j++)
                {
                    Console.Write(' ');
                }
                Console.Write("│");
            }

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                if (i == 0)
                {
                    Console.Write('└');
                }
                else if (i == Console.WindowWidth - 1)
                {
                    Console.Write('┘');
                }
                else
                {
                    Console.Write('─');
                }
            }
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
        static char[] Canvas()
        {
            List<char> canvas = new List<char>();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                if (i == 0)
                {
                    canvas.Add('┌');
                }
                else if (i == Console.WindowWidth - 1)
                {
                    canvas.Add('┐');
                }
                else
                {
                    canvas.Add('─');
                }
            }
            canvas.Add('\n');
            for (int i = 0; i < Console.WindowHeight - 2; i++)
            {
                canvas.Add('│');
                for (int j = 0; j < Console.WindowWidth - 2; j++)
                {
                    canvas.Add(' ');
                }
                canvas.Add('│');
                canvas.Add('\n');
            }

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                if (i == 0)
                {
                    canvas.Add('└');
                }
                else if (i == Console.WindowWidth - 1)
                {
                    canvas.Add('┘');
                }
                else
                {
                    canvas.Add('─');
                }
            }
            canvas.Add('\n');
            return canvas.ToArray();
        }

        static char[,] Canvas2()
        {
            char[,] canvas = new char[Console.WindowHeight, Console.WindowWidth];
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                if (i == 0)
                {
                    canvas[0, i] = '┌';
                }
                else if (i == Console.WindowHeight - 1)
                {
                    canvas[0, i] = '└';
                }
                else
                {
                    canvas[0, i] = '─';
                }
            }
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    if (j == 0)
                    {
                        canvas[j, i] = '─';
                    }
                    else if (j == Console.WindowHeight - 1)
                    {
                        canvas[j, i] = '─';
                    }
                    else
                    {
                        canvas[j, i] = ' ';
                    }
                }
            }
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                if (i == 0)
                {
                    canvas[i, Console.WindowWidth - 1] = '┐';
                }
                else if (i == Console.WindowHeight - 1)
                {
                    canvas[i, Console.WindowWidth - 1] = '┘';
                }
                else
                {
                    canvas[i, Console.WindowWidth - 1] = '|';
                }
            }
            for (int i = 1; i < Console.WindowHeight; i++)
            {
                if (i == Console.WindowHeight - 1)
                {
                    canvas[i, 0] = '└';
                }
                else
                {
                    canvas[i, 0] = '|';
                }

            }
            return canvas;
        }

        static (char, int)[,] Canvas3()
        {
            (char, int)[,] canvas = new (char, int)[Console.WindowHeight - 1, Console.WindowWidth];
            for (int i = 0; i < canvas.GetLength(0); i++)
            {
                if (i == 0)
                {
                    canvas[0, i] = ('┌', 15);
                }
                else if (i == canvas.GetLength(0) - 1)
                {
                    canvas[0, i] = ('└', 15);
                }
                else
                {
                    canvas[0, i] = ('─', 15);
                }
            }
            for (int i = 1; i < canvas.GetLength(1) - 1; i++)
            {
                for (int j = 0; j < canvas.GetLength(0); j++)
                {
                    if (j == 0)
                    {
                        canvas[j, i] = ('─', 15);
                    }
                    else if (j == canvas.GetLength(0) - 1)
                    {
                        canvas[j, i] = ('─', 15);
                    }
                    else
                    {
                        canvas[j, i] = (' ', 15);
                    }
                }
            }
            for (int i = 0; i < canvas.GetLength(0); i++)
            {
                if (i == 0)
                {
                    canvas[i, canvas.GetLength(1) - 1] = ('┐', 15);
                }
                else if (i == canvas.GetLength(0) - 1)
                {
                    canvas[i, canvas.GetLength(1) - 1] = ('┘', 15);
                }
                else
                {
                    canvas[i, canvas.GetLength(1) - 1] = ('│', 15);
                }
            }
            for (int i = 1; i < canvas.GetLength(0); i++)
            {
                if (i == canvas.GetLength(0) - 1)
                {
                    canvas[i, 0] = ('└', 15);
                }
                else
                {
                    canvas[i, 0] = ('│', 15);
                }

            }
            return canvas;
        }

        static void Save((char, int)[,] chars)
        {
            Stream streamD = new FileStream("draw.txt", FileMode.Truncate);
            Stream streamC = new FileStream("color.txt", FileMode.Truncate);

            StreamWriter writerD = new StreamWriter(streamD);
            StreamWriter writerC = new StreamWriter(streamC);

            writerD.AutoFlush = true;
            writerC.AutoFlush = true;

            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for (int j = 0; j < chars.GetLength(1); j++)
                {
                    writerD.Write(chars[i, j].Item1);
                }
                if (i != chars.GetLength(0) - 1)
                    writerD.WriteLine();
            }
            writerD.Close();

            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for (int j = 0; j < chars.GetLength(1); j++)
                {
                    writerC.Write(chars[i, j].Item2);
                    writerC.Write(" ");
                }
                if (i != chars.GetLength(0) - 1)
                    writerC.WriteLine();
            }
            writerC.Close();
        }

        static void SavePoints(List<Point> points)
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

        static (char, int)[,] Load(string pathD, string pathC)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 1);

            Stream streamD = new FileStream(pathD, FileMode.Open);
            Stream streamC = new FileStream(pathC, FileMode.Open);

            StreamReader readerD = new StreamReader(streamD);
            StreamReader readerC = new StreamReader(streamC);

            (char, int)[,] canvas = new (char, int)[Console.WindowHeight - 1, Console.WindowWidth];
            char[,] draw = new char[Console.WindowHeight - 1, Console.WindowWidth];
            int[,] color = new int[Console.WindowHeight - 1, Console.WindowWidth];

            for (int i = 0; i < draw.GetLength(0); i++)
            {
                string line = readerD.ReadLine()!;
                for (int j = 0; j < draw.GetLength(1); j++)
                {
                    draw[i, j] = line[j];
                }
            }
            readerD.Close();

            for (int i = 0; i < color.GetLength(0); i++)
            {
                string[] line = readerC.ReadLine()!.Split();
                for (int j = 0; j < color.GetLength(1); j++)
                {
                    color[i, j] = int.Parse(line[j]);
                }
            }
            readerC.Close();

            for (int i = 0; i < canvas.GetLength(0); i++)
            {
                for (int j = 0; j < canvas.GetLength(1); j++)
                {
                    canvas[i, j] = (draw[i, j], color[i, j]);
                }
            }

            for (int i = 0; i < draw.GetLength(0); i++)
            {
                for (int j = 0; j < draw.GetLength(1); j++)
                {
                    Console.ForegroundColor = (ConsoleColor)canvas[i, j].Item2;
                    Console.Write(canvas[i, j].Item1);
                }
                if (i != draw.GetLength(0) - 1)
                {
                    Console.WriteLine();
                }
            }

            return canvas;
        }

        static List<Point> LoadPoints(string pathD)
        {
            Console.Clear();
            Frame3();
            Console.SetCursorPosition(0, 1);
            List<Point> points = new List<Point>();

            string[] lines = File.ReadAllLines(pathD);

            for (int i = 0; i < lines.Length; i++)
            {
                points.Add(Point.FromCSV(lines[i]));
                Point.DrawPoint(points[i]);
            }

            return points;
        }
        public struct Status
        {
            public ConsoleColor color;
            public char intensity;
            public char mode;
            public char save;
            public string text;

            public void DrawStatus()
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = color;
                Console.Write(intensity);
                Console.ForegroundColor = (ConsoleColor)15;
                Console.Write($" {mode} {save} {text}");
            }
        }

        static void PointDraw(int x, int y, char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        static void Rajzolas()
        {
            char[] ch = ['░', '▒', '▓', '█', ' '];
            (int, int) pos = (0, 0);
            int intensity = 3;
            int color = 15;
            Console.ForegroundColor = (ConsoleColor)color;
            bool help = false;
            ((int, int), bool) square = ((0, 0), false);
            ((int, int), bool) circle = ((0, 0), false);
            List<Point> points = new List<Point>();
            Status status = new Status();
            status.color = (ConsoleColor)color;
            status.intensity = ch[intensity];
            status.mode = 'D';
            status.save = 'U';
            status.text = "Press F1 for help (your progress will be saved)";
            status.DrawStatus();
            Frame3();

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            pos = Console.GetCursorPosition();


            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        if (pos.Item2 > 2 && Console.CapsLock)
                        {
                            points.Add(new Point()
                            {
                                x = pos.Item1,
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            Console.Write(ch[intensity]);
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
                            points.Add(new Point()
                            {
                                x = pos.Item1,
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            Console.Write(ch[intensity]);
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
                            points.Add(new Point()
                            {
                                x = pos.Item1,
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            Console.Write(ch[intensity]);
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
                            points.Add(new Point()
                            {
                                x = pos.Item1,
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            Console.Write(ch[intensity]);
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
                            x = pos.Item1,
                            y = pos.Item2,
                            color = (ConsoleColor)color,
                            symbol = ch[intensity]
                        });
                        Console.Write(ch[intensity]);
                        pos = Console.GetCursorPosition();
                        break;
                    case ConsoleKey.S:
                        SavePoints(points);
                        Console.SetCursorPosition(4, 0);
                        Console.Write('S');
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        break;
                    case ConsoleKey.L:
                        points = LoadPoints("draw.txt");
                        status.DrawStatus();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;
                    case ConsoleKey.F1:
                        if (!help)
                        {
                            SavePoints(points);
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
                            Console.Write("Press R to reset your canvas.");
                            Console.SetCursorPosition(1, 8);
                            Console.Write("Use the add and subtract buttons to change your brush intesity.");
                            help = true;
                        }
                        else
                        {
                            Console.Clear();
                            LoadPoints("draw.txt");
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
                                        x = j,
                                        y = i,
                                        color = (ConsoleColor)color,
                                        symbol = ch[intensity]
                                    });
                                    Console.SetCursorPosition(j, i);
                                    Console.Write(ch[intensity]);
                                }
                            }
                            Console.SetCursorPosition(pos.Item1, pos.Item2);
                            square.Item2 = false;
                        }
                        break;
                    case ConsoleKey.A:
                        int r;
                        int rpow;
                        if (!circle.Item2)
                        {
                            circle.Item1 = pos;
                            circle.Item2 = true;
                        }
                        else
                        {
                            r = circle.Item1.Item1 - pos.Item1;
                            rpow = r * r;
                            Console.Write(ch[intensity]);
                            Console.SetCursorPosition(pos.Item1 + 1, pos.Item2);
                            Console.Write(ch[intensity]);
                            pos = circle.Item1;
                            Console.SetCursorPosition(pos.Item1 - (int)(r * 1.6), pos.Item2);
                            Console.Write(ch[intensity]); 
                            points.Add(new Point()
                            {
                                x = pos.Item1 - (int)(r * 1.6),
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                x = pos.Item1 - (int)(r * 1.6) + 1,
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            pos.Item1++;
                            for (int j = 1; j <= r; j++)
                            {
                                for (int i = 0; i < r * 2 - (r / 2.8); i++)
                                {
                                    if (Math.Pow((double)(circle.Item1.Item1 - pos.Item1), 2) + Math.Pow((double)(circle.Item1.Item2 - pos.Item2), 2) <= (rpow - j * r) * Math.PI - 3)
                                    {
                                        PointDraw(pos.Item1, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            x = pos.Item1,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });
                                        PointDraw(pos.Item1 - i * 2, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            x = pos.Item1 - i * 2,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });
                                        pos.Item1++;
                                    }
                                }
                                pos = circle.Item1;
                                pos.Item2 -= 1 * j;
                            }
                            pos = (pos.Item1 + r, pos.Item2);

                            for (int j = 1; j <= r; j++)
                            {
                                for (int i = 0; i < r * 2 - (r / 2.8); i++)
                                {
                                    if (Math.Pow((double)(circle.Item1.Item1 - pos.Item1), 2) + Math.Pow((double)(circle.Item1.Item2 - pos.Item2), 2) <= (rpow - j * r) * Math.PI - 3 && circle.Item1.Item2 + pos.Item2 > circle.Item1.Item2 + r)
                                    {

                                        PointDraw(pos.Item1, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            x = pos.Item1,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });
                                        PointDraw(pos.Item1 - i * 2, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            x = pos.Item1 - i * 2,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });
                                        pos.Item1++;
                                    }
                                }
                                pos = circle.Item1;

                                pos.Item2 += 1 * j;


                            }
                        }
                        break;
                    case ConsoleKey.C:
                        int rc;
                        int rcpow;
                        if (!circle.Item2)
                        {
                            circle.Item1 = pos;
                            circle.Item2 = true;
                        }
                        else
                        {
                            rc = circle.Item1.Item1 - pos.Item1;
                            rcpow = rc * rc;
                            Console.Write(ch[intensity]);
                            Console.SetCursorPosition(pos.Item1 + 1, pos.Item2);
                            Console.Write(ch[intensity]);
                            pos = circle.Item1;
                            Console.SetCursorPosition(pos.Item1 - (int)(rc * 1.6), pos.Item2);
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                x = pos.Item1 - (int)(rc * 1.6),
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            Console.Write(ch[intensity]);
                            points.Add(new Point()
                            {
                                x = pos.Item1 - (int)(rc * 1.6) + 1,
                                y = pos.Item2,
                                color = (ConsoleColor)color,
                                symbol = ch[intensity]
                            });
                            pos.Item1++;
                            for (int j = 1; j <= rc; j++)
                            {
                                for (int i = 0; i < rc * 2 - (rc / 2.8); i++)
                                {
                                    if (Math.Pow((double)(circle.Item1.Item1 - pos.Item1), 2) + Math.Pow((double)(circle.Item1.Item2 - pos.Item2), 2) <= (rcpow - j * rc) * Math.Cos(i*j) * Math.Tanh(i*j))
                                    {
                                        PointDraw(pos.Item1, pos.Item2, ch[intensity]);

                                        points.Add(new Point()
                                        {
                                            x = pos.Item1,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });

                                        PointDraw(pos.Item1 - i * 2, pos.Item2, ch[intensity]);

                                        points.Add(new Point()
                                        {
                                            x = pos.Item1 - i * 2,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });
                                        pos.Item1++;
                                    }
                                }
                                pos = circle.Item1;
                                pos.Item2 -= 1 * j;
                            }
                            pos = (pos.Item1 + rc, pos.Item2);

                            for (int j = 1; j <= rc; j++)
                            {
                                for (int i = 0; i < rc * 2 - (rc / 2.8); i++)
                                {
                                    if (Math.Pow((double)(circle.Item1.Item1 - pos.Item1), 2) + Math.Pow((double)(circle.Item1.Item2 - pos.Item2), 2) <= (rcpow - j * rc) * Math.Cos(i*j) * Math.Tanh(i*j)&& circle.Item1.Item2 + pos.Item2 > circle.Item1.Item2 + rc)
                                    {

                                        PointDraw(pos.Item1, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            x = pos.Item1,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });
                                        PointDraw(pos.Item1 - i * 2, pos.Item2, ch[intensity]);
                                        points.Add(new Point()
                                        {
                                            x = pos.Item1 - i * 2,
                                            y = pos.Item2,
                                            color = (ConsoleColor)color,
                                            symbol = ch[intensity]
                                        });
                                        pos.Item1++;
                                    }
                                }
                                pos = circle.Item1;

                                pos.Item2 += 1 * j;


                            }
                        }
                        break;
                }
            }
        }
    }
}
