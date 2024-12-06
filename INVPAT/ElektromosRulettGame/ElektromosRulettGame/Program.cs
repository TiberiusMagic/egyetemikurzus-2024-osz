using ElektromosRulettGame;

GameLogics jatek = new GameLogics();

Console.WriteLine("Üdvözöllek az SZTE Szerencsejáték Kar Rulett Szakának Elektromos Rulett játékban!");
Console.WriteLine($"Kezdő egyenleged: {jatek.money} kredit");

bool exitGame = false;

while (!exitGame)
{
    Console.WriteLine("\nFőmenü:");
    Console.WriteLine("1 - Tét elhelyezése");
    Console.WriteLine("2 - Játék indítása");
    Console.WriteLine("3 - Tét visszavonása");
    Console.WriteLine("4 - Kölcsön felvétele");
    Console.WriteLine("5 - Játék állapota");
    Console.WriteLine("0 - Kilépés");
    Console.Write("Válassz egy opciót: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Mennyi kreditet kockáztatsz?");
            int risk = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Elérhető tétek: Számok 0-36, Piros, Fekete, Zöld, Tucat 1, Tucat 2, Tucat 3");
            Console.Write("Add meg a tét típusát: ");
            string playerBetType = Console.ReadLine();
            if (jatek.PlaceBet(risk, playerBetType))
            {
                Console.WriteLine($"Sikerült felraknod {risk} kreditet a {playerBetType} fogadásra.");
            }
            else
            {
                Console.WriteLine("Nem tudsz ennyit felrakni. Ellenőrizd a tevékenységedet, és próbáld újra. Ha kell, vehetsz fel hitelt ;)");
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
            Console.WriteLine($"Kölcsön felvéve! Az új egyenleged: {jatek.money} kredit");
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
        
