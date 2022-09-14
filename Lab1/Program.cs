using System.Numerics;

bool isProgramRunning = true;

do
{
    FindFigits();

    Console.WriteLine();
    Console.WriteLine("Press ESC to Quit or the Any key to enter a new sequence.");

    if (Console.ReadKey(true).Key == ConsoleKey.Escape) isProgramRunning = false;
    
    Console.Clear();
}
while (isProgramRunning);


void FindFigits()
{
    Console.WriteLine("Welcome to Fredrik's Fantastic Figit Finder");

    string inputString = RequestUserInput();

    List<string> numbers = GetAllMatchingNumbers(inputString);

    if (numbers.Count > 0)
    {      
        PrintAllNumbers(inputString, numbers);

        PrintSumOfAllNumbers(numbers);
    }
    else Console.WriteLine("Sequence Contained no Figits");
}

string RequestUserInput()
{
    string input;
    bool isValidInput;

    do
    {
        Console.WriteLine("Enter a Figit Sequence:");
        input = Console.ReadLine();

        isValidInput = !string.IsNullOrEmpty(input);
        if (!isValidInput)
        {
            Console.WriteLine("You can better than that...");
        }
    }
    while (!isValidInput);

    return input;
}

List<string> GetAllMatchingNumbers(string inputString)
{
    List<string> allMatchingNumbers = new();

    for (int startIndex = 0; startIndex < inputString.Length - 1; startIndex++)
    {
        if (TryFindNextIndexOfTwinDigit(inputString, startIndex, out int twinIndex))
        {
            string matchingNumber = inputString[startIndex..twinIndex];
            allMatchingNumbers.Add(matchingNumber);
        }
    }

    return allMatchingNumbers;
}

bool TryFindNextIndexOfTwinDigit(string inputString, int startIndex, out int foundIndex)
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

void PrintAllNumbers(string originalString, List<string> listOfNumbers)
{
    Console.Clear();

    int startIndex = 0;
    foreach (string number in listOfNumbers)
    {
        PrintRowWithNumberColored(originalString, number, startIndex, out int previousNumberLocation);
        startIndex = previousNumberLocation + 1;

        Console.WriteLine();
    }	
}

void PrintRowWithNumberColored(string row, string number, int startIndex, out int positionOfNumber)
{   
    positionOfNumber = row.IndexOf(number, startIndex);

    Console.ForegroundColor = ConsoleColor.White;

    string everythingBeforeNumber = row[0..positionOfNumber];
    Console.Write(everythingBeforeNumber);
    
    Console.ForegroundColor = ConsoleColor.Green;    

    Console.Write(number);

    Console.ForegroundColor = ConsoleColor.White;

    string everythingAfterNumber = row[(positionOfNumber + number.Length)..^0];
    Console.Write(everythingAfterNumber);
}

void PrintSumOfAllNumbers(List<string> listOfNumbers)
{
    BigInteger sum = 0;

    foreach(string number in listOfNumbers)
    {
        sum += BigInteger.Parse(number);
    }

    Console.WriteLine();
    Console.WriteLine($"Total: {sum}");
}
