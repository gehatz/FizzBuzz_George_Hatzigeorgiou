namespace FizzBuzz_George_Hatzigeorgiou
{
    public class While
    {
        /// <summary>
        /// Process range of values using a while loop
        /// </summary>
        /// <param name="values">List<int></int></param>
        public static void Main(List<int> values)
        {
            int count = 0;
            try
            {
                while (count < values.Count())
                {
                    Console.WriteLine(Logic.GetOutputFromValue(values[count]));
                    count++;
                }
            } catch(Exception ex)
            {
                Console.WriteLine($"Failed to process values in Logic.GetOutputFromValue for value with index {values[count]} with message: {ex.Message}", ex);
            }

        }
    }
}
