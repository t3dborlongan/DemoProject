namespace Exercise2.Helpers
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.Json;
    using Common.Utils;
    using Common.Constants;
    using Constants.Utils;
    using System.Text.Json.Nodes;
    using System.Text;

    public static class OutputGenerator
    {
        public static void PrintSortedNumbersDescending(this List<decimal> inputValues) {
            
            var sortedValues = inputValues.OrderByDescending(item => item).ToList();

            Console.WriteLine();
            sortedValues.ForEach(item => Console.WriteLine(item));
            Console.WriteLine();
        }

        public static void PrintSortedNumbersAscending(this List<decimal> inputValues)
        {

            var sortedValues = inputValues.OrderBy(item => item).ToList();

            Console.WriteLine();
            sortedValues.ForEach(item => Console.WriteLine(item));
            Console.WriteLine();
        }

        public static void PrintRandomItemFromTheList(this List<decimal> inputValues)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, inputValues.Count);

            Decimal randomItem = inputValues[randomIndex];

            Console.WriteLine();
            Console.WriteLine("Chosen random item from the list: " + randomItem);
            Console.WriteLine();
        }

        public static void MultiplyValues(this List<decimal> inputValues)
        {
            var currentValue = 0M;
          
            Dictionary<string, object> jsonObject = new Dictionary<string, object>();

            for (int i = 0; i < inputValues.Count() - 1; i++) {
                currentValue += inputValues[i] * inputValues[i + 1];
                jsonObject.Add($"InputNumber{i + 1}", inputValues[i]);
            }

            jsonObject.Add($"Multiplication", currentValue);

            string jsonString = JsonSerializer.Serialize(jsonObject);
            DirectoryHelper.SetupDeploymentDirectory(DeploymentPaths.AUDIT_TRAIL);
            AuditTrailHelper.LogToJsonFile(jsonString);
            Console.WriteLine();
        }

        public static void SubtractValuesTopDown(this List<decimal> inputValues)
        {
            var sortedValues = inputValues.OrderByDescending(item => item).ToList();
            var values = new List<string>();
            for (int i = 0; i < sortedValues.Count() - 1; i++)
            {
                var minuend = sortedValues[i];
                var subtrahend = sortedValues[i + 1];
                values.Add($"{minuend} - {subtrahend} = {minuend - subtrahend}");
            }

            var sb = new StringBuilder();
            sb.AppendLine(String.Join(",", values));
            Console.WriteLine();
            Console.WriteLine("Displaying output of subtraction:");
            Console.WriteLine(sb.ToString());
        }
    }
}
