using System;

namespace Ovning2
{
   public class Program
    {
        static bool stop = false;
        const int STANDARDPRIS = 120;
        const int UNGDOMSPRIS = 80;
        const int PENSIONPRIS = 90;
        // Main menu module of multi-function console program that handles function selection, keep-alive and communication with the user.
        static void Main(string[] args)
        {
            Console.WriteLine("Huvudmeny. Skriv en siffra för att välja ett alternativ.");
            while (!stop)
            {
                PrintMainMenuOptions();
                string input = Console.ReadLine();
                switch (input)
                {
                    case var d when d.Equals("0"):
                        stop = true;
                        Console.WriteLine("Programmet avslutas.");
                        break;
                    case var d when d.Equals("1"):
                        MovieTicketPriceCalculator();
                        break;
                    default:
                        UnknownOption();
                        break;
                }
            }
        }

        public static void UnknownOption()
        {
            Console.WriteLine("Okänt val, försök igen.");
        }

        // Prints the available menu options.
        public static void PrintMainMenuOptions()
        {
            Console.WriteLine("0: Avsluta programmet.");
            Console.WriteLine("1: Biobiljettsprisräknare");
        }

        public static void MovieTicketPriceCalculator()
        {
            Console.WriteLine("--- Biobiljettprisräknare ---");
            Console.WriteLine("Anger biobiljettpris beroende på angiven ålder.");
            var done = false;
            while (!done)
            {
                var age = 0;
                PrintMovieOptions();
                var input = Console.ReadLine();
                switch (input)
                {
                    case var d when d.Equals("1"):
                        MovieOnePerson(age);
                        break;
                    case var d when d.Equals("2"):
                        MovieSeveralPersons(age);
                        break;
                    case var d when d.Equals("0"):
                        done = true;
                        break;
                    default:
                        UnknownOption();
                        break;
                }
            }
        }

        public static void PrintMovieOptions()
        {
            Console.WriteLine("1: Beräkna pris för en person");
            Console.WriteLine("2: Beräkna pris för ett sällskap.");
            Console.WriteLine("0: Tillbaka till huvudmenyn.");
        }

        private static void MovieSeveralPersons(int age)
        {
            throw new NotImplementedException();
        }

        public static void MovieOnePerson(int age)
        {
            age = GetMovieAgeInput();
            int price = CalculateTicketPrice(age);
            PrintTicketPrice(price);
        }

        public static int CalculateTicketPrice(int age)
        {
            if(age < 65)
            {
                if (age > 19)
                {
                    return STANDARDPRIS;
                }
                else
                {
                    return UNGDOMSPRIS;
                }
            }
            else 
            {
                return PENSIONPRIS;
            }
        }

        // Gets the ticket price depending on age using the constants in the class.
        public static void PrintTicketPrice(int price)
        {
            switch (price)
            {
                case var d when d == STANDARDPRIS:
                    Console.WriteLine($"Standardpris: {STANDARDPRIS}kr");
                    break;
                case var d when d == UNGDOMSPRIS:
                    Console.WriteLine($"Ungdomspris: {UNGDOMSPRIS}kr");
                    break;
                case var d when d == PENSIONPRIS:
                    Console.WriteLine($"Pensonärspris: {PENSIONPRIS}kr");
                    break;
                default:
                    throw new Exception("PrintTicketPrice() did not find a matching case for the supplied price");
            }
        }

        // Gets the age for a person for the movie ticket price checker.
        public static int GetMovieAgeInput()
        {
            string input = "";
            int age = 0;
            while (true)
            {
                Console.WriteLine("Skriv in personens ålder:");
                input = Console.ReadLine();
                int result = ParseMovieAgeInput(input);
                if (result != -1)
                {
                    return result;
                }
            }
        }

        // Parses the input string into a number. Returns -1 in case the number is negative, or the string could not be parsed as an Int32.
        public static int ParseMovieAgeInput(string input)
        {
            var age = 0;
            try
            {
                age = int.Parse(input);
                if (age < 0)
                {
                    Console.WriteLine("Personer kan inte ha negativ ålder.");
                    return -1;
                }
                return age;
            }
            catch (FormatException)
            {
                InputNotInt();
                return -1;
            }
        }

        public static void InputNotInt()
        {
            Console.WriteLine("Var vänlig skriv in en heltalssiffra och försök igen.");
        }
    }
}
