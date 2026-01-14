namespace simulazione_partita_calcio
{
    internal class Program
    {
        static int[] GenVetSquadre(int N) //Funzione per la generazione delle squadre
        {

            int[] sq = new int[N];

            for (int i = 0; i < sq.Length; i++)
            {
                Random gol = new Random();
                sq[i] = gol.Next(0, 101);
            }
             
            return sq;
        }

        static void StampaSquadra(int[] sq1, int[] sq2, int[] pan1, int[] pan2) //Funzione per la stampa delle squadre e delle panchine
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

        static int PotenzaSqudra(int[] sq) //Funzione per il calcolo della potenza totale delle squadre
        {
            int pot=0;

            for(int i=0; i < sq.Length; i++)
            {
                pot = pot + sq[i];
            }

            return pot;
        }

        static int[] aumentoPotGol(int[] sq) //Funzione per l'aumento della potenza totale della squdra che ha segnato 
        {

            for (int i = 0; i < sq.Length; i++)
            {
                if(sq[i] + 5 >= 100)
                {
                    sq[i] = 100;
                }
                else
                {
                    sq[i] = sq[i] + 2;
                }
            }

            return sq;
        }

        static void CartellinoGiallo(int[] sq, int[] vettoreG) //Funzione per la assegnazione dei cartellini gialli ai giocatori
        {
            Random rnd3 = new Random();
            int giocatoreGiallo = rnd3.Next(0, 11);

            vettoreG[giocatoreGiallo] = vettoreG[giocatoreGiallo] + 1;            

            if (vettoreG[giocatoreGiallo] < 2)
            {
                sq[giocatoreGiallo] = sq[giocatoreGiallo] - 3;

                PotenzaSqudra(sq);
            }
            else if (vettoreG[giocatoreGiallo] == 2) 
            {
                Console.WriteLine();

                Console.WriteLine("Un giocatore ha preso 2 cartellini gialli, qundi uno rosso ed è stato espulso(potenza=0)");//estensione di livello 1 "Ammonizioni accumulative"

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();

                Console.WriteLine("Il giocatore è gia stato espulso in precedenza");

                Console.WriteLine();
            }         
            
        }

        static int[] CartellinoRosso(int[] sq) //Funzione per l'assegnazione dei cartellini rossi ai giocatori
        {

            Random rnd5 = new Random();
            int giocatoreRosso = rnd5.Next(0, 11);

            sq[giocatoreRosso] = 0;

            PotenzaSqudra(sq);

            return sq;

        }

        static void Sostituzione(int[] sq, int[] panchina, int[] vettoreSos) //Funzione per la gestione delle sostituzioni
        {

            int panchinaMax = 0, titolareMin = 1000; //Estensione di livello 2 "panchina intelligente"

            for (int i = 0; i < sq.Length; i++)
            { 
            
                if(sq[i] < titolareMin)
                {
                    titolareMin = i;
                }
            
            }

            for (int i = 0; i < panchina.Length; i++)
            {
                if (panchina[i] > panchinaMax)
                {
                    panchinaMax = i;
                }
            }

            if (vettoreSos[panchinaMax] > 0)
            {
                Console.WriteLine();

                Console.WriteLine("Il giocatore non può essere sostituito");

                Console.WriteLine();
            }
            else
            {
                sq[titolareMin] = panchina[panchinaMax];
                panchina[panchinaMax]=sq[titolareMin];

                vettoreSos[panchinaMax] = vettoreSos[panchinaMax] +1;

                Console.WriteLine();

                Console.WriteLine("Viene sostituito il giocatore con potenza minore, il numero " + titolareMin);

                Console.WriteLine();
            }
        }

        static int[] Infortunio(int[] sq) //Funzione per la gestione degli infortuni
        {
            Random rnd10 = new Random();
            int giocatoreInf = rnd10.Next(0, 11);

            if(sq[giocatoreInf] - 20 >= 0)
            {
                sq[giocatoreInf] = sq[giocatoreInf] - 20;

                PotenzaSqudra(sq);
            }
            else
            {
                sq[giocatoreInf] = 0;

                PotenzaSqudra(sq);
            }

            return sq;
        }

        static int[] CaloFisico(int[] sq) //Funzione per la gestione dei cali fisici delle squadre
        {

            for (int i = 0; i < sq.Length; i++) 
            {

                sq[i] = sq[i] - 2;
            
            }

            return sq;

        }

        static void Rigore(int contaGol) //Funzione per la gestione dei rigori 
        {

            Random rnd13 = new Random();       //Estensione livello 3 "Rigori"
            int rigore = rnd13.Next(1, 101);

            if (rigore < 50)
            {
                contaGol = contaGol + 1;

                Console.WriteLine("Il rigore è stato segnato!!!");
            }
            else
            {
                Console.WriteLine("Il rigore non è stato segnato purtroppo!!!");
            }

            
        }

        
        static void Main(string[] args)
        {
            //Inizializzazioni delle variabili
            int numSq;

            int[] squadra1 = GenVetSquadre(numSq = 11);   //inizializzazione di tutti gli array utilizzati
            int[] squadra2 = GenVetSquadre(numSq = 11);

            int[] panchina1 = GenVetSquadre(numSq = 5);
            int[] panchina2 = GenVetSquadre(numSq = 5);

            int[] gialli1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] gialli2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int[] sostituzione1 = { 0, 0, 0, 0, 0 };
            int[] sostituzione2 = { 0, 0, 0, 0, 0 };


            int potenzaSquadra1 = PotenzaSqudra(squadra1), potenzaSquadra2 = PotenzaSqudra(squadra2), sommaPot = potenzaSquadra1 + potenzaSquadra2, contaGolSq1 = 0, contaGolSq2 = 0, contaGialli1 = 0, contaGialli2 = 0, contaSos1 = 0, contaSos2 = 0, contaRossi1 = 0, contaRossi2 = 0; ;
            
            StampaSquadra(squadra1, squadra2, panchina1, panchina2);
            
            Console.WriteLine();

            for (int i = 0; i <= 90; i++) {  //Ciclo per lo scorrere dei minuti della partita

                Console.WriteLine();
 
                Console.WriteLine("Minuto " +  i);

                //Controllo dell'estrazione randomica per la scelta degli eventi che possono accadere

                Random rnd = new Random();
                int gol = rnd.Next(1, 101);

                if (gol > 2 && gol <=7)  //Cartelllini gialli
                {
                    Console.Write("E' stato dato un cartellino giallo alla ");

                    Random rnd2 = new Random();
                    int squadraGiallo = rnd2.Next(1, 101);

                    if(squadraGiallo < 50)
                    {
                        contaGialli1 = contaGialli1 + 1;

                        Console.WriteLine("squadra 1, il giocatore  che ha commesso fallo verra depotenziato");

                        CartellinoGiallo(squadra1, gialli1);
                        
                    }
                    else
                    {
                        contaGialli2 = contaGialli2 + 1;

                        Console.WriteLine("squadra 2, il giocatore che ha commesso fallo verra depotenziato");

                        CartellinoGiallo(squadra2, gialli2);

                    }

                }
                else if(gol>7 && gol <= 9)//Cartellini rossi
                {
                    Console.Write("E' stato dato un cartellino rosso alla ");

                    Random rnd4 = new Random();
                    int squadraRosso = rnd4.Next(1, 101);

                    if (squadraRosso < 50)
                    {
                        contaRossi1= contaRossi1 + 1;

                        Console.WriteLine("squadra 1, il giocatore  che ha avuto un cartellino rosso verra espulso(potenza=0)");

                        CartellinoRosso(squadra1);
                        
                    }
                    else
                    {
                        contaRossi2 = contaRossi2 + 1;

                        Console.WriteLine("squadra 2, il giocatore che ha avuto un cartellino rosso verra espulso(potenza=0)");

                        CartellinoRosso(squadra2);

                    }
                }
                else if(gol<=2)//Gol di una squdra 
                {
                    Random rnd6 = new Random();
                    int squadraGol = rnd6.Next(1, sommaPot + 1);

                    Console.WriteLine();
                    Console.WriteLine("GOLLL");
                    if (squadraGol < potenzaSquadra1)
                    {
                        Console.WriteLine("HA SEGNATO LA SQUADRA 1");
                        contaGolSq1 = contaGolSq1 + 1;

                        Console.WriteLine();

                        aumentoPotGol(squadra1);
                        PotenzaSqudra(squadra1);

                        Console.WriteLine();

                        StampaSquadra(squadra1, squadra2, panchina1, panchina2);

                        Console.WriteLine(); 
                    }
                    else
                    {
                        Console.WriteLine("HA SEGNATO LA SQUADRA 2");
                        contaGolSq2 = contaGolSq2 + 1;

                        Console.WriteLine();

                        aumentoPotGol(squadra2);
                        PotenzaSqudra(squadra2);

                        Console.WriteLine();
                        
                        StampaSquadra(squadra1, squadra2, panchina1, panchina2);

                        Console.WriteLine();
                    }
                    
                }
                else if(gol>9 && gol <= 14)//Sostituzioni
                {
                    Random rnd7 = new Random();
                    int sos = rnd7.Next(1, 101);

                    if (sos < 50)
                    {
                        if (contaSos1 <= 5)
                        {
                            Console.WriteLine();

                            Console.WriteLine("La squadra 1 effettua una sostituzione");

                            Console.WriteLine();

                            Sostituzione(squadra1, panchina1, sostituzione1);
                        }
                        else
                        {
                            Console.WriteLine() ;

                            Console.WriteLine("La squadra 1 tenta di sostituire un giocatore ma non puo, ha finito le sostiruzioni") ;

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        if (contaSos2 <= 5)
                        {
                            Console.WriteLine();

                            Console.WriteLine("La squadra 2 effettua una sostituzione");

                            Console.WriteLine();

                            Sostituzione(squadra2, panchina2, sostituzione2);
                        }
                        else
                        {
                            Console.WriteLine();

                            Console.WriteLine("La squadra 2 tenta di sostituire un giocatore ma non puo, ha finito le sostiruzioni");

                            Console.WriteLine();
                        }
                    }

                }
                else if(gol>14 && gol <= 16)//Infortuni e depotenziamento causati da essi
                {

                    Random rnd9 = new Random();
                    int squadraInf = rnd9.Next(1, 101);

                    if (squadraInf < 50) 
                    {
                        Console.WriteLine();

                        Console.WriteLine("Un giocatore della squadra 1 si è infortunato e verra depotenziato di 20");

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("Un giocatore della squadra 2 si è infortunato e verra depotenziato di 20");

                        Console.WriteLine();
                    }

                }
                else if(gol>16 && gol <= 21)//Cali fisici della squadra
                {
                    if (i >= 60)
                    {
                        Random rnd11 = new Random();
                        int squadraCalo = rnd11.Next(1, 101);

                        if (squadraCalo < 50)
                        { 
                            Console.WriteLine();

                            Console.WriteLine("La squadra 1 ha avuto un calo fisico dovuto alla stancheza, vengono depotenziati lievemente tutti i giocatori");

                            Console.WriteLine();

                            CaloFisico(squadra1);
                        }
                        else
                        {
                            Console.WriteLine();

                            Console.WriteLine("La squadra 2 ha avuto un calo fisico dovuto alla stancheza, vengono depotenziati lievemente tutti i giocatori");

                            Console.WriteLine();

                            CaloFisico(squadra2);
                        }

                    }
                    else if(gol > 21 && gol <= 23)//Rigori (estensione livello 3)
                    {
                        Random rnd12 = new Random();
                        int squadraRig = rnd12.Next(1, 101);

                        if(squadraRig < 50)
                        {
                            Console.WriteLine("La squadra 1 deve battere un rigore");

                            Rigore(contaGolSq1);
                        }
                        else
                        {
                            Console.WriteLine("La squadra 2 deve battere un rigore");

                            Rigore(contaGolSq2);
                        }
                    }
                    else//Non succede nulla nel minuto di partita
                    {
                        Console.WriteLine("Non è successo nulla");
                    }
                }
                else
                {
                    Console.WriteLine("Non è successo nulla");
                }
            
            }

            //Risultati finali con statistiche finali

            if (contaGolSq1 < contaGolSq2)
            {
                Console.WriteLine();
                Console.WriteLine("HA VINTO LA SQUDRA 2");
                Console.WriteLine();

                Console.WriteLine("Gol squdra 1: " + contaGolSq1);
                Console.WriteLine("Gol squdra 2: " + contaGolSq2);
                Console.WriteLine("cartellini gialli squdra 1: " + contaGialli1);
                Console.WriteLine("cartellini gialli squdra 2: " + contaGialli2);
                Console.WriteLine("cartellini Rossi squdra 1: " + contaRossi1);
                Console.WriteLine("cartellini Rossi squdra 2: " + contaRossi2);
            }
            else if(contaGolSq1 > contaGolSq2)
            {
                Console.WriteLine();
                Console.WriteLine("HA VINTO LA SQUDRA 1");
                Console.WriteLine();

                Console.WriteLine("Gol squdra 1: " + contaGolSq1);
                Console.WriteLine("Gol squdra 2: " + contaGolSq2);
                Console.WriteLine("cartellini gialli squdra 1: " + contaGialli1);
                Console.WriteLine("cartellini gialli squdra 2: " + contaGialli2);
                Console.WriteLine("cartellini Rossi squdra 1: " + contaRossi1);
                Console.WriteLine("cartellini Rossi squdra 2: " + contaRossi2);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("PAREGGIO");
                Console.WriteLine();

                Console.WriteLine("Gol squdra 1: " + contaGolSq1);
                Console.WriteLine("Gol squdra 2: " + contaGolSq2);
                Console.WriteLine("cartellini gialli squdra 1: " + contaGialli1);
                Console.WriteLine("cartellini gialli squdra 2: " + contaGialli2);
                Console.WriteLine("cartellini Rossi squdra 1: " + contaRossi1);
                Console.WriteLine("cartellini Rossi squdra 2: " + contaRossi2);
            }

        }
    }
}
