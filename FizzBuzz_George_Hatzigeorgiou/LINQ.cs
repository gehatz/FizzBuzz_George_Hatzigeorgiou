namespace FizzBuzz_George_Hatzigeorgiou
{
    public class LINQ
    {
        /// <summary>
        /// Process range of values using LINQ.
        /// </summary>
        /// <param name="values">List<int></param>
        public static void Main(List<int> values)
        {
            try
            {
                
                // Create a list of numbers from min to max and iterate through it 
                // outputing the appropriate output for each value as a string.
                Enumerable.Range(values.First(), values.Last())
                        .ToList()
                        .ForEach(number =>
                            Console.WriteLine(
                                Logic.GetOutputFromValue(number)
                                ));

            } catch(Exception ex)
            {
                Console.WriteLine($"Failed to get output from value in Logic.GetOutFromValue() in {values} with exception: {ex.Message}", ex);
            }

        }
    }
}
