using LOGIK;
namespace UI;
public class ConsoleInput
{
    public static string GetString(string output) // i input kan man skriva tex ange ett namn
    {
        string input = string.Empty;
        do
        {
            Console.WriteLine(output);            //så skrivs det ut "ange ett namn"
            input = Console.ReadLine();           // användaren skriver i sitt namn

        } while (string.IsNullOrWhiteSpace(input) == true);       //om det inte är tomt så returneras namnet direkt till en string name = denna metod
        return input;
    }
    public static int GetInt(string output)
    {
        int inputInt = 0;
        while (true)
        {
            try
            {
                Console.WriteLine(output);
                string input = Console.ReadLine();
                inputInt = int.Parse(input);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a digit.");
            }
        }
        return inputInt;

    }
}