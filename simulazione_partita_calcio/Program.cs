namespace simulazione_partita_calcio
{
    internal class Program
    {
        static int[] GenVetSquadre(int N)
        {

            int[] sq = new int[N];

            for (int i = 0; i < sq.Length; i++)
            {
                Random gol = new Random();
                sq[i] = gol.Next(0, 101);
            }
             
            return sq;
        }

        static void StampaSquadra(int[] sq1, int[] sq2, int[] pan1, int[] pan2)
        {
            Console.Write("Squadra 1: ");

            for (int i = 0; i < sq1.Length; i++)
            {  
                Console.Write("[" + sq1[i] + "]");    
            }

            Console.WriteLine();

            Console.Write("Panchina 1: ");

            for (int i = 0; i < pan1.Length; i++)
            {
                Console.Write("[" + pan1[i] + "]");
            }

            Console.WriteLine();

            Console.Write("Squadra 2: ");

            for (int i = 0; i < sq2.Length; i++)
            {
                Console.Write("[" + sq2[i] + "]");              
            }

            Console.WriteLine();

            Console.Write("Panchina 2: ");

            for (int i = 0; i < pan2.Length; i++)
            {
                Console.Write("[" + pan2[i] + "]");
            }
        }

        static int PotenzaSqudra(int[] sq)
        {
            int pot=0;

            for(int i=0; i < sq.Length; i++)
            {
                pot = pot + sq[i];
            }

            return pot;
        }

        static void aumentoPotGol(int[] sq) 
        {

            for (int i = 0; i < sq.Length; i++)
            {
                if(sq[i] + 5 >= 100)
                {
                    sq[i] = 100;
                }
                else
                {
                    sq[i] = sq[i] + 5;
                }
            }
        }

        static void Main(string[] args)
        {
            int numSq;

            int[] squadra1 = GenVetSquadre(numSq = 11);
            int[] squadra2 = GenVetSquadre(numSq = 11);

            int[] panchina1 = GenVetSquadre(numSq = 5);
            int[] panchina2 = GenVetSquadre(numSq = 5);


            int potenzaSquadra1 = PotenzaSqudra(squadra1), potenzaSquadra2 = PotenzaSqudra(squadra2), sommaPot = potenzaSquadra1 + potenzaSquadra2, contaGolSq1 = 0, contaGolSq2 = 0;
            
            StampaSquadra(squadra1, squadra2, panchina1, panchina2);
            
            Console.WriteLine();

            for (int i = 0; i < 90; i++) {

                Random rnd = new Random();
                int gol = rnd.Next(0, 101);

                if (gol > 2)
                {
                    Console.WriteLine("Non c'è stato nessun gol");
                }
                else
                {
                    Random rnd2 = new Random();
                    int squadraGol = rnd.Next(0, sommaPot + 1);

                    Console.WriteLine();
                    Console.WriteLine("GOLLL");
                    if (squadraGol < potenzaSquadra1)
                    {
                        Console.WriteLine("HA SEGNATO LA SQUADRA 1");
                        contaGolSq1 = contaGolSq1 + 1;

                        Console.WriteLine();

                        aumentoPotGol(squadra1);

                        Console.WriteLine();

                        StampaSquadra(squadra1, squadra2, panchina1, panchina2);
                    }
                    else
                    {
                        Console.WriteLine("HA SEGNATO LA SQUADRA 2");
                        contaGolSq2 = contaGolSq2 + 1;

                        Console.WriteLine();

                        aumentoPotGol(squadra2);

                        Console.WriteLine();
                        
                        StampaSquadra(squadra1, squadra2, panchina1, panchina2);
                    }
                    Console.WriteLine();
                }
            
            }

            if (contaGolSq1 < contaGolSq2)
            {
                Console.WriteLine();
                Console.WriteLine("HA VINTO LA SQUDRA 2");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("HA VINTO LA SQUDRA 2");
                Console.WriteLine();
            }

        }
    }
}
