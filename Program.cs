using System;
using System.IO;


namespace zad3
{
    class Program
    {


        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            string line;
            string name = "pla1a.in";
            StreamReader sr = new StreamReader(name);
            line = sr.ReadToEnd();
            Console.WriteLine(line);

            int ArrayLength;
            string Length = "";

            //ilosc domkow
            int k = 0;
            while (true)
            {
                if (Convert.ToInt32(line[k]) >= 48 && Convert.ToInt32(line[k]) <= 57)
                    Length += Convert.ToString(line[k]);
                else
                    break;
                k++;
            }

            ArrayLength = Convert.ToInt32(Length);
            Console.WriteLine(ArrayLength);

            //tworze tablice z domkami(szerokosc ich nie ma znaczenia wiec jest 1 wymiarowa)
            int[] tab = new int[ArrayLength];
            string StrNumberToAdd = "";
            int IntNumberToAdd;
            //zapelniam tablice
            int CountMyArray = 0;


            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == 32)//kesli jest spacja
                {
                    i++;
                    while (Convert.ToInt32(line[i]) >= 48 && Convert.ToInt32(line[i]) <= 57)
                    {
                        StrNumberToAdd += line[i];
                        i++;
                        if (i == line.Length)
                            break;
                    }
                    IntNumberToAdd = Convert.ToInt32(StrNumberToAdd);
                    tab[CountMyArray] = IntNumberToAdd;
                    StrNumberToAdd = "";
                    CountMyArray++;
                }
            }


            //WYPISZ
            Console.Write("\n\ntablica: ");

            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");


            //usuwam powtorzenia gdy obok sa
            for (int i = 0; i < ArrayLength - 1; i++)
            {
                if (tab[i] == tab[i + 1] && tab[i] != 0)
                {
                    //przesuwanko
                    for (int l = i; l < ArrayLength - 2; l++)
                        tab[l + 1] = tab[l + 2];
                    tab[ArrayLength - 1] = 0;
                    i--;
                }
            }
           

            //WYPISZ bez powtorzen
            Console.Write("\n\ntablica bez powt: ");

            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");


            int Posters = 0;


            //wybieram wieze i uuwam srodkowa // i usuwam takie same obok
            for (int i = 0; i < ArrayLength - 2; i++)
            {
                //jesli wieza
                if (tab[i + 1] > tab[i] && tab[i + 1] > tab[i + 2] && tab[i + 2] != 0)
                {
                    Posters++;
                    //przesuwanko
                    for (int j = i; j < ArrayLength - 2; j++)
                        tab[j + 1] = tab[j + 2];
                    tab[ArrayLength - 1] = 0;

                    if (i >= 2)
                        i -= 2;
                    else
                        i--;
                }

                //usuwam takie same obok
                for (int j = 0; j < ArrayLength - 2; j++)
                {
                    if (tab[j] == tab[j + 1] && tab[j] != 0)
                    {
                        //przesuwanko
                        for (int l = j; l < ArrayLength - 2; l++)
                            tab[l + 1] = tab[l + 2];
                        tab[ArrayLength - 1] = 0;
                        if (j >= 2)
                            j -= 2;
                        else
                            j--;
                    }
                }
            }


           
            //WYPISZ tablice
            Console.Write("\n\nbez max: ");

            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");



            //usuwam powtorzenia gdy obok
            for (int i = 0; i < ArrayLength - 1; i++)
            {
                if (tab[i] == tab[i + 1] && tab[i] != 0)
                {
                    //przesuwanko
                    for (int l = i; l < ArrayLength - 2; l++)
                    {
                        tab[l + 1] = tab[l + 2];
                    }
                    tab[ArrayLength - 1] = 0;
                    //tab[i] = 0;//zero bo nie ma wyzokosci 0
                    i--;
                }

            }
            //pozostale wolne liczby to niezalezne plakaty
            for (int i = 0; i < ArrayLength; i++)
            {
                if (tab[i] != 0)
                    Posters++;
            }




            //WYPISZ tablice
            Console.Write("\n\nbez powt: ");
            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");


            Console.WriteLine("\nLiczba Plakatow:"+Posters);

            DateTime Stop = DateTime.Now;
            TimeSpan myTime = (Stop - start);

            StreamWriter sw = new StreamWriter("pla.out");
            sw.WriteLine("Zadanie: "+name+"  Plakatow: "+ Posters + "\nCzas trwania programu: "+ myTime.TotalSeconds+"s");
            sw.Close();


            Console.WriteLine("Czas trwania programiu:" + (myTime));
            Console.ReadKey();
        }
    }
}
