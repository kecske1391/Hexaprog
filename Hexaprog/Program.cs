using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            F18OsztoOssz();
            F19Perfect();
            F20Hatvany();
            F21Pozitiv();*/
            F22Tizossze();
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

        static void F3Dupla()
        {
            Console.WriteLine("F2 Egy szám duplázása: ");
            double num = BeDouble("Adj meg egy számot: ");

            Console.WriteLine($"Ennek a kétszerese: {num * 2}");
            Console.WriteLine();
        }

        static void F4Szamolasok()
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

        static void F5Nagyobb()
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

        static void F6Kissebb()
        {
            Console.WriteLine("F5 Hároms szám közül a legikissebb: ");
            int[] nums = { BeInt("Adj meg egy számot: "), BeInt("Adj meg még egy számot: "), BeInt("Adj meg egy harmadik számot: ") };

            Console.WriteLine($"A leg kisebb szám: {nums.Min()}");

            Console.WriteLine();
        }

        static void F7Haromszog()
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

        static void F8Kozep()
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

        static void F9Egyenlet()
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

        static void F10EgyenletMegoldas()
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

        static void F11Atfogo()
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

        static void F12Teglatest()
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

        static void F13KorKer()
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
        
        static void F14Korcikk()
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
            Console.WriteLine($"A körcik területe: {(a/360)*Math.Pow(r,2)*Math.PI}");
            Console.WriteLine($"A körív hossza: {r * a}");
            Console.WriteLine();
        }

        static void F15KiIras()
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
            Console.Write($"{num- 1}");
            Console.WriteLine();
        }

        static void F16Kiiras()
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

        static void F17OsztoKiiras()
        {
            Console.WriteLine("F16 A bekért egész számig kiírja az osztóit");
            int num = BeInt("Adj meg egy számot: ");
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj meg egy számot: ");
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
            int num = BeInt("Adj meg egy számot: ");
            long ossz = 0;
            while (num < 0)
            {
                Console.WriteLine($"Nem lehet negatív, add meg újra: ");
                num = BeInt("Adj meg egy számot: ");
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
            Console.WriteLine("F19 Bekér egy hatványalapot és egy hatványkitevőt, aztán kiírja az eredményt: ");
            double num = BeDouble("Add meg a hatványalapot: ");
            double pow = BeDouble("Add emg a hatványkitevőt: ");
            Console.WriteLine($"Az eredmény: {Math.Pow(num,pow)}");
            Console.WriteLine();
        }

        static void F21Pozitiv()
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
        static void F22Tizossze()
        {
            Console.WriteLine("F21 Összeadja a számokat addid amíg tíznél kissebbek: ");
            double num  = BeDouble("Adj emg egy számot: "); ;
            double sum = 0;
            while (num < 10)
            {
                sum += num;
                num = BeDouble("Adj emg egy számot: ");
            }
            Console.WriteLine($"A számok öszege: {sum}");
            Console.WriteLine();
        }

        static void F23Osztas()
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
            if (count > 0)
            {
                
            }
        }
    }
}
