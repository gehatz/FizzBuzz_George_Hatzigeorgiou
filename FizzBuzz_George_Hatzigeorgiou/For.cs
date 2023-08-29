namespace FizzBuzz_George_Hatzigeorgiou
{
    public class For
    {
        /// <summary>
        /// Process range of values using a for loop.
        /// </summary>
        /// <param name="values">List<int></param>
        public static void Main(List<int> values)
        {
            try
            {
                
                for (int i = 0; i <= values.Count(); i++)
                {
                    Console.WriteLine(Logic.GetOutputFromValue(values[i]));
                }

            } catch (Exception ex) 
            { 
                Console.WriteLine($"Failed to get output from value in Logic.GetOutFromValue() in {values} with exception: {ex.Message}", ex);
            }

        }
    }
}
