using ElektromosRulettGame;

GameLogics jatek = new GameLogics();

Console.WriteLine("Üdvözöllek az SZTE Szerencsejáték Kar Rulett Szakának Elektromos Rulett játékban!");
Console.WriteLine($"Kezdő egyenleged: {jatek.money} kredit");

bool exitGame = false;

while (!exitGame)
{
    Console.WriteLine("\nFőmenü:");
    Console.WriteLine("1 - Tét elhelyezése");
    Console.WriteLine("2 - Tét véglegesítése és Pörgetés");
    Console.WriteLine("3 - Tét visszavonása");
    Console.WriteLine("4 - Kölcsön felvétele");
    Console.WriteLine("5 - Játék állapota");
    Console.WriteLine("0 - Kilépés");
    Console.Write("Válassz egy opciót: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            int risk = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Mennyi kreditet kockáztatsz?");
                string? input = Console.ReadLine();

                try
                {
                    risk = Int32.Parse(input);
                    if (risk <= 0)
                    {
                        Console.WriteLine("A tétnek pozitív számnak kell lennie. Próbáld újra.");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Érvénytelen input. Kérlek, adj meg egy egész számot.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("A megadott szám túl nagy. (Mármint nem az én szám, az teljesen átlagos méretű a fogorvosom szerint!) Adj meg egy kisebb számot.");
                }
            }

            Console.WriteLine("Elérhető tétek: Számok 0-36, Piros, Fekete, Zöld, Kicsi, Nagy, Páros, Páratlan, Tucat 1, Tucat 2, Tucat 3");

            string? playerBetType = "";
            bool validBetType = false;

            while (!validBetType)
            {
                Console.Write("Add meg a tét típusát: ");
                playerBetType = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(playerBetType))
                {
                    Console.WriteLine("Írj be valamit tét típusnak. (Elérhető tétek: Számok 0-36, Piros, Fekete, Zöld, Kicsi, Nagy, Páros, Páratlan, Tucat 1, Tucat 2, Tucat 3)");
                }
                else
                {
                    validBetType = true;
                }
            }


            if (jatek.PlaceBet(risk, playerBetType.First().ToString().ToUpper() + String.Join("", playerBetType.Skip(1))))
            {
                Console.WriteLine($"Sikerült felraknod {risk} kreditet a {playerBetType} fogadásra.");
            }
            else
            {
                Console.WriteLine("Nem tudsz ennyit felrakni, vagy nincs ilyen fogadásfajta. Ellenőrizd a tevékenységedet, és próbáld újra. Ha kell, vehetsz fel hitelt ;)");
            }
            break;

        case "2":
            jatek.ConfirmBetAndStartGame();
            break;

        case "3":
            jatek.CancelBet();
            Console.WriteLine($"A tétedet visszavontuk. Új egyenleged: {jatek.money} kredit");
            break;

        case "4":
            jatek.TakeOutALoan();
            break;

        case "5":
            Console.WriteLine($"Jelenlegi egyenleg: {jatek.money}");
            Console.WriteLine($"Aktuális tét: {jatek.currentBet} - Összeg: {jatek.currentBetSize} kredit");
            break;

        case "0":
            exitGame = true;
            Console.WriteLine("Köszönöm, hogy játszottál! Viszlát!");
            break;

        default:
            Console.WriteLine("Érvénytelen opció. Próbáld újra.");
            break;
    }
}
        
