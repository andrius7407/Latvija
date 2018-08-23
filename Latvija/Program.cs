using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latvija
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] eilutes = System.IO.File.ReadAllLines(@"C:\Users\Andrius\Documents\txt_failai\Latvija.txt");
            string pirmaeilute = eilutes[0];
            string[] pirmaduomenys = pirmaeilute.Split(' ');
            // ax - desines sienos x koordinate (L)
            double ax = Convert.ToDouble(pirmaduomenys[0]);
            int n = Convert.ToInt32(pirmaduomenys[1]);
            string antraeilute = eilutes[1];
            //pradinio tasko x koordinate (y koordinate yra 0)
            double koordx = Convert.ToDouble(antraeilute);
            
            // ay - skydo atsitrenkimo i desine siena y koordinate
            double ay = 1;
            
            int NumustuPriesuSkaicius = 0;
            int GalimaNumustiDaugiausiai = 0;
            //masyvas su priesu koordinatemis
            double[,] PriesuKoord = new double[n,2];
            for(int i = 0; i < n; i++)
            {
                string PriesoDuomenys = eilutes[i + 2];
                string[] PriesoKoordinates = PriesoDuomenys.Split(' ');
                PriesuKoord[i, 0] = Convert.ToDouble(PriesoKoordinates[0]);
                PriesuKoord[i, 1] = Convert.ToDouble(PriesoKoordinates[1]);
            }
            for(int j = 0; j < 20; j++)
            {
                double pirmaAtkarpaTangentas = (ay) / (ax - koordx);
                for (int k = 0; k < n; k++)
                {

                    double pirmasTaskasTangentas = (PriesuKoord[k, 1]) / (PriesuKoord[k, 0] - koordx);
                    if (pirmasTaskasTangentas == pirmaAtkarpaTangentas)
                    {
                        NumustuPriesuSkaicius++;
                    }
                }
                // by - skydo atsitrenkimo i kaire siena y koordinate
                double by = 1;
                for (int l = 0; l < 20; l++)
                {
                    double antraAtkarpaTangentas = (by - ay) / ax;
                    for (int m = 0; m < n; m++)
                    {
                        double antrasTaskasTangentas = (PriesuKoord[m, 1] - ay) / (ax - PriesuKoord[m, 0]);
                        if (antrasTaskasTangentas == antraAtkarpaTangentas)
                        {
                            NumustuPriesuSkaicius++;
                        }
                    }
                    double treciaAtkarpaTangentas = koordx / by;
                    for (int p = 0; p < n; p++)
                    {
                        double treciasTaskasTangentas = PriesuKoord[p, 0] / (by - PriesuKoord[p, 1]);
                        if (treciasTaskasTangentas == treciaAtkarpaTangentas)
                        {
                            NumustuPriesuSkaicius++;
                        }
                        if (NumustuPriesuSkaicius > GalimaNumustiDaugiausiai)
                        {
                            GalimaNumustiDaugiausiai = NumustuPriesuSkaicius;
                        }
                    }
                    NumustuPriesuSkaicius = 0;
                    by++;

                }          
                ay++;
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\txt_failai\Latvijarez.txt"))
            {
                file.WriteLine(GalimaNumustiDaugiausiai);
            }

        }
    }
}
