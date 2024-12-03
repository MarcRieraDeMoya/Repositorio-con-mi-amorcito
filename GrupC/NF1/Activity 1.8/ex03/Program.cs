using System.Buffers.Binary;

namespace ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            //per a poder tenir els valors de les variables llegirem
            //escquerre i mig previament i en cada iteracio llegirem dreta
            int esquerre, mig, dreta = 0;
            const string path = @"..\..\..\..\FITXERS FINESTRES\";
            bool minimLocal = false;
            string fitxer = "";
            string linia;
            char resposta = 's';
            char opcio = '0';

            while (resposta == 's')
            {
                Console.WriteLine("Fitxers");
                Console.WriteLine("1.- MINIM_LOCAL1");
                Console.WriteLine("2.- MINIM_LOCAL2");
                Console.Write("Tria un fitxer: ");
                opcio = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (opcio == '1')
                    fitxer = "MINIM_LOCAL1.TXT";
                else if (opcio == '2')
                    fitxer = "MINIM_LOCAL2.TXT";
                else
                    Console.WriteLine("No has triat una opcio valida");

                if (File.Exists(path + fitxer))
                {
                    StreamReader sr = new StreamReader(path + fitxer); 

                    //Valors entrada 
                    //Correctament hem de controlar que el fitxer no estigui buit o tindrem errors
                    linia = sr.ReadLine();
                    if (linia == null)
                        Console.WriteLine("El fitxer està buit");
                    else
                    {
                        esquerre = Convert.ToInt32(linia);
                        linia = sr.ReadLine();
                        if (linia == null)
                            Console.WriteLine("No hem trobat suficients valors");
                        else
                        {
                            mig = Convert.ToInt32(linia);
                            linia = sr.ReadLine();
                            while (linia != null && !minimLocal)
                            {
                                dreta = Convert.ToInt32(linia);
                                minimLocal = esquerre < mig && mig < dreta;
                                if (!minimLocal)
                                {
                                    esquerre = mig;
                                    mig = dreta;
                                    linia = sr.ReadLine();
                                }
                            }
                            if (minimLocal)
                                Console.WriteLine($"Hem trobat una vall als valors {esquerre} - {mig} - {dreta} ");
                            else
                                Console.WriteLine($"La seqüència de valors NO ES CREIXENT");
                        }
                    }
                }
                else
                    Console.WriteLine($"No s'ha trobat el fitxer {fitxer} a la ruta {path}");

                Console.Write("Vols llegir un altre fitxer: ");
                resposta = Console.ReadKey().KeyChar;
                Console.Clear();
            }
        }
    }
}
