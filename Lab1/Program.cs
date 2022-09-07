#pragma warning disable IDE0062 // Make local function 'static'

string inputString = "29535123p48723487597645723645";

List<string> numbers = GetAllMatchingNumberParts(inputString);

PrintMatrix(inputString, numbers);

PrintSumOfAllNumbers(numbers);

Console.ReadKey(true);



//Functions

List<string> GetAllMatchingNumberParts(string inputString)
{
    List<string> allNumbers = new();

    for (int startIndex = 0; startIndex < inputString.Length - 1; startIndex++)
    {
        if (TryFindIndexOfTwin(inputString, startIndex, out int twinIndex))
        {
            string matchingNumber = inputString[startIndex..twinIndex];
            allNumbers.Add(matchingNumber);
        }
    }

    return allNumbers;
}

bool TryFindIndexOfTwin(string inputString, int startIndex, out int foundIndex)
{
    foundIndex = -1;
    char digitToMatch = inputString[startIndex];
            
    for (int i = startIndex + 1; i < inputString.Length; i++)
    {
        char currentCharacter = inputString[i];

        if (TryCheckDigitsForMatch(digitToMatch, currentCharacter, out bool isMatch))
        {
            if (isMatch)
            {
                foundIndex = i + 1;
                return true;
            }
        }
        else return false;
    }
        
    return false;
}

bool TryCheckDigitsForMatch(char firstDigit, char secondDigit, out bool isMatch)
{
    isMatch = false;

    if (char.IsDigit(firstDigit) && char.IsDigit(secondDigit))
    {
        if (firstDigit.Equals(secondDigit))
        {
            isMatch = true;			
        }
    }
    else return false;

    return true;
}

void PrintMatrix(string inputString, List<string> listOfNumbers)
{
    foreach (string number in listOfNumbers)
    {
        PrintColoredRow(inputString, number);
        Console.WriteLine();
    }	
}

void PrintColoredRow(string inputString, string number)
{
    int positionOfNumber = inputString.IndexOf(number);

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(inputString[0..positionOfNumber]);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(inputString[positionOfNumber..(positionOfNumber + number.Length)]);

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(inputString[(positionOfNumber + number.Length)..^0]);
}

void PrintSumOfAllNumbers(List<string> listOfNumbers)
{
    ulong sum = 0;

    foreach(string number in listOfNumbers)
    {
        sum += Convert.ToUInt64(number);
    }

    Console.WriteLine();
    Console.WriteLine($"Total: {sum}");
}
