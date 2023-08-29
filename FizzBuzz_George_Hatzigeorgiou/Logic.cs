namespace FizzBuzz_George_Hatzigeorgiou
{
    public class Logic
    {
        /// <summary>
        /// Uses order of operations to determine the processed value of each value passed in.
        /// </summary>
        /// <param name="value">integer</param>
        /// <returns>string value: either FizzBuzz, Fizz, Buzz or the actual number if it is not a multiple of 3, 5 or both.</returns>
        public static string GetOutputFromValue(int value)
        {
            return value % 15 == 0 ? StaticValues.FizzBuzz :
                   value % 3 == 0 ? StaticValues.Fizz :
                   value % 5 == 0 ? StaticValues.Buzz :
                   value.ToString();
        }
    }
}
