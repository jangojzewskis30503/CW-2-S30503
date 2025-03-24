using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_CW2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private bool NiebiezpiecznyLadunek { get; set; }

        public LiquidContainer(double wagaMaksymalna, double wagaKontenera, double wysokosc, double glebokosc, bool niebiezpiecznyLadunek)
            : base("L", wagaMaksymalna, wagaKontenera, wysokosc, glebokosc)
        {
            NiebiezpiecznyLadunek = niebiezpiecznyLadunek;
        }

        public override void ZaladujLadunek(double waga)
        {

            if (NiebiezpiecznyLadunek == true)
            {
                if (waga + WagaLadunku > WagaMaksymalna * 0.5)
                {
                    throw new OverFillException($"Niepoprawny ładunek: Przepełnienie kontenera {NrSeryjny}!");  
                }
               } else
                {
                if (waga + WagaLadunku > WagaMaksymalna * 0.9)
                {
                    throw new OverFillException($"Niepoprawny ładunek: Przepełnienie kontenera {NrSeryjny}!");
                }
            }
            base.ZaladujLadunek (waga);


        }
        public void NotifyHazard(string nrSeryjny)
        {
            Console.WriteLine($"Uwaga! Niebezpieczne zdarzenie w kontenerze na płyny: {nrSeryjny}");

        }

        public override string ToString()
        {
            return base.ToString() + (NiebiezpiecznyLadunek ? " (Niebezpieczny ładunek)" : " (Ładunek zwykły)");
        }



    }
}

