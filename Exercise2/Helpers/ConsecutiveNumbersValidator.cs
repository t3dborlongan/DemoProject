namespace Exercise2.Helpers
{
    internal class ConsecutiveNumbersValidator
    {
        public static bool Valid(List<decimal> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return false;

            // Sort the list
            numbers.Sort();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] != numbers[i + 1] - 1)
                    return false;
            }

            return true;
        }
    }
}
