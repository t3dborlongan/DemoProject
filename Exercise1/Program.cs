using Common.Constants;
using Constants.Utils;

try
{
    using var reader = new StreamReader(SourceFiles.FILEDIFF);

    string? lineItem;

    while (!string.IsNullOrEmpty((lineItem = reader.ReadLine())))
    {
        Console.WriteLine(lineItem);
        string[] currentValue = lineItem.Split('\t', StringSplitOptions.RemoveEmptyEntries);

        DirectoryHelper.PrepareForDeployment(currentValue);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


