namespace FizzBuzz_George_Hatzigeorgiou
{
    public class DoWhile
    {
        /// <summary>
        /// Process range of values using a do-while loop.
        /// </summary>
        /// <param name="values">List<int></param>
        public static void Main(List<int> values)
        {
            int count = 0;

            try
            {

                do
                {
                    Console.WriteLine(Logic.GetOutputFromValue(values[count]));
                    count++;
                }
                while (count <= values.Count());

            } catch (Exception ex)
            {
                Console.WriteLine($"Failed to get output from value in Logic.GetOutFromValue() while processing the {count} element in {values} wtih exception: {ex}", ex);
            }

        }
    }
}
