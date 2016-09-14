using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Book_Try
{
    class Program
    {
        /*POSTAVA*/
        static string Jmeno = ""; //uloženo hráčovo jméno
        static List<string> inventar = new List<string>();

        /*POSTAVA: SKYLLI*/
        static string Class = ""; // clasa hráče (hráče)
        static int Heal = 10; // životy (hráče)
        static int Mana = 10; // mana (hráče)
        static int Lvl = 1; // level (hráče)

        static int l_utok = 5; // utok tipu 1 pro (hráče/nepžítele)
        static int t_utok = 10; // utok tipu 2 pro (hráče/nepžítele)

        /*PAMĚŤ*/
        static string moznosti = ""; //aktuálně dostupné možnosti v kroku.
        static string v_boji_s = ""; //název aktuálního nepřítele se kterým hráč bojuje.
        static int mistnost = 0;
        static int varianta = 0;
        static int zivoty_nepritele = 0;
        static int radky_v_hl_popise = 1;


        /*PAMĚŤ: STRINGI PRO ZOBRAZENÍ*/
        static string k_prohledani;
        static string k_najduti;
        static string k_pokracovani;
        static string k_rozhlednuti;
        static string k_rozhovoru;
        static string k_npc;

        /*PAMĚŤ: POVOLOVÁNÍ/ZAKAZOVÁNÍ MOŽNOSTÍ*/
        /*CIVILNÍ*/
        static bool prohledej;
        static bool rozhledni_se;
        static bool seber;
        static bool jit;

        /*BOJOVÉ*/
        static bool utok_1 = true;
        static bool utok_2 = true;
        static bool kryti = true;
        static bool dev = true;

        /*FUNKCE*/
        static bool While_MainTree = true;
        static bool While_Odpovedi = true;

        static void Main(string[] args)
        {
            Name();
            selectCustom();
            Start();
            Intro();

            while (While_MainTree)
            {
                Mistnost(mistnost, varianta);
                //Souboj();
            }
        }

        static void Name()
        {
            Console.Write("Jaké je tvé jméno ? ");
            Jmeno = Console.ReadLine().ToString();
        }

        static void Start()
        {
            Console.WriteLine("Jsi připraven vydat se na cestu tvého života ?");
            Console.WriteLine("Moznosti: Ano, Ne");
            Console.Write("Odpoveď: ");
            if (Console.ReadLine() == "Ne") Environment.Exit(0);
        }

        static void Intro()
        {
            Console.WriteLine("Jsi připraven vydat se na cestu tvého života ?");
            Console.WriteLine("Stiskni {Enter} ");
            Console.ReadKey();
        }

        static void Mistnost(int id, int vari = 0)
        {
            Console.Clear();
            if (id == 0)
            {
                if (vari == 0)
                {

                    /*Nastavení Místnosti*/
                    k_pokracovani = "Doleva, Doprava";
                    k_rozhlednuti = "Starojtarou mírně zarostlou stesku Doleva, Druhou směřující doprava." + Environment.NewLine + "U ůpatí cesty ležící Kámen";
                    k_prohledani = "";
                    k_najduti = "Kamen";
                    prohledej = false;
                    rozhledni_se = true;
                    seber = false;
                    jit = true;
                    radky_v_hl_popise = 2;
                    /*Konec nastavení místnosti)*/

                    Console.WriteLine("Popis Lokace: Nacházíš se v překrásném ůdolí.");
                    Console.WriteLine(Moznosti());
                }
            }
            else if (id == 1)
            {
                if (vari == 0)
                {

                    /*Nastavení Místnosti*/
                    k_pokracovani = "Doleva, Doprava, Zpátky";
                    k_rozhlednuti = "Cestu která se tu opět zozdvojuje jedna vede doleva druhá do prava. V dubu je dutina";
                    k_prohledani = "";
                    k_najduti = "";
                    prohledej = false;
                    rozhledni_se = true;
                    seber = false;
                    jit = false;
                    radky_v_hl_popise = 1;
                    /*Konec nastavení místnosti)*/

                    Souboj();
                    Console.WriteLine("Popis Lokace: Došel jsi k velkému statnému dubu rozstousímu na ůpatí strmého srázu.");
                    Console.WriteLine(Moznosti());
                }
            }
            else if (id == 2)
            {
                if (vari == 0) { }
            }
            else if (id == 3)
            {
                if (vari == 0) { }
            }
            Console.Write("Odpověď: ");
            Odpoved(Console.ReadLine());
        }

        static string Moznosti(bool V_Souboji = false)
        {
            if (V_Souboji)
            {
                string a = "Moznosti: ";
                if (utok_1) a = a + "Lehký ůtok, ";
                if (utok_2) a = a + "Těžký ůtok, ";
                if (kryti) a = a + "Krýt se, ";
                if (dev) a = a + "OP";
                moznosti = a;
                return a;
            }
            else
            {
                string a = "Moznosti: ";
                if (prohledej) a = a + "Prohledat, ";
                if (rozhledni_se) a = a + "Rozhlednout se, ";
                if (seber) a = a + "Sebrat, ";
                if (jit) a = a + "Jít, ";
                moznosti = a;
                return a;
            }
        }

        static void Odpoved(string a)
        {
            while (While_Odpovedi)
            {
                if (moznosti.Contains(a) && a != "")
                {
                    if (a.Contains("Prohledat"))
                    {
                        Prohledat();
                    }
                    if (a.Contains("Rozhlednout se"))
                    {
                        Rozhlednuti();
                    }
                    if (a.Contains("Sebrat"))
                    {
                        Sebrat();
                    }
                    if (a.Contains("Jít"))
                    {
                        Jit();
                    }
                    While_Odpovedi = false;
                }
                else if (a.Contains("/") && a != "")
                {
                    if (a.Contains("Exit"))
                    {
                        Environment.Exit(0);
                    }

                    if (a.Contains("Inventář"))
                    {
                        int i_z = 3;
                        if (inventar.Count() > 0)
                        {
                            Console.WriteLine("Inventář: ");
                            for (int i = 0; i < inventar.Count(); i++)
                            {
                                Console.WriteLine((i + 1).ToString() + ") " + inventar[i]);
                                i_z++;
                            }
                            Console.WriteLine("Stiskni {Enter} ");
                            Console.ReadKey();
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - i_z);
                            for (int i = 0; i < i_z; i++)
                            {
                                Console.Write(new string(' ', Console.WindowWidth));
                            }
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - i_z);
                            Console.Write("Odpověď: ");
                            Odpoved(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Inventář: ");
                            Console.WriteLine(" a nic v něm! ");
                            i_z++;
                            Console.WriteLine("Stiskni {Enter} ");
                            Console.ReadKey();
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - i_z);
                            for (int i = 0; i < i_z; i++)
                            {
                                Console.Write(new string(' ', Console.WindowWidth));
                            }
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - i_z);
                            Console.Write("Odpověď: ");
                            Odpoved(Console.ReadLine());
                        }
                    }
                    if (a.Contains("Pomoc"))
                    {
                        Console.WriteLine("Pomocné Příkazy: /Inventář - zobrazí inventář");
                        Console.WriteLine("                 /Pomoc - zobrazí sezanm (systémovýc) příkazů");
                        Console.WriteLine("                 /Exit - ukončí hru");
                        Console.ReadKey();
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 4);
                        for (int i = 0; i < 4; i++)
                        {
                            Console.Write(new string(' ', Console.WindowWidth));
                        }
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 4);
                        Console.Write("Odpověď: ");
                        Odpoved(Console.ReadLine());
                    }
                    While_Odpovedi = false;

                }
                else
                {
                    Console.WriteLine("Neplatná možnost! Stiskni {Enter}");
                    Console.ReadKey();
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                    Console.Write("Odpověď: ");
                    Odpoved(Console.ReadLine());
                }
            }
        }

        static void Prohledat()
        {
            //if (k_prohledani != "") Console.WriteLine("Prohledal jsi ? : " + k_prohledani);
            Console.WriteLine("Našel jsi: " + k_prohledani);
            if (k_najduti != "") seber = true;
            Console.WriteLine(Moznosti());
            Console.Write("Odpověď: ");
            Odpoved(Console.ReadLine());
        }

        static void Jit()
        {
            Console.WriteLine("Kam ? : " + k_pokracovani);
            Console.Write("Odpověď: ");
            string Operator = Console.ReadLine();
            if (Operator == "Doleva")
            {
                if (mistnost == 0)
                {
                    mistnost = 1;
                    varianta = 0;
                }
            }
        }

        static void Sebrat()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.WriteLine("Co ? : " + k_najduti);
            Console.Write("Odpověď: ");
            string a = Console.ReadLine();
            if (k_najduti.Contains(a)) inventar.Add(a);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
            Console.Write("Odpověď: ");
            Odpoved(Console.ReadLine());

        }

        static void Rozhlednuti()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (1 + radky_v_hl_popise));
            for (int i = 0; i < (1 + radky_v_hl_popise);i++ )
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (1 + radky_v_hl_popise));


            Console.WriteLine("Vidíš: " + k_rozhlednuti);
            if (k_najduti != "") seber = true;
            rozhledni_se = false;
            Console.WriteLine(Moznosti());
            Console.Write("Odpověď: ");
            Odpoved(Console.ReadLine());
        }

        static void Souboj()
        {
            Random nahoda = new Random();
            bool nepritel_exist = true;
            bool spravna_odpoved = true;
            bool boj = true;
            bool moje_kolo = true;
            string d_o = null;
            v_boji_s = "";
            int i_z = 0;
            int zivot = Heal;
            zivoty_nepritele = 0;
            

            int a = nahoda.Next(1, 4);
            if (a == 1)
            {
                Console.WriteLine("Uprostřed hvozdu na tebe zautočil zloděj.");
                v_boji_s = "Zloděj";
                zivoty_nepritele = 10;
            }
            else if (a == 2)
            {
                Console.WriteLine("Z poza stromu na tebe vyskořil Skřet a zautočil na tebe.");
                v_boji_s = "Skřet";
                zivoty_nepritele = 30;
            }
            else if (a == 3)
            {
                Console.WriteLine("Na cestě se najednou oběvil Přízrak.");
                v_boji_s = "Přízrak";
                zivoty_nepritele = 50;
            }

            while (boj)
            {
                if (spravna_odpoved != false)
                {
                    Console.WriteLine(Stats());
                }
                if (spravna_odpoved != false)
                {
                    if (zivoty_nepritele > 0 && Heal > 0)
                    {
                        Console.WriteLine(Moznosti(true));
                    }
                }
                if (zivoty_nepritele > 0 && Heal > 0)
                {
                    Console.Write("Odpověď: ");
                }
                if (zivoty_nepritele > 0 && Heal > 0)
                {
                    d_o = Console.ReadLine();
                }

                if (zivoty_nepritele <= 0) nepritel_exist = false;

                if (zivoty_nepritele > 0 && Heal > 0)
                {
                    if (moznosti.Contains(d_o) && d_o != "")
                    {
                        spravna_odpoved = true;
                        if (nepritel_exist)
                        {
                            if (moje_kolo)
                            {
                                if (d_o.Contains("Lehký ůtok"))
                                {
                                    if (nahoda.Next(1, 3) == 2)
                                    {
                                        zivoty_nepritele -= l_utok;
                                        Console.WriteLine("Tvůj útok byl uspěšný!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Netrefil Jsi se");
                                    }
                                }
                                if (d_o.Contains("Těžký ůtok"))
                                {
                                    if (nahoda.Next(1, 3) == 2)
                                    {
                                        zivoty_nepritele -= t_utok;
                                        Console.WriteLine("Tvůj utok dopadl na nepřítele se zdrcující přesností.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Netrefil Jsi se");
                                    }
                                }
                                if (d_o.Contains("Krýt se"))
                                {
                                    Console.WriteLine("Zaujal si krycí postoj.");
                                }
                                if (d_o.Contains("OP"))
                                {
                                    Console.WriteLine("Nepřítele srazilo Thorovo nebezké kladivo");
                                    zivoty_nepritele -= zivoty_nepritele;
                                }
                                moje_kolo = false;
                            }
                            if (!moje_kolo)
                            {
                                if (zivoty_nepritele > 0)
                                {
                                    if (d_o.Contains("Krýt se"))
                                    {
                                        Console.WriteLine("Nepřítelův ůtok byl zastaven tvím krytem.");
                                    }
                                    else
                                    {
                                        int x = nahoda.Next(1, 4);
                                        if (x == 2)
                                        {
                                            Heal -= l_utok;
                                            Console.WriteLine("Nepřítel provedl ůspěšný ůtok");
                                        }
                                        else if (x == 3)
                                        {
                                            Heal -= t_utok;
                                            Console.WriteLine("Nepřítel provedl zdrcující ůtok ůspěšný ůtok");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nepřítel se netrefil!");
                                        }
                                    }
                                }
                                moje_kolo = true;
                                i_z = 8;
                            }
                        }
                    }
                    else
                    {
                        Console.Write("Neplatná možnost! Stiskni {Enter}");
                        Console.ReadKey();
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        for (int i = 0; i < (1 + 1); i++)
                        {
                            Console.Write(new string(' ', Console.WindowWidth));
                        }
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                        spravna_odpoved = false;
                    }
                }
                else
                {
                    if (zivoty_nepritele <= 0)
                    {
                        Console.WriteLine("Nepřítel je mrtví");
                        Heal = zivot;
                    }

                    if (Heal <= 0)
                    {
                        Console.WriteLine("Zemřel jsi!");
                        Console.Write("Stiskni {Enter}");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    i_z = 5;
                    boj = false;
                }
                if (spravna_odpoved == true)
                {
                    Console.Write("Stiskni {Enter}");
                    Console.ReadKey();
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - i_z);
                    for (int i = 0; i < (i_z + 1); i++)
                    {
                        Console.WriteLine(new string(' ', Console.WindowWidth - 1));
                    }
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (i_z + 1));
                }
            }
        }

        static void Rozhovor()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
            Console.WriteLine("Vidíš: " + k_rozhlednuti);
            if (k_najduti != "") seber = true;
            rozhledni_se = false;
            Console.WriteLine(Moznosti());
            Console.Write("Odpověď: ");
            Odpoved(Console.ReadLine());
        }

        static string Stats()
        {
            string a = "║ " + "[" + Jmeno + "]" + " Životy: " + Heal + " Mana: " + Mana + " Lvl. " + Lvl;
            string b = "║ Životy nepřítele: " + zivoty_nepritele;
            int delka = 0;
            if (a.Length > b.Length) delka = a.Length;
            else if (a.Length < b.Length) delka = b.Length;

            if ((delka) == a.Length) a = a + " ║";
            else
            {
                int prepocet = delka - a.Length;
                for (int i = 0; i < prepocet; i++)
                {
                    a = a + " ";
                }
                a = a + " ║";
            }

            if ((delka) == b.Length) b = b + " ║";
            else
            {
                int prepocet = delka - b.Length;
                for (int i = 0; i < prepocet; i++)
                {
                    b = b + " ";
                }
                b = b + " ║";
            }

            a = "╔" + (new string('═', delka) + "╗" + Environment.NewLine) + a;
            b = b + Environment.NewLine + "╚" + (new string('═', delka) + "╝");

            return a + Environment.NewLine + b;
        }

        //static string item(bool pouzit_bitve = false)
        //{
        //}

        static void delete(int a)
        {
            Console.SetCursorPosition(0, Console.CursorTop - a);
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            if ((Console.CursorTop - a) <= 0) { a = a - 1; }
            Console.SetCursorPosition(0, Console.CursorTop - a - 1);
        }

        static void selectCustom()
        {
            back: Console.WriteLine("Vyber si své povolání ");
            string a = "Bojovník" + Environment.NewLine + "Lučišník" + Environment.NewLine + "Čaroděj" + Environment.NewLine + "Povolání: ";
            Console.Write(a);
            string b = Console.ReadLine();

            if (a.Contains(b)) 
            {
                Class = b;
                delete(5);
            }
            else 
            {
                Console.WriteLine("Neplatné Povolání!");
                Console.WriteLine("{Enter}");
                Console.ReadKey();
                delete(6);
                goto back;
            
            }
        }
    }
}