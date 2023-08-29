namespace FizzBuzz_George_Hatzigeorgiou
{
    public class ForEach
    {
        /// <summary>
        /// Process range of values using a foreach loop.
        /// </summary>
        /// <param name="values">List<int></param>
        public static void Main(List<int> values)
        {
            try
            {
                foreach (int value in values)
                {
                    Console.WriteLine(Logic.GetOutputFromValue(value));
                }
            } catch(Exception ex)
            {
                Console.WriteLine($"Failed to get output from value in Logic.GetOutFromValue() in {values} with exception: {ex.Message}", ex);
            }

        }
    }
}
