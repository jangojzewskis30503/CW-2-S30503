using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_CW2
{
    public abstract class Container
    {
        private double wagaLadunku  { get; set; }
        private double wagaKontenera    { get; set; }
        private double wagaMaksymalna { get; set; }
        private double wysokosc {  get; set; }
        private double glebokosc {  get; set; }
        private string nr_seryjny { get; set; }
       
        private int nr_seryjny_licznik = 1;
       
        
        public Container(string typ, double wagaKontenera)
        {
            nr_seryjny = $"KON-{typ}-{nr_seryjny_licznik++}";

            wagaMaksymalna = wagaMaksymalna;
           }


        public virtual void ZaladujLadunek(double waga)
        {
            if (waga + wagaKontenera > wagaMaksymalna)
            {
                throw new OverFillException($"Przepełnienie kontenera{nr_seryjny}!");
            }
            wagaLadunku += waga;

        }




    }
}
