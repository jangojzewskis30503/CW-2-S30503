using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_CW2
{
    public class RefrigeratedContainer : Container, IHazardNotifier
    {
        protected double Temperatura { get;  set; }
        protected string Produkt { get; set; }

        private static Dictionary<string, double> MinimalneTemperatury = new Dictionary<string, double>()
        {
             { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }


        };







        public RefrigeratedContainer(double wagaMaksymalna, double wagaKontenera, double wysokosc, double glebokosc,string produkt, double temperatura)
            : base("C", wagaMaksymalna, wagaKontenera, wysokosc, glebokosc)
        {
            if (!MinimalneTemperatury.ContainsKey(produkt))
            {
                throw new Exception("Nieznany produkt, nie utworzono kontenera!!!");
            }

            if(MinimalneTemperatury[produkt] > temperatura)
            {
                throw new Exception($"Temperatura nie moze byc nizsza {MinimalneTemperatury[produkt]} stopni dla {produkt}  ");
            }






            Temperatura = temperatura;
            Produkt = produkt;
        }

        public override void ZaladujLadunek(double waga)
        {
           base.ZaladujLadunek(waga);
        }



        public void UstawTemperature(double nowaTemperatura)
        {
            if (nowaTemperatura < MinimalneTemperatury[Produkt])
            {
                throw new Exception($"Nie można ustawić temperatury poniżej {MinimalneTemperatury[Produkt]}°C dla {Produkt}.");
            }

            Temperatura = nowaTemperatura;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Produkt: {Produkt}, Temperatura: {Temperatura} stopni";
        }
    



public void NotifyHazard(string nrSeryjny)
        {
            Console.WriteLine($"Uwaga! Niebezpieczne zdarzenie w kontenerze chłodniczym: {nrSeryjny}");
        }




       
    }

}

