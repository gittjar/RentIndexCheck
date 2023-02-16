using System;
using Spectre.Console;

namespace MyIndex
{
	public class Indeksilaskuri
	{
    static public void Main(String[] args)
    {
        // metodin kutsu
        Indexlaskuri();     
    }
		static void Indexlaskuri()
		{

            Console.WriteLine("Indeksikorotuslaskuri v.1.0!");
            
            var rule1 = new Rule("[lightseagreen]Anna nykyinen vuokrasi, pelkkä vuokra ilman muita maksuja (erota centit pisteellä!): [/]");
            //rule1.Alignment = Justify.Left;
            AnsiConsole.Write(rule1);
            double CustomerRent;

            while (true)
            {
                while (!double.TryParse(Console.ReadLine(), out CustomerRent)) Console.WriteLine("Vain numerot kelpaavat!");
                {
                    if (CustomerRent < 0)
                    {
                        Console.WriteLine("Annoit negatiivisen lukeman, anna kelvollinen vuokra!");
                    }
                    else if (CustomerRent == 0)
                    {
                        Console.WriteLine("Annoit nollan, anna kelvollinen vuokra!");
                    }
                    else if (CustomerRent > 0)
                    {
                        Console.WriteLine("Vuokrasi on tällä hetkellä: " + CustomerRent + " Euroa.");
                        break;
                    }
                }
            }
            Console.WriteLine("");

            // NYKYINEN INDEKSI
            var rule2 = new Rule("[lightseagreen]Anna vuokran elinkustannusindeksin pisteluku (erota sadasosat pisteellä!): [/]");
            //rule2.Alignment = Justify.Left;
            AnsiConsole.Write(rule2);
            double VanhaIndeksi;
            // Console.WriteLine("Anna vuokran elinkustannusindeksin pisteluku (erota sadasosat pilkulla!): ");
            while (true)
            {
                while (!double.TryParse(Console.ReadLine(), out VanhaIndeksi)) Console.WriteLine("Vain numerot kelpaavat!");
                {
                    if (VanhaIndeksi < 0)
                    {
                        Console.WriteLine("Annoit negatiivisen lukeman, anna kelvollinen indeksi!");
                    }
                    else if (VanhaIndeksi == 0)
                    {
                        Console.WriteLine("Annoit nollan, anna kelvollinen indeksi!");
                    }
                    else if (VanhaIndeksi > 0)
                    {
                        Console.WriteLine("Nykyinen indeksi on tällä hetkellä: " + VanhaIndeksi);
                        break;
                    }
                }
            }

            // UUSI INDEKSI
            var rule3 = new Rule("[lightseagreen]Anna uusi elinkustannusindeksin pisteluku, johon edellistä elinkustannusindeksiä verrataan (erota sadasosat pisteellä!): [/]");
            //rule3.Alignment = Justify.Left;
            AnsiConsole.Write(rule3);
            double UusiIndeksi;
            // Console.WriteLine("Anna vuokran elinkustannusindeksin pisteluku (erota sadasosat pilkulla!): ");
            while (true)
            {
                while (!double.TryParse(Console.ReadLine(), out UusiIndeksi)) Console.WriteLine("Vain numerot kelpaavat!");
                {
                    if (UusiIndeksi < 0)
                    {
                        Console.WriteLine("Annoit negatiivisen lukeman, anna kelvollinen indeksi!");
                    }
                    else if (UusiIndeksi == 0)
                    {
                        Console.WriteLine("Annoit nollan, anna kelvollinen indeksi!");
                    }
                    else if (UusiIndeksi > 0)
                    {
                        Console.WriteLine("Nykyinen indeksi on tällä hetkellä: " + UusiIndeksi);
                        break;
                    }
                }
            }

            // LOPPUTULOS
            Console.WriteLine("Oletko valmis kuulemaan uuden vuokratasosi?");
            Console.WriteLine("Paina Enter!");
            Console.ReadLine();

            // Synchronous
            AnsiConsole.Status()
                .Start("Ladataan", ctx =>
                {
                    // Simulate some work
                    // AnsiConsole.MarkupLine("Doing some work...");
                    // Thread.Sleep(1000);

                    // Update the status and spinner
                    ctx.Status("Koostan lopputuloksen!");
                    ctx.Spinner(Spinner.Known.Star);
                    ctx.SpinnerStyle(Style.Parse("green"));
                    Thread.Sleep(3500);

                    // Simulate some work
                    // AnsiConsole.MarkupLine("Doing some more work...");
                    // Thread.Sleep(2000);
                });

            double Tulos = (UusiIndeksi / VanhaIndeksi) * CustomerRent;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Uusi vuokrasi on €/kuukaudessa: {0:F2}", Tulos);
            double MuutosPerKK = Tulos - CustomerRent;
            double VuodessaMore = MuutosPerKK * 12;
            double MuutosProsenttiTarkka = ((UusiIndeksi - VanhaIndeksi) / VanhaIndeksi) * 100 ;

            Double MuutosProsentti = Math.Round((Double)MuutosProsenttiTarkka, 2);
            Console.WriteLine("Vuokrasi kohosi noin: " + MuutosProsentti + " prosenttia.");

            Console.WriteLine("Muutos euroa per kuukausi: {0:F2}", MuutosPerKK);
            Console.WriteLine("Muutos euroa per vuosi: {0:F2}", VuodessaMore);
           
            // konvertoidaan kaaviota varten
            Double VanhaVuokra = Math.Round((Double)CustomerRent, 2);
            Double UusiVuokra = Math.Round((Double)Tulos, 2);

            AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label("[green bold underline]Vuokratasot[/]")
                .CenterLabel()
                .AddItem("Vanha vuokra", VanhaVuokra, Color.Yellow)
                .AddItem("Uusi vuokrasi", UusiVuokra, Color.Green));
               // .AddItem("Jotakin", 33, Color.Red));
        }
	}
}