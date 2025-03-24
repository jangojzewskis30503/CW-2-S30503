namespace APBD_CW2
{
    public class Program
    {
        public static void Main(String[] args)
        {
            //testy
            try
            {
                // Tworzenie statku
                Ship ship = new Ship("Posejdon", 30, 5, 10000);

                // Tworzenie różnych typów kontenerów
                GasContainer gasContainer = new GasContainer(5000, 1000, 200, 150, 10);
                LiquidContainer liquidContainer = new LiquidContainer(4000, 800, 180, 140, true);
                RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(3000, 700, 160, 130, "Meat", -15);

                // Test ładowania kontenerów na statek
                ship.ZaładujKontener(gasContainer);
                ship.ZaładujKontener(liquidContainer);
                ship.ZaładujKontener(refrigeratedContainer);

                //// Wyświetlenie informacji o statku i jego ładunku
                ship.WypiszInformacje();

                //// Próba przeładowania kontenera
                try
                {
                    liquidContainer.ZaladujLadunek(3000); // Powinno rzucić wyjątek
                }
                catch (OverFillException e)
                {
                    Console.WriteLine(e.Message);
                }

                //// Test opróżniania kontenerów
                gasContainer.WyladujLadunek();
                ship.WypiszInformacje();

                // Tworzenie drugiego statku
                Ship ship2 = new Ship("Neptun", 25, 5, 8000);

                // Test przenoszenia kontenera między statkami
                ship.PrzeniesKontener(ship2, gasContainer);

                // Wyświetlenie informacji o obu statkach
                ship.WypiszInformacje();
                ship2.WypiszInformacje();

                // Test usuwania kontenera ze statku
                ship.RozładujKontener(liquidContainer);
                ship.WypiszInformacje();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }






        }

    }
}
