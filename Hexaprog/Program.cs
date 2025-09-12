using System.Net.Http.Headers;

namespace Hexaprog
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*F1Hello();
            F2Hi();
            F3Dupla();
            F4Szamolasok();
            F5Nagyobb();
            F6Kissebb();
            F7Haromszog();
            F8Kozep();
            F9Egyenlet();
            F10EgyenletMegoldas();
            F11Atfogo();
            F12Teglatest();
            F13KorKer();
            F14Korcikk();
            F15KiIras();
            F16Kiiras();
            F17OsztoKiiras();
            F18OsztoOssz();*/
            F19Perfect();
        }
        static void F1Hello()
        {
            Console.WriteLine("Hello world!");
            Console.WriteLine();
        }

        static void F2Hi()
        {
            Console.WriteLine("F1 Köszönés:");
            Console.Write("Mi a neved: ");
            string name = Console.ReadLine()!;
            Console.WriteLine($"Szia {name}");
            Console.WriteLine();

        }

        static double BeDouble()
        {
            Console.Write("Kérek egy számot: ");
            double? num = null;
            do
            {
                try
                {
                    num = double.Parse(Console.ReadLine()!);

                }
                catch (FormatException)
                {
                    Console.Write("Nem megfelelő formátum ad meg újra: ");

                }
                catch (OverflowException)
                {
                    Console.Write($"A megadot számnak {double.MinValue} és {double.MaxValue} között kell lennie, add meg újra: ");
                }
            }
            while (num == null);
            return num.Value;

        }

        static int BeInt()
        {
            Console.Write("Kérek egy számot: ");
            int? num = null;
            do
            {
                try
                {
                    num = int.Parse(Console.ReadLine()!);

                }
                catch (FormatException)
                {
                    Console.Write("Nem megfelelő formátum ad meg újra: ");

                }
                catch (OverflowException)
                {
                    Console.Write($"A megadot számnak {int.MinValue} és {int.MaxValue} között kell lennie, add meg újra: ");
                }
            }
            while (num == null);

            return num.Value;
        }

        static void F3Dupla()
        {
            Console.WriteLine("F2 Egy szám duplázása: ");
            double num = BeDouble();

            Console.WriteLine($"Ennek a kétszerese: {num * 2}");
            Console.WriteLine();
        }

        static void F4Szamolasok()
        {
            Console.WriteLine("F3 Két szám öszsege, különbsége, szorzata és hányadosa: ");
            double num1 = BeDouble();
            double num2 = BeDouble();

            Console.WriteLine($"Az összegük: {num1 + num2}");
            Console.WriteLine($"A különbségük: {num1 - num2}");
            Console.WriteLine($"A szorzatok: {num1 * num2}");

            if (num2 != 0)
            {
                Console.WriteLine($"A hányadosuk: {num1 / num2}");
            }

            Console.WriteLine();
        }

        static void F5Nagyobb()
        {
            Console.WriteLine("F4 Két szám közül melyik a nagyobbb: ");
            int num1 = BeInt();
            int num2 = BeInt();

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

        static void F6Kissebb()
        {
            Console.WriteLine("F5 Hároms szám közül a legikissebb: ");
            int[] nums = { BeInt(), BeInt(), BeInt() };

            Console.WriteLine($"A leg kisebb szám: {nums.Min()}");

            Console.WriteLine();
        }

        static void F7Haromszog()
        {
            Console.WriteLine("F6 A három megadott oldalhosszból rajzolható-e háromszög: ");
            int[] sides = { BeInt(), BeInt(), BeInt() };
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

        static void F8Kozep()
        {
            Console.WriteLine("F7 Megadja két szám számtani és mértani közepét: ");
            int[] nums = { BeInt(), BeInt() };
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

        static void F9Egyenlet()
        {
            Console.WriteLine("F8 Megmondja, hogy egy másodfokú egyenlet három tagjából meg lehet-e oldani az egyenletett.");
            int[] nums = { BeInt(), BeInt(), BeInt() };
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

        static void F10EgyenletMegoldas()
        {
            Console.WriteLine("F9 Megoldja a másodfokú egyenletet.");
            int[] nums = { BeInt(), BeInt(), BeInt() };
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

        static void F11Atfogo()
        {
            Console.WriteLine("F10 A két befogóból kiszámolja az átfogót egy derékszögű háromszögben");
            double[] nums = { BeDouble(), BeDouble() };
            while (nums[0] < 0 && nums[1] < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                nums[0] = BeDouble();
                nums[1] = BeDouble();
            }
            Console.WriteLine($"Az átfogó hossza: {Math.Round(Math.Sqrt(Math.Pow(nums[0], 2) + Math.Pow(nums[1], 2)), 2)}");
            Console.WriteLine();
        }

        static void F12Teglatest()
        {
            Console.WriteLine("F11 Téglatest felszíne és térfogata");
            double[] sides = { BeDouble(), BeDouble(), BeDouble() };
            while (sides[0] < 0 && sides[1] < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                sides[0] = BeDouble();
                sides[1] = BeDouble();
            }
            Console.WriteLine($"A téglatest felszíne: {2 * (sides[1] * sides[0] + sides[1] * sides[2] + sides[1] * sides[2])}");
            Console.WriteLine($"A téglatest térfogata: {sides[1] * sides[0] * sides[2]}");
        }

        static void F13KorKer()
        {
            Console.WriteLine("F12 Megadja a kör átmárőjét és megadja a kör területét és kerületét");
            double d = BeDouble();
            while (d < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                d = BeDouble();
            }
            Console.WriteLine($"A kör kerülete: {d * Math.PI}");
            Console.WriteLine($"A kör területe: {Math.Pow(d / 2, 2) * Math.PI}");
            Console.WriteLine();
        }
        
        static void F14Korcikk()
        {
            Console.WriteLine("F13 Kiszámolja a körcikk sugarából és a központi sögéből a területét és a határoló ív hosszát");
            double r = BeDouble();
            double a = BeDouble();
            while (a < 0 && r < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                a = BeDouble();
                r = BeDouble();
            }
            Console.WriteLine($"A körcik területe: {(a/360)*Math.Pow(r,2)*Math.PI}");
            Console.WriteLine($"A körív hossza: {r * a}");
        }

        static void F15KiIras()
        {
            Console.WriteLine("F14 A bekért egész számig kiírja az üsszes számot addig");
            int num = BeInt();
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                num = BeInt();
            }
            for (int i = 0; i < num - 1; i++)
            {
                Console.Write($"{i} ");
            }
            Console.Write($"{num- 1}");
            Console.WriteLine();
        }

        static void F16Kiiras()
        {
            Console.WriteLine("F15 A bekért egész számig kiírja az összes számot addig");
            int num = BeInt();
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                num = BeInt();
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"{i} ");
            }
            Console.WriteLine();
        }

        static void F17OsztoKiiras()
        {
            Console.WriteLine("F16 A bekért egész számig kiírja az osztóit");
            int num = BeInt();
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                num = BeInt();
            }
            for (int i = 1; i < num+1/2; i++)
            {
                if (num % i == 0)
                {
                    Console.WriteLine($"{i} ");
                }
                
            }
            Console.WriteLine(num);
            Console.WriteLine();
        }
        static void F18OsztoOssz()
        {
            Console.WriteLine("F17 A bekért egész számig kiírja az osztóinak az összegét");
            int num = BeInt();
            long ossz = 0;
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                num = BeInt();
            }
            for (int i = 1; i < num+1 / 2; i++)
            {
                if (num % i == 0)
                {
                    ossz += i;
                }

            }
            Console.WriteLine(ossz + num);
            Console.WriteLine();
        }
        static void F19Perfect()
        {
            Console.WriteLine("F18 A bekért egész számot és megállapítja róla, hogy tökéletes-e.");
            int num = BeInt();
            long ossz = 0;
            bool perfect = false;
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív hosszúságú, add meg újra: ");
                num = BeInt();
            }
            for (int i = 1; i < num + 1 / 2; i++)
            {
                if (num % i == 0)
                {
                    ossz += i;
                }

            }

            ossz += num;

            if (num*2 == ossz )
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

        static void F20Hatvany()
        {
            Console.WriteLine("F19");
        }
    }
}
