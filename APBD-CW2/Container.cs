using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_CW2
{
    public abstract class Container
    {
        public double WagaLadunku {  get;  set; }
        public double WagaKontenera { get;  set; }
        protected double WagaMaksymalna { get; set; }
        protected double Wysokosc { get;  set; }
        protected double Glebokosc { get;  set; }
        public string NrSeryjny { get;  set; }
        private static int nrSeryjnyLicznik = 1;

        public Container(string typ, double wagaMaksymalna, double wagaKontenera, double wysokosc, double glebokosc)
        {
            NrSeryjny = $"KON-{typ}-{nrSeryjnyLicznik++}";
            WagaMaksymalna = wagaMaksymalna;
            WagaKontenera = wagaKontenera;
            Wysokosc = wysokosc;
            Glebokosc = glebokosc;
            WagaLadunku = 0;
        }

       

        public virtual void ZaladujLadunek(double waga)
        {
            if (WagaLadunku + waga > WagaMaksymalna)
            {
                throw new OverFillException($"Przepełnienie kontenera: {NrSeryjny}!");
            }

            WagaLadunku += waga;
        }

        public virtual void WyladujLadunek()
        {
            WagaLadunku = 0;
        }

        public override string ToString()
        {
            return $"{NrSeryjny}: {WagaLadunku}/{WagaMaksymalna} kg";
        }
    }
}
    

