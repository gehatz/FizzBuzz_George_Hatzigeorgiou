using FizzBuzz_George_Hatzigeorgiou;
using System.Text.RegularExpressions;

namespace FizzBuz_George_Hatzigeorgiou
{
    internal static class Program
    {
        public static string _methodology = String.Empty;
        public static string _mode = String.Empty;
        public static int _min;
        public static int _range;

        private static void Main(string[] arguments)
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + StaticValues.appGuid))
            {
                // Do not allow the execution of more than a single instance of this application to run at a time.
                if (!mutex.WaitOne(0, false))
                {
                    Console.WriteLine("Only one instance of this application may be executed at any given time.");
                    return;
                }

                GetMainMenuSelection();

                List<int> values;

                switch (_mode.ToLower())
                {
                    case "default":

                        // Create a list of integers ranging from the selected min and max
                        values = Enumerable.Range(1, 100).ToList();
                        // Get desired execution methodology
                        GetDesiredMethodology();
                        // Execute selected methodology
                        ExecuteSelectedMethodology(values);

                        break;
                    
                    case "customrange":

                        // Get and set application values
                        GetRangeMinimum();
                        GetRangeMaximum();

                        // Get desired execution methodology
                        GetDesiredMethodology();

                        // Create a list of integers ranging from the selected min and max
                        values = Enumerable.Range(_min, _range).ToList();
                        // Execute selected methodology
                        ExecuteSelectedMethodology(values);

                        break;

                    case "singlevalue":

                        // Process single value
                        ProcessSingleNumber();

                        break;
                    default:

                        // Invalid input message
                        Console.WriteLine("Invalid input. Only values 1, 2 and 3 are valid.");

                        break;
                }

            }

        }

        /// <summary>
        /// Main menu selection method.
        /// </summary>
        private static void GetMainMenuSelection()
        {
            Console.WriteLine("Welcome to FizzBuzz");
            Console.WriteLine("Select Mode");
            Console.WriteLine("1 - Default Mode");
            Console.WriteLine("2 - Custom Range");
            Console.WriteLine("3 - Single Value");

            var input = Console.ReadLine();
            var value = 0;
            bool validInt = int.TryParse(input, out value);

            if (validInt)
            {
                switch (value)
                {
                    case 1:
                        _mode = StaticValues.DefaultMode;
                        break;
                    case 2:
                        _mode = StaticValues.CustomRange;
                        break;
                    case 3:
                        _mode = StaticValues.SingleValue;
                        break;
                    default:
                        Console.WriteLine("Entry out of range. Please select either option 1, 2 or 3.");
                        GetMainMenuSelection();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid value. Please enter a numeric value for the minimum number of the range of numbers you would like to process...");
                return;
            }
        }

        /// <summary>
        /// Desired methodology selection method.
        /// 1. Default (1-100) 2. Custom Range 3. Single Value
        /// </summary>
        private static void GetDesiredMethodology()
        {
            Console.WriteLine("Select the number (1 - 4) that corresponds to the methodology you would like used to play the game...");
            Console.WriteLine("1 - Do While Loop");
            Console.WriteLine("2 - For Loop");
            Console.WriteLine("3 - For Each Loop");
            Console.WriteLine("4 - While Loop");
            Console.WriteLine("5 - LINQ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _methodology = StaticValues.DoWhileMethodology;
                    break;
                case "2":
                    _methodology = StaticValues.ForMethodology;
                    break;
                case "3":
                    _methodology = StaticValues.ForEachMethodology;
                    break;
                case "4":
                    _methodology = StaticValues.WhileMethodology;
                    break;
                case "5":
                    _methodology = StaticValues.LINQMethodology;
                    break;
                default:
                    _methodology = StaticValues.LINQMethodology;
                    break;
            }
        }

        /// <summary>
        /// Single numeric value processing method.
        /// </summary>
        private static void ProcessSingleNumber()
        {
            Console.WriteLine("Please enter any integer to process:");
            var input = Console.ReadLine();

            var value = 0;
            bool validInt = int.TryParse(input, out value);
            
            if (!String.IsNullOrEmpty(input))
            {
                if (validInt)
                {
                    Console.WriteLine(Logic.GetOutputFromValue(value));
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter any integer to process...");
                    ProcessSingleNumber();
                }

            } else
            {
                Console.WriteLine("Invalid input. Please try again...");
                ProcessSingleNumber();
            }

        }

        /// <summary>
        /// Executes logic based on user selected methodology.
        /// Defaults to LINQ methodology
        /// </summary>
        /// <param name="values"></param>
        private static void ExecuteSelectedMethodology(List<int> values)
        {
            // Execute program based on selected methodology
            switch (_methodology.ToLower())
            {
                case "foreach":
                    // Generate output using a for loop
                    ForEach.Main(values);
                    break;
                case "for":
                    // Generate output using a for loop
                    For.Main(values);
                    break;
                case "linq":
                    // Create output using LINQ
                    LINQ.Main(values);
                    break;
                case "while":
                    // Create output using a while loop
                    While.Main(values);
                    break;
                case "dowhile":
                    DoWhile.Main(values);
                    break;
                default:
                    // Default is LINQ
                    LINQ.Main(values);
                    break;
            }
        }

        /// <summary>
        /// Gets numeric value for custom range minimum.
        /// (also validates numeric user input)
        /// </summary>
        private static void GetRangeMinimum()
        {
            Console.WriteLine("Enter the minimum number of the range of numbers you would like to process...");
            var input = Console.ReadLine();
            var value = 0;
            bool validInt = int.TryParse(input, out value);

            if (validInt)
            {
                _min = value;
            }
            else
            {
                Console.WriteLine("Invalid value. Please enter a numeric value for the minimum number of the range of numbers you would like to process...");
                return;
            }

        }

        /// <summary>
        /// Gets numeric value for custom range maximum.
        /// (also validates numeric user input and max being greater than min)
        /// </summary>
        private static void GetRangeMaximum()
        {
            Console.WriteLine($"Enter the range of numbers you wish to process started from your selected minimum of {_min}...");
            var input = Console.ReadLine();

            var value = 0;
            bool validInt = int.TryParse(input, out value);

            if (validInt)
            {
                _range = value;
            }
            else
            {
                Console.WriteLine("Invalid value. Please enter a numeric value for the maximum number of the range of numbers you would like to process...");
                return;
            }
        }

    }
}