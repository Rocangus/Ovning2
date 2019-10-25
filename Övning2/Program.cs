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
                    case var d when d.Equals("2"):
                        RepeatTenTimes();
                        break;
                    case var d when d.Equals("3"):
                        PickThirdWord();
                        break;
                    default:
                        UnknownOption();
                        break;
                }
            }
        }

        // Small function that prints a message to the console when an unknown option number was selected.
        public static void UnknownOption()
        {
            Console.WriteLine("Okänt val, försök igen.");
        }

        // Prints the available menu options.
        public static void PrintMainMenuOptions()
        {
            Console.WriteLine("1: Biobiljettsprisräknare");
            Console.WriteLine("2: Återupprepare");
            Console.WriteLine("3: Det tredje ordet.");
            Console.WriteLine("0: Avsluta programmet");
        }

        // Module for calculating the price for movie tickets. Supports individual people and groups.
        public static void MovieTicketPriceCalculator()
        {
            Console.WriteLine("--- Biobiljettprisräknare ---");
            Console.WriteLine("Anger biobiljettpris beroende på angiven ålder.");
            MovieOptionSelector();
        }

        // Called by the movie ticket price module to decide what to do.
        public static void MovieOptionSelector()
        {
            var done = false;
            while (!done)
            {
                var age = 0;
                PrintMovieOptions();
                var input = Console.ReadLine();
                switch (input)
                {
                    case var d when d.Equals("1"):
                        MovieOnePerson();
                        break;
                    case var d when d.Equals("2"):
                        MovieSeveralPersons();
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

        // Prints the options for the movie ticket price calculator module.
        public static void PrintMovieOptions()
        {
            Console.WriteLine("1: Beräkna pris för en person");
            Console.WriteLine("2: Beräkna pris för ett sällskap.");
            Console.WriteLine("0: Tillbaka till huvudmenyn.");
        }

        // Main method for the group movie ticket price calculation.
        public static void MovieSeveralPersons()
        {
            Console.WriteLine("Ange antalet personer:");
            while (true)
            {
                int persons;
                try
                {
                    persons = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    InputNotInt();
                    continue;
                }
                if (persons <= 0)
                {
                    Console.WriteLine("Antalet personer måste vara minst 1.");
                    continue;
                }
                int[] ages = GetSeveralPersonsMovieAge(persons);
                PrintTotalTicketPriceInfo(ages);
                return;
            }
        }

        // Prints the number of persons and the total price to console. Returns the sum for testability.
        public static int PrintTotalTicketPriceInfo(int[] ages)
        {
            var sum = 0;
            foreach(int n in ages)
            {
                sum += CalculateTicketPrice(n);
            }
            Console.WriteLine($"Antal personer: {ages.Length}\nTotalkostnad: {sum}");
            return sum;
        }

        // Gets the age of the person to visit the movies, then calls the appropriate methods to calculate and print the ticket price.
        public static void MovieOnePerson()
        {
            var age = GetOnePersonMovieAgeInput();
            var price = CalculateTicketPrice(age);
            PrintTicketPrice(price);
        }

        // Returns the appropriate ticket price for the stated age given as parameter.
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
        public static int GetOnePersonMovieAgeInput()
        {
            while (true)
            {
                Console.WriteLine("Skriv in personens ålder:");
                var input = Console.ReadLine();
                int result = ParseMovieAgeInput(input);
                if (result != -1)
                {
                    return result;
                }
            }
        }
        
        // Gets age for several persons for the movie ticket price checker.
        public static int[] GetSeveralPersonsMovieAge(int patrons)
        {
            var ages = new int[patrons];
            for (var i = 0; i < patrons; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Ange ålder för person {i + 1}:");
                    var input = Console.ReadLine();
                    var result = ParseMovieAgeInput(input);
                    if (result != -1)
                    {
                        ages[i] = result;
                        break;
                    }
                }
            }
            return ages;
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

        // Prints an information message if the user did not input something convertable to an integer.
        public static void InputNotInt()
        {
            Console.WriteLine("Var vänlig skriv in en heltalssiffra och försök igen.");
        }


        public static void RepeatTenTimes()
        {
            Console.WriteLine("Skriv vad du vill i konsolen. Det kommer att upprepas tio gånger.");
            var text = Console.ReadLine();
            for (var i = 0; i < 9; i++)
            {
                Console.Write($"{text}, ");
            }
            Console.Write($"{text}\n");
        }

        // Picks the third word from the user's input and prints it to console.
        private static void PickThirdWord()
        {
            Console.WriteLine("Programmet ber om en mening på minst tre ord. Det tredje ordet kommer att skrivas ut på konsolen.");
            var words = GetSentence();
            var word = words[2];
            Console.WriteLine(word);
        }

        // Gets a sentence from the user and re-prompts of less than three words are in the user input.
        private static string[] GetSentence()
        {
            while (true)
            {
                Console.WriteLine("Skriv en mening med minst tre ord.");
                var input = Console.ReadLine();
                var temp = input.Split(' ');
                var count = 0;
                string[] actualWords = ValidateWords(temp, ref count);
                if (count < 3)
                {
                    Console.WriteLine("För få ord, försök igen.");
                    continue;
                }
                string[] words = new string[count];
                Array.Copy(actualWords, words, count);
                return words;
            }
        }

        // Helps remove empty strings created by too many spaces.
        private static string[] ValidateWords(string[] temp, ref int count)
        {
            var result = new string[temp.Length];
            for (var i = 0; i < temp.Length; i++)
            {
                var str = temp[i];
                if (str.Length > 0)
                {
                    result[count] = str;
                    count++;
                }
            }

            return result;
        }
    }
}
