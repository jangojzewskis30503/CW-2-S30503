using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_CW2
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Cisnienie { get;  set; }

        public GasContainer(double wagaMaksymalna, double wagaKontenera, double wysokosc, double glebokosc, double cisnienie)
            : base("G", wagaMaksymalna, wagaKontenera, wysokosc, glebokosc)
        {
            Cisnienie = cisnienie;
        }

        public override void ZaladujLadunek(double waga)
        {
        base.ZaladujLadunek(waga);
        }

        public override void WyladujLadunek()
        {
            double pozostałyLadunek = WagaLadunku * 0.05; 
              
            Console.WriteLine($"Kontener {NrSeryjny} oprożniony, ale pozostawiono 5% ładunku: {pozostałyLadunek} kg");
        }

        public void NotifyHazard(string nrSeryjny)
        {
            Console.WriteLine($"Uwaga! Niebezpieczne zdarzenie w kontenerze: {nrSeryjny}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Ciśnienie: {Cisnienie} atm";
        }

    }

}
