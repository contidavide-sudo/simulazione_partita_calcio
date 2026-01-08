namespace simulazione_partita_calcio
{
    internal class Program
    {
        static int[] GenVetSquadre()
        {

            int[] sq = new int[11];

            for (int i = 0; i < 11; i++)
            {
                Random gol = new Random();
                sq[i] = gol.Next(0, 101);
            }

            return sq;
        }

        static void StampaSquadra(int[] sq1, int[] sq2)
        {
            Console.Write("Squadra 1: ");

            for (int j = 0; j < sq1.Length; j++)
            {  
                Console.Write("[" + sq1[j] + "]");    
            }

            Console.WriteLine();

            Console.Write("Squadra 2: ");

            for (int j = 0; j < sq2.Length; j++)
            {
                Console.Write("[" + sq2[j] + "]");              
            }

            Console.WriteLine();
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

        static void Main(string[] args)
        {
            int[] squadra1 = GenVetSquadre();
            int[] squadra2 = GenVetSquadre();

            int potenzaSquadra1 = PotenzaSqudra(squadra1), potenzaSquadra2 = PotenzaSqudra(squadra2), sommaPot = potenzaSquadra1 + potenzaSquadra2, contaGolSq1 = 0, contaGolSq2 = 0;
            
            StampaSquadra(squadra1, squadra2);
            
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
                    }
                    else
                    {
                        Console.WriteLine("HA SEGNATO LA SQUADRA 2");
                        contaGolSq2 = contaGolSq2 + 1;
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
