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
            return new Point() { 
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
            /*F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            F8();
            F9();
            F10();
            F11();
            F12();
            F13();
            F14();
            F15();
            F16();
            F17();
            F18();
            F19();
            F20();
            F21();
            F22();
            F23();
            F24();
            F25();
            F26();
            F27();
            F28();
            F29();
            F30();
            F31();
            F32();
            F33();
            F34();
            F35();
            F36();
            F37();
            F38();
            F39();
            F40();
            F41();
            F42();
            F43();
            F44();
            F45();
            F46();
            F47();
            F48();
            F49();
            F50();
            F51();
            F52();
            F53();
            F54();
            F55();
            F56();
            F57();
            F58();
            F59();
            F60();*/
            Rajzolas();

        }
        /*static void F1()
        {
            Console.WriteLine("Hello world!");
            Console.WriteLine();
        }

        static void F2()
        {
            Console.WriteLine("F1 Köszönés:");
            Console.Write("Mi a neved: ");
            string name = Console.ReadLine()!;
            Console.WriteLine($"Szia {name}!");
            Console.WriteLine();

        }

        static double BeDouble(string ask)
        {
            Console.Write(ask);
            double? num = null;
            do
            {
                try
                {
                    num = double.Parse(Console.ReadLine()!);

                }
                catch (FormatException)
                {
                    Console.Write("Nem megfelelő formátum, add meg újra: ");

                }
                catch (OverflowException)
                {
                    Console.Write($"A megadot számnak {double.MinValue} és {double.MaxValue} között kell lennie, add meg újra: ");
                }
            }
            while (num == null);
            return num.Value;

        }

        static int BeInt(string ask)
        {
            Console.Write(ask);
            int? num = null;
            do
            {
                try
                {
                    num = int.Parse(Console.ReadLine()!);

                }
                catch (FormatException)
                {
                    Console.Write("Nem megfelelő formátum, add meg újra: ");

                }
                catch (OverflowException)
                {
                    Console.Write($"A megadot számnak {int.MinValue} és {int.MaxValue} között kell lennie, add meg újra: ");
                }
            }
            while (num == null);

            return num.Value;
        }

        static void F3()
        {
            Console.WriteLine("F2 Egy szám duplázása: ");
            double num = BeDouble("Adj meg egy számot: ");

            Console.WriteLine($"Ennek a kétszerese: {num * 2}");
            Console.WriteLine();
        }

        static void F4()
        {
            Console.WriteLine("F3 Két szám öszsege, különbsége, szorzata és hányadosa: ");
            double num1 = BeDouble("Add meg az első számot: ");
            double num2 = BeDouble("Add meg a második számot: ");

            Console.WriteLine($"Az összegük: {num1 + num2}");
            Console.WriteLine($"A különbségük: {num1 - num2}");
            Console.WriteLine($"A szorzatok: {num1 * num2}");

            if (num2 != 0)
            {
                Console.WriteLine($"A hányadosuk: {num1 / num2}");
            }

            Console.WriteLine();
        }

        static void F5()
        {
            Console.WriteLine("F4 Két szám közül melyik a nagyobbb: ");
            int num1 = BeInt("Adj meg egy számot: ");
            int num2 = BeInt("Adj meg még egy számot: ");

            if (num1 > num2)
            {
                Console.WriteLine("Az első száma nagyobb.");
            }
            else if (num1 < num2)
            {
                Console.WriteLine("A második szám a nagyobb.");
            }
            else
            {
                Console.WriteLine("Ugyan akkora a két szám.");
            }

            Console.WriteLine();
        }

        static void F6()
        {
            Console.WriteLine("F5 Hároms szám közül a legikissebb: ");
            int[] nums = { BeInt("Adj meg egy számot: "), BeInt("Adj meg még egy számot: "), BeInt("Adj meg egy harmadik számot: ") };

            Console.WriteLine($"A leg kisebb szám: {nums.Min()}");

            Console.WriteLine();
        }

        static void F7()
        {
            Console.WriteLine("F6 A három megadott oldalhosszból rajzolható-e háromszög: ");
            int[] sides = { BeInt("Add meg az első oldal hoszát: "), BeInt("Add meg a második oldal hosszát: "), BeInt("Add meg a harmadik oldal hosszát is: ") };
            bool possible = false;

            if (sides[0] + sides[1] > sides[2] && sides[1] + sides[2] > sides[0] && sides[2] + sides[0] > sides[1])
            {
                possible = true;
            }

            if (possible)
            {
                Console.WriteLine("Szerkeszthető a háromszög");
            }
            else
            {
                Console.WriteLine("Nem szerkeszthető a háromszög");
            }

            Console.WriteLine();
        }

        static void F8()
        {
            Console.WriteLine("F7 Megadja két szám számtani és mértani közepét: ");
            int[] nums = { BeInt("Adj meg egy számot: "), BeInt("Adj meg még egy számot: ") };
            int num = nums[0] * nums[1];

            Console.WriteLine($"Számtani közepük: {(nums[0] + nums[1]) / 2}");

            if (num > -1)
            {
                Console.WriteLine($"Mértani közepük: {Math.Sqrt(num)}");
            }
            else
            {
                Console.WriteLine("Gyök alatt nem lehet negatív");
            }

            Console.WriteLine();
        }

        static void F9()
        {
            Console.WriteLine("F8 Megmondja, hogy egy másodfokú egyenlet három tagjából meg lehet-e oldani az egyenletett.");
            int[] nums = { BeInt("Add meg az első tagot: "), BeInt("Add meg a második tagot: "), BeInt("Add meg a hatmadik tagot is: ") };
            int num = nums[1] * nums[1] * -4 * nums[0] * nums[2];
            bool possible = false;

            if (nums[0] != 0 && num > 0)
            {
                possible = true;
            }

            if (possible)
            {
                Console.WriteLine("Megoldható");
            }
            else
            {
                Console.WriteLine("Nem megoldható a racionális számok halmazán");
            }

            Console.WriteLine();
        }

        static void F10()
        {
            Console.WriteLine("F9 Megoldja a másodfokú egyenletet.");
            int[] nums = { BeInt("Add meg az első tagot: "), BeInt("Add meg a második tagot: "), BeInt("Add meg a harmadik tagot is: ") };
            int num = nums[1] * nums[1] * -4 * nums[0] * nums[2];
            bool possible = false;

            if (nums[0] != 0 && num > 0)
            {
                possible = true;
            }

            if (possible)
            {
                Console.WriteLine($"Első megoldás: {(-nums[1] + Math.Sqrt(num)) / 2 * nums[0]}");
                Console.WriteLine($"Második megoldás: {(-nums[1] - Math.Sqrt(num)) / 2 * nums[0]}");
            }
            else
            {
                Console.WriteLine("Nem megoldható a racionális számok halmazán");
            }

            Console.WriteLine();
        }

        static void F11()
        {
            Console.WriteLine("F10 A két befogóból kiszámolja az átfogót egy derékszögű háromszögben.");
            double[] nums = { BeDouble("Add meg az első befogó hosszát: "), BeDouble("Add meg a második befogó hosszát: ") };
            while (nums[0] < 0 && nums[1] < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                nums[0] = BeDouble("Add meg az első befogó hosszát: ");
                nums[1] = BeDouble("Add meg a második befogó hosszát: ");
            }
            Console.WriteLine($"Az átfogó hossza: {Math.Round(Math.Sqrt(Math.Pow(nums[0], 2) + Math.Pow(nums[1], 2)), 2)}");
            Console.WriteLine();
        }

        static void F12()
        {
            Console.WriteLine("F11 Kiszámolja a téglatest felszínét és térfogatát a három oldalból.");
            double[] sides = { BeDouble("Add meg az első oldal hoszát: "), BeDouble("Add meg a második oldal hoszát: "), BeDouble("Add meg a harmadik oldal hoszát is: ") };
            while (sides[0] < 0 && sides[1] < 0 && sides[2] < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                sides[0] = BeDouble("Add meg az első oldal hoszát: ");
                sides[1] = BeDouble("Add meg a második oldal hoszát: ");
                sides[1] = BeDouble("Add meg a harmadik oldal hoszát is: ");
            }
            Console.WriteLine($"A téglatest felszíne: {2 * (sides[1] * sides[0] + sides[1] * sides[2] + sides[1] * sides[2])}");
            Console.WriteLine($"A téglatest térfogata: {sides[1] * sides[0] * sides[2]}");
            Console.WriteLine();
        }

        static void F13()
        {
            Console.WriteLine("F12 Kiszámolja a kör átmárőjéből a kör területét és kerületét.");
            double d = BeDouble("Add meg a kör átmérőjét: ");
            while (d < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra. ");
                d = BeDouble("Add meg a kör átmérőjét: ");
            }
            Console.WriteLine($"A kör kerülete: {d * Math.PI}");
            Console.WriteLine($"A kör területe: {Math.Pow(d / 2, 2) * Math.PI}");
            Console.WriteLine();
        }

        static void F14()
        {
            Console.WriteLine("F13 Kiszámolja a körcikk sugarából és a központi sögéből a területét és a határoló ív hosszát.");
            double r = BeDouble("Add meg a körcikk sugarát: ");
            double a = BeDouble("Add meg a központi szöget: ");
            while (a < 0 && r < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra. ");
                a = BeDouble("Add meg a körcikk sugarát: ");
                r = BeDouble("Add meg a központi szöget: ");
            }
            Console.WriteLine($"A körcik területe: {(a / 360) * Math.Pow(r, 2) * Math.PI}");
            Console.WriteLine($"A körív hossza: {r * a}");
            Console.WriteLine();
        }
        //Ha hiányzik a hosszú i vagy rövid van a helyén az azért van mert nincs a billenttyűzetemen.
        static void F15()
        {
            Console.WriteLine("F14 A bekért egész számig kiírja az összes számot addig.");
            int num = BeInt("Adj meg egy számot: ");
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj emg egy számot: ");
            }
            for (int i = 0; i < num - 1; i++)
            {
                Console.Write($"{i} ");
            }
            Console.Write($"{num - 1}");
            Console.WriteLine();
        }

        static void F16()
        {
            Console.WriteLine("F15 A bekért egész számig kiírja az összes számot addig.");
            int num = BeInt("Adj meg egy számot: ");
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj meg egy számot: ");
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"{i} ");
            }
            Console.WriteLine();
        }

        static void F17()
        {
            Console.WriteLine("F16 A bekért egész számig kiírja az osztóit");
            int num = BeInt("Adj meg egy számot: ");
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj meg egy számot: ");
            }
            for (int i = 1; i < num + 1 / 2; i++)
            {
                if (num % i == 0)
                {
                    Console.WriteLine($"{i} ");
                }

            }
            Console.WriteLine(num);
            Console.WriteLine();
        }
        static void F18()
        {
            Console.WriteLine("F17 A bekért egész számig kiírja az osztóinak az összegét");
            int num = BeInt("Adj meg egy számot: ");
            long ossz = 0;
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj meg egy számot: ");
            }
            for (int i = 1; i < num + 1 / 2; i++)
            {
                if (num % i == 0)
                {
                    ossz += i;
                }

            }
            Console.WriteLine(ossz + num);
            Console.WriteLine();
        }
        static void F19()
        {
            Console.WriteLine("F18 A bekér egy egész számot és megállapítja róla, hogy tökéletes-e.");
            int num = BeInt("Adj meg egy számot: ");
            long ossz = 0;
            bool perfect = false;
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj meg egy számot: ");
            }
            for (int i = 1; i < num + 1 / 2; i++)
            {
                if (num % i == 0)
                {
                    ossz += i;
                }

            }

            ossz += num;

            if (num * 2 == ossz)
            {
                perfect = true;
            }

            if (perfect)
            {
                Console.WriteLine("A szám tökéletes");
            }
            else
            {
                Console.WriteLine("A szám tökéletlen");
            }

            Console.WriteLine();
        }

        static bool Perfect(int num)
        {
            long ossz = 0;
            bool perfect = false;
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj meg egy számot: ");
            }
            for (int i = 1; i < num + 1 / 2; i++)
            {
                if (num % i == 0)
                {
                    ossz += i;
                }

            }

            ossz += num;

            if (num * 2 == ossz)
            {
                perfect = true;
            }

            return perfect;
        }

        static void F20()
        {
            Console.WriteLine("F19 Bekér egy hatványalapot és egy hatványkitevőt, aztán kiírja az eredményt: ");
            double num = BeDouble("Add meg a hatványalapot: ");
            double pow = BeDouble("Add emg a hatványkitevőt: ");
            Console.WriteLine($"Az eredmény: {Math.Pow(num, pow)}");
            Console.WriteLine();
        }

        static void F21()
        {
            Console.WriteLine("F20 Csak akkor veszi be ha pozitív");
            bool sucsess = false;
            double num;
            do
            {
                num = BeDouble("Adj meg egy számot");
                if (num > 0)
                {
                    sucsess = true;
                }
                else
                {
                    Console.WriteLine("A számnak pozitívnak kell lennie!");
                }
            } while (!sucsess);
            Console.WriteLine(num);
            Console.WriteLine();
        }
        static void F22()
        {
            Console.WriteLine("F21 Összeadja a számokat addid amíg tíznél kissebbek: ");
            double num = BeDouble("Adj emg egy számot: "); ;
            double sum = 0;
            while (num < 10)
            {
                sum += num;
                num = BeDouble("Adj emg egy számot: ");
            }
            Console.WriteLine($"A számok öszege: {sum}");
            Console.WriteLine();
        }

        static void F23()
        {
            Console.WriteLine("F22 Beolvas egy egész számot, majd elosztja 2-vel annyiszor,\r\nahányszor lehet és közben felírja a számot a kettes számok szorzataként\r\nmegszorozva egy olyan számmal, amely már nem osztható 2-vel.");
            int num = BeInt("Adj meg egy számot: ");
            int buffer = num;
            int count = 0;
            while (num % 2 == 0)
            {
                count++;
                num = num / 2;
            }

            //Console.WriteLine($"{buffer} = " + "2 * " * count + $"{num}");
            Console.WriteLine();
        }

        static void F24()
        {
            Console.WriteLine("F23 Bekér egy szót és csak akkor fogadja el ha az a szó alma");
            string text = "";
            do
            {
                Console.Write("Írd be, hogy alma : ");
                text = Console.ReadLine()!;
            } while (text != "alma");
            Console.WriteLine("Az alma gyümölcs");
            Console.WriteLine();
        }

        static void F25()
        {
            Console.WriteLine("F24 Bekér egy egész számot és kiirja azt három szorzataként");
            int num = BeInt("Adj meg egy egész számot: ");
            int buffer = num;
            int buffer2 = 0;
            int count = 0;
            while (num % 3 == 0)
            {
                count++;
                num = num / 3;
            }

            buffer2 = num % 3;

            Console.WriteLine($"{buffer} = " + $"{count} * 3" + $"+ {buffer2}");
            Console.WriteLine();
        }

        static bool F26(double num)
        {
            double sqrt = Math.Round(Math.Sqrt(num));
            bool prime = true;
            for (int i = 2; i <= sqrt; i++)
            {
                if (num % i == 0)
                {
                    prime = false;
                }
            }

            if (prime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void F27()
        {
            Console.WriteLine("F25 Bekér egy számot és kiirja odáig a prim számokat");
            int num = BeInt("Adj meg egy számot: ");
            for (int i = 0; i <= Math.Sqrt(num); i++)
            {
                if (F26(i))
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }

        static void F28PrimOszt()
        {
            Console.WriteLine("F26 Bekér egy számot és kiirja a prim osztóit");
            int num = BeInt("Adj meg egy számot: ");
            for (int i = 0; i <= Math.Sqrt(num); i++)
            {
                if (F26(i) && num % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }

        static void F29()
        {
            Console.WriteLine("F27 Bekér egy számot kiirja a primtényezős felbontását");
            double num = BeDouble("Adj meg egy számot: ");
            for (int i = 2; i <= num; i++)
            {
                if (F26(i) && num % i == 0.0)
                {
                    num = num / i;
                    Console.Write($"{i}*");
                    i = 2;
                }
            }
            Console.WriteLine(num);
            Console.WriteLine();
        }

        static void F30()
        {
            Console.WriteLine("F28 Bekér két számot és kiírja a legnagyobb közös osztóját");
            double num1 = BeDouble("Adj meg egy számot: ");
            double num2 = BeDouble("Adj emg egy másik számot: ");
            double buffer = 0;
            if (num1 < num2)
            {
                for (double i = 1; i <= num1; i++)
                {
                    if (num1 % i == 0 && num2 % i == 0)
                    {
                        buffer = i;
                    }
                }
                Console.WriteLine($"AZ LNKO {buffer}");
            }
            else if (num2 < num1)
            {
                for (double i = 1; i <= num2; i++)
                {
                    if (num1 % i == 0 && num2 % i == 0)
                    {
                        buffer = i;
                    }
                }
                Console.WriteLine($"Az LNKO {buffer}");
            }
            else
            {
                Console.WriteLine($"Az LNKO: {num1}");
            }

        }

        static double LNKO(double num1, double num2)
        {
            double buffer = 0;
            if (num1 < num2)
            {
                for (double i = 1; i <= num1; i++)
                {
                    if (num1 % i == 0 && num2 % i == 0)
                    {
                        buffer = i;
                    }
                }
                return buffer;
            }
            else if (num2 < num1)
            {
                for (double i = 1; i <= num2; i++)
                {
                    if (num1 % i == 0 && num2 % i == 0)
                    {
                        buffer = i;
                    }
                }
                return buffer;
            }
            else
            {
                return num1;
            }
        }

        static void F31()
        {
            Console.WriteLine("F29 Megmondja két szám legkissebb közös többszörösét");
            double num1 = BeDouble("Adj emg egy számot: ");
            double num2 = BeDouble("Adj emg még egy számot: ");
            if (num1 != 0 && num2 != 0)
            {
                Console.WriteLine($"A LKKT: {(Math.Abs(num1 * num2)) / LNKO(num1, num2)}");
            }
            else
            {
                Console.WriteLine($"Nyilván nulla");
            }
        }

        static void F32()
        {
            Console.WriteLine("F30 Bekér egy számot és kiírja a hozzá tartozó szorzótáblát");
            int num1 = BeInt("Adj emg egy számot: ");
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i <= 10; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine("    __________________________________________");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{num1 * i} |");
                for (int j = 1; j <= 10; j++)
                {

                    Console.Write($" {num1 * i * j}");
                }
                Console.WriteLine();
            }
        }

        static void F33()
        {
            Console.WriteLine("F31 Bekér egy számot és kiírja a hozzá tartozó összegtáblát");
            int num1 = BeInt("Adj emg egy számot: ");
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i <= num1; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine("   ___________________________________________");
            for (int i = 0; i <= num1; i++)
            {
                Console.Write($"{num1 + i} |");
                for (int j = 0; j <= num1; j++)
                {

                    Console.Write($" {num1 + (i + j)}");
                }
                Console.WriteLine();
            }
        }

        static void F34()
        {
            Console.WriteLine("F32 Bekér egy kétjegyű számpárt és megondja róla hogy speciális-e");

            int num1 = BeInt("Adj meg egy számot: ");
            int num2 = BeInt("Adj meg még egy számot: ");

            int rnum1 = int.Parse($"{num1 / 10}{num1 % 10}");
            int rnum2 = int.Parse($"{num2 / 10}{num2 % 10}");
            bool special = false;

            if (num1 * num2 == rnum1 * rnum2)
            {
                special = true;
            }

            if (special)
            {
                Console.WriteLine("A számpár speciális");
            }
            else
            {
                Console.WriteLine("A számpár nem speciális");
            }
        }

        static void F35()
        {
            Console.WriteLine("F33 Kiírja a kisbetűket sé mellé az ASCII kódját");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((int)('a' + i + j * 10) <= (int)'z')
                    {
                        Console.Write($"{(char)('a' + i + j * 10)} {(int)('a' + i + j * 10)} ");
                    }
                }
                Console.WriteLine();
            }
        }

        static char Simbolchange(char simbol)
        {
            if (simbol == 'X')
            {
                simbol = 'O';
            }
            else
            {
                simbol = 'X';
            }
            return simbol;
        }
        static void F36()
        {
            Console.WriteLine("F34 Bekéri a sorok és oszlopok számát és sormintát ír");
            int line = BeInt("Add meg az oszlopok számát: ");
            int coul = BeInt("Add meg a sorok számát: ");
            char simbol = 'X';
            for (int i = 1; i <= coul; i++)
            {
                if (i % 2 == 0)
                {
                    simbol = 'O';
                }
                else
                {
                    simbol = 'X';
                }
                for (int j = 1; j <= line; j++)
                {

                    Console.Write(simbol);
                    simbol = Simbolchange(simbol);
                }
                Console.WriteLine();
            }
        }

        static void F37()
        {
            Console.WriteLine("F35 Bekér egy számot és annyi csillagot ír ki fokozatosan sorokba");
            int num = BeInt("Adj meg egy számot: ");
            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void F38()
        {
            Console.WriteLine("F36 Bekér egy számot és egy akkora csillag háromszöget rajzol");
            int num = BeInt("Adj meg egy számot: ");

            for (int i = 1; i <= num; i++)
            {
                for (int k = 0; k < num - i; k++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                for (int k = 0; k < num - i; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();

            }
        }

        static void F39()
        {
            Console.WriteLine("F37 Bekér két természetes számot és egy akkora csillag négyzetet rejzol");
            int num1 = BeInt("Adj meg egy számot: ");
            int num2 = BeInt("Adj meg még egy számot: ");

            for (int i = 1; i <= num2; i++)
            {
                if (i == 1 || i == num2)
                {
                    for (int j = 1; j <= num1; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.Write("*");
                    for (int j = 1; j < num1 - 1; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        static void F40()
        {
            Console.WriteLine("F38 Bekér egy egész számot és kiírja addig a számig a tökéletes számokat");
            int num = BeInt("Adj meg egy számot: ");

            for (int i = 1; i <= num; i++)
            {
                if (Perfect(i))
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }

        static void F41()
        {
            Console.WriteLine("F39 Kiírja a Vigenère-táblát");
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    Console.Write((char)('A' + (i + j) % 26));
                }
                Console.WriteLine();
            }
        }

        static void F42()
        {
            Console.WriteLine("F40 Bekér pár számot és kiírja menny belőle a páratlan");
            int[] nums = BeIntArry();
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    count++;
                }
            }
            Console.WriteLine($"A páratlan számok száma: {count} darab");
            Console.WriteLine();
        }

        static void F43()
        {
            Console.WriteLine("F41 Bekér egy pár számot és aztán kiírja a párosok összegét");
            int[] nums = new int[BeInt("Bekért számok mennyisége: ")];
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = BeInt($"Add meg a {i + 1}. számot: ");
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    count += nums[i];
                }
            }
            Console.WriteLine($"A páros számok összege: {count}");
            Console.WriteLine();
        }

        static void F44()
        {
            Console.WriteLine("F42 Bekér számokat és aztán kiírja a párosakat sorszámmal együtt");
            int[] nums = BeIntArry();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    Console.WriteLine($"{i + 1}. szám páros: {nums[i]}");
                }
            }
        }

        static void F45()
        {
            Console.WriteLine("F43 Bekér egész számokat és aztán megkeres egy bizonyos számot");
            int[] nums = BeIntArry();

            int num = BeInt("Melyik számot keresed: ");

            if (nums.Contains(num))
            {

                Console.WriteLine($"A keresett szám a {Array.IndexOf(nums, num)}. helyen van");
            }
            else
            {
                Console.WriteLine("Nincs ilyen szám");
            }

            Console.WriteLine();
        }

        static void F46()
        {
            Console.WriteLine("F44 Bekér egész számokat és aztán meg mondja hogy egy bizonyos szából mennyi van");
            int[] nums = BeIntArry();
            int count = 0;

            int num = BeInt("Melyik számot keresed: ");

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == num)
                {
                    count++;
                }
            }

            Console.WriteLine($"A keresett számból {count} darab van");
            Console.WriteLine();
        }

        static string BeStr(string ask)
        {
            Console.Write(ask);
            string text = Console.ReadLine()!;
            return text;
        }
        static void F47()
        {
            Console.WriteLine("F45 Bekér kersztneveket és aztán megmondja hogy egy bizonyos keresztnevű emberből hány darab van");
            string[] names = new string[BeInt("Bekért nevek mennyisége: ")];
            int count = 0;

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = BeStr($"Add meg a {i + 1}. keresztnevet: ");
            }

            string name = BeStr("Melyik keresztnevet keresed: ");

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    count++;
                }
            }

            Console.WriteLine($"A keresett keresztnévből {count} darab van");
            Console.WriteLine();
        }

        static int[] BeIntArry()
        {
            int[] nums = new int[BeInt("Bekért számok mennyisége: ")];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = BeInt($"Add meg a {i + 1}. számot: ");
            }
            return nums;
        }
        static void F48()
        {
            Console.WriteLine("F46 Bekér számokat és aztán megadja a legnagyobb és a legkissebb szám különbséget");
            int[] nums = BeIntArry();

            Console.WriteLine($"A legnagyobb és elgkissebb szám különbsége: {nums.Max() - nums.Min()}");
            Console.WriteLine();
        }

        static void F49()
        {
            Console.WriteLine("F47 Buborékos rendezés");
            int[] nums = BeIntArry();
            int buffer = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        buffer = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = buffer;
                    }
                }
            }

            Console.WriteLine();
        }

        static void F50()
        {
            Console.WriteLine("F48 Bekér egy szót és kiírja a betűit elválasztva");
            string text = BeStr("Adj meg egy szót: ");

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"{text[i]} ");
            }
            Console.WriteLine();
        }

        static char BeChar(string ask)
        {
            Console.Write(ask);
            char? ch = null;

            do
            {
                try
                {
                    ch = char.Parse(Console.ReadLine()!);

                }
                catch (FormatException)
                {
                    Console.Write("Nem megfelelő formátum, add meg újra: ");

                }
                catch (OverflowException)
                {
                    Console.Write($"Csak egy karaktert adj meg, add meg újra: ");
                }
            }
            while (ch == null);

            return ch.Value;
        }
        static void F51()
        {
            Console.WriteLine("F49 Bekér egy szót és egy karaktert, kiírja a szót kihagyva azt a karaktert");
            string text = BeStr("Adj meg egy szót: ");
            char ch = BeChar("Adj meg egy karaktert: ");

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ch && text[i] != ch - 32)
                {
                    Console.Write($"{text[i]}");
                }
            }

            Console.WriteLine();
        }

        static void F52()
        {
            Console.WriteLine("F50 Bekér egy szót és kiírja minden második betűjét egymás alá");
            string text = BeStr("Adj meg egy szót: ");

            for (int i = 1; i < text.Length; i += 2)
            {
                Console.WriteLine($"{text[i]}");
            }

            Console.WriteLine();
        }

        static void F53()
        {
            Console.WriteLine("F51 Bekér egy szót és kiírja egymás alá a karaktereit és a kódját");
            string text = BeStr("Adj meg egy szót: ");

            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine($"{text[i]} {(int)text[i]}");
            }

            Console.WriteLine();
        }

        static void F54()
        {
            Console.WriteLine("F52 Bekér egy szót és kiírja visszafelé");
            string text = BeStr("Adj meg egy szót: ");

            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write($"{text[i]}");
            }
            Console.WriteLine();
        }

        static void F55()
        {
            Console.WriteLine("F53 Bekér egy mondatot és kiírja a szavait egymás alá");
            string text = BeStr("Adj meg egy mondatot: ");
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }

            Console.WriteLine();
        }

        static void F56()
        {
            Console.WriteLine("F54 Bekér egy szót és kiírja a betűit visszafelé nagybetűként");
            string text = BeStr("Adj meg egy szót: ");
            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write($"{char.ToUpper(text[i])}");
            }
        }

        static void F57()
        {
            Console.WriteLine("F55 Bekér egy mondatot és kiírja a szavait egymás alá nagy kezdőbetűvel");
            string text = BeStr("Adj meg egy mondatot: ");
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"{char.ToUpper(words[i][0])}{words[i].Substring(1).ToLower()}");
            }
        }
        static void F58()
        {
            Console.WriteLine("F56 Egy megadott forrásból kiírja a legnagyobb számot");
            FileStream file = new FileStream("forras1.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            int[] nums = new int[Convert.ToInt32(reader.ReadLine())];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Convert.ToInt32(reader.ReadLine());
            }

            int max = nums.Max();

            reader.Close();
            file.Close();

            Console.WriteLine($"A legnagyobb beolvasott szám: {max}");
            Console.WriteLine();
        }

        static void F59()
        {
            Console.WriteLine("F57 Egy megadott forrásból kiírja a legkissebb páros számot");
            FileStream file = new FileStream("forras2.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            int db = Convert.ToInt32(reader.ReadLine());
            int[] nums = new int[db];
            int num = 0;

            for (int i = 0; i < db; i++)
            {
                nums[i] = Convert.ToInt32(reader.ReadLine());
            }

            for (int i = 0; i < db; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    if (num == 0 || nums[i] < num)
                    {
                        num = nums[i];
                    }
                }
            }

            //Console.WriteLine($"A legkissebb páros szám: {}");
        }
        */
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
            Console.Write("─".PadRight(Console.WindowWidth - 2,'─'));
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

        static void Rajzolas()
        {
            char[] ch = ['░', '▒', '▓', '█', ' '];
            (int, int) pos = (0, 0);
            int intensity = 3;
            int color = 15;
            bool help = false;
            ((int, int), bool) square = ((0, 0), false);
            List<Point> points = new List<Point>();
            Status status = new Status();
            status.color = ConsoleColor.White;
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
                }
            }
        }
    }
}
