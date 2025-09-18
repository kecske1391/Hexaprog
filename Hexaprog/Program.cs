using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hexaprog
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //F1Hello();
            //F2Hi();
            //F3Dupla();
            //F4Szamolasok();
            //F5Nagyobb();
            //F6Kissebb();
            //F7Haromszog();
            //F8Kozep();
            //F9Egyenlet();
            //F10EgyenletMegoldas();
            //F11Atfogo();
            //F12Teglatest();
            //F13KorKer();
            //F14Korcikk();
            //F15KiIras();
            //F16Kiiras();
            //F17OsztoKiiras();
            //F18OsztoOssz();
            //F19Perfect();
            //F20Hatvany();
            //F21Pozitiv();
            //F22Tizossze();
            //F23Osztas();
            //F24Alma();
            //F25HaromOsztas();
            //F26Prim();
            //F27PrimIras();
            //F28PrimOszt();
            //F29PrimFelsoztas();
            //F30LNKO();
            //F31LKKT();
            //F32Szorzotabla();
            //F33Osszegtabla();
            //F34Special();
            //F35ASCII();
            //F36XO();
            //F37Csillag();
            F38CsillagHaromszog();


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
            Console.WriteLine($"A körcik területe: {(a / 360) * Math.Pow(r, 2) * Math.PI}");
            Console.WriteLine($"A körív hossza: {r * a}");
            Console.WriteLine();
        }
        //Ha hiányzik a hosszú i vagy rövid van a helyén az azért van mert nincs a billenttyűzetemen.
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
            Console.Write($"{num - 1}");
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

        static void F20Hatvany()
        {
            Console.WriteLine("F19 Bekér egy hatványalapot és egy hatványkitevőt, aztán kiírja az eredményt: ");
            double num = BeDouble("Add meg a hatványalapot: ");
            double pow = BeDouble("Add emg a hatványkitevőt: ");
            Console.WriteLine($"Az eredmény: {Math.Pow(num, pow)}");
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

            //Console.WriteLine($"{buffer} = " + "2 * " * count + $"{num}");
            Console.WriteLine();
        }

        static void F24Alma()
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

        static void F25HaromOsztas()
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

        static bool F26Prim(double num)
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

        static void F27PrimIras()
        {
            Console.WriteLine("F25 Bekér egy számot és kiirja odáig a prim számokat");
            int num = BeInt("Adj meg egy számot: ");
            for (int i = 0; i <= Math.Sqrt(num); i++)
            {
                if (F26Prim(i))
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
                if (F26Prim(i) && num % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }

        static void F29PrimFelsoztas()
        {
            Console.WriteLine("F27 Bekér egy számot kiirja a primtényezős felbontását");
            double num = BeDouble("Adj meg egy számot: ");
            for (int i = 2; i <= num; i++)
            {
                if (F26Prim(i) && num % i == 0.0)
                {
                    num = num / i;
                    Console.Write($"{i}*");
                    i = 2;
                }
            }
            Console.WriteLine(num);
            Console.WriteLine();
        }

        static void F30LNKO()
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
            Console.WriteLine("F28 Bekér két számot és kiírja a legnagyobb közös osztóját");
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

        static void F31LKKT()
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

        static void F32Szorzotabla()
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

        static void F33Osszegtabla()
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

        static void F34Special()
        {
            Console.WriteLine("F32 Bekér egy kétjegyű számpárt és megondja róla hogy speciális-e");

            int num1 = BeInt("Adj meg egy számot: ");
            int num2 = BeInt("Adj emg még egy számot: ");

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

        static void F35ASCII()
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
        static void F36XO()
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

        static void F37Csillag()
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

        static void F38CsillagHaromszog()
        {
            Console.WriteLine("F36 Bekér egy számot és egy akkor csillag háromszöget rajzol");
            int num = BeInt("Adj meg egy számot: ");
            for (int i = 1; i <= num; i++)
            {
                for (int k = 0; k < num - i; k++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.WriteLine("*");
                }
                for (int k = 0; k < num - i; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();

            }
        }
    }
}
