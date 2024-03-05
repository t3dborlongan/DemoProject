using Exercise2.Helpers;

static void ExecuteUserAction(List<decimal> collectedValues)
{
    bool? repeatUserAction = true;
    while (repeatUserAction.GetValueOrDefault())
    {
        Console.WriteLine();
        Console.WriteLine("Please choose your desired action below:");
        Console.WriteLine("1. Perform subtraction and show output on screen comma separated.");
        Console.WriteLine("2. Perform multiplication and store result in a JSON file.");
        Console.WriteLine("3. Pick randomly a number and show it on screen.");
        Console.WriteLine("4. Print sorted (highest to lowest) array/list numbers.");
        Console.WriteLine("5. Print sorted (lowest to highest) array/list numbers.");
        Console.WriteLine();
        Console.Write("Enter your desired action:");

        var userAction = Console.ReadLine();

        if (int.TryParse(userAction, out int action))
        {
            switch (action)
            {
                case 1:
                    collectedValues.SubtractValuesTopDown();
                    break;
                case 2:
                    collectedValues.MultiplyValues();
                    break;
                case 3:
                    collectedValues.PrintRandomItemFromTheList();
                    break;
                case 4:
                    collectedValues.PrintSortedNumbersDescending();
                    break;
                case 5:
                    collectedValues.PrintSortedNumbersAscending();
                    break;
                default:
                    Console.WriteLine("Invalid action. Please choose a valid action.");
                    break;
            }
        }

        Console.Write("Do you want to perform other actions? (Y/N)");
        var continueStatus = Console.ReadLine();
        repeatUserAction = continueStatus switch
        {
            "Y" => true,
            "N" => false,
            _ => null
        };

        if (repeatUserAction == null)
        {
            Console.WriteLine("Invalid user action. Restarting the process...");
        }
    }
}

while (true) {
    Console.Write("Enter 6 consecutive numbers separated by space: ");
    var numbers = Console.ReadLine();

    string[] input = numbers.Split(" ");
    List<decimal> collectedValues = new List<decimal>();
    if (input.Length < 6)
    {
        Console.WriteLine();
        Console.WriteLine("Missing argument, please enter 6 numbers separated by a space");
    }
    else
    {
        foreach (var item in input)
        {
            if (decimal.TryParse(item, out decimal result))
            {
                collectedValues.Add(result);
            }
            else
            {
                Console.WriteLine("Invalid argument detected.");
            }
        }

        if (!ConsecutiveNumbersValidator.Valid(collectedValues))
        {
            Console.WriteLine("Input error. The numbers are not consecutive.");
        }
        else
        {
            ExecuteUserAction(collectedValues);
        }
    }
}



