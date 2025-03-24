using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_CW2
{
    public class Ship
    {
        public string Nazwa { get; set; }
        public double MaksymalnaPredkosc { get; set; }
        public int MaksymalnaLiczbaKontenerow { get; set; }
        public double MaksymalnaWagaKontenerow { get; set; }

        private List<Container> Kontenery;

        public Ship(string nazwa, double maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, double maksymalnaWagaKontenerow)
        {
            Nazwa = nazwa;
            MaksymalnaPredkosc = maksymalnaPredkosc;
            MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
            MaksymalnaWagaKontenerow = maksymalnaWagaKontenerow;
            Kontenery = new List<Container>();
        }

        public void ZaładujKontener(Container kontener)
        {
            double całkowitaWaga = 0;
            foreach (var k in Kontenery)
            {
                całkowitaWaga += k.WagaLadunku + k.WagaKontenera;
            }

            if (Kontenery.Count >= MaksymalnaLiczbaKontenerow || całkowitaWaga + kontener.WagaLadunku + kontener.WagaKontenera > MaksymalnaWagaKontenerow)
            {
                throw new Exception("Nie można załadować kontenera: przekroczona maksymalna pojemność.");
            }

            Kontenery.Add(kontener);
            Console.WriteLine($"Kontener {kontener.NrSeryjny} został załadowany na statek {Nazwa}.");
        }

        public void RozładujKontener(Container kontener)
        {
            if (Kontenery.Contains(kontener))
            {
                Kontenery.Remove(kontener);
                kontener.WyladujLadunek();
                Console.WriteLine($"Kontener {kontener.NrSeryjny} został rozładowany ze statku {Nazwa}.");
            }
            else
            {
                Console.WriteLine($"Kontener {kontener.NrSeryjny} nie jest załadowany na statek {Nazwa}.");
            }
        }

        public void ZastąpKontener(Container staryKontener, Container nowyKontener)
        {
            int index = Kontenery.IndexOf(staryKontener);
            if (index != -1)
            {
                Kontenery[index] = nowyKontener;
                Console.WriteLine($"Kontener {staryKontener.NrSeryjny} został zastąpiony przez {nowyKontener.NrSeryjny}.");
            }
            else
            {
                Console.WriteLine($"Kontener {staryKontener.NrSeryjny} nie znajduje się na statku.");
            }
        }

        public void PrzeniesKontener(Ship innyStatek, Container kontener)
        {
            try
            {
                this.RozładujKontener(kontener);
                innyStatek.ZaładujKontener(kontener);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WypiszInformacje()
        {
            Console.WriteLine($"Statek {Nazwa}: {Kontenery.Count}/{MaksymalnaLiczbaKontenerow} kontenerów załadowanych.");
            foreach (var kontener in Kontenery)
            {
                Console.WriteLine(kontener);
            }
        }
    }
}
