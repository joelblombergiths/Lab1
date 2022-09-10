#pragma warning disable IDE0062 // Make local function 'static'
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.

//29535123p48723487597645723645

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

    List<string> numbers = GetAllMatchingNumberParts(inputString);

    if (numbers.Count > 0)
    {      
        PrintAllNumbers(inputString, numbers);

        PrintSumOfAllNumbers(numbers);
    }
    else Console.WriteLine("Sequence Contained no Figits");
}

List<string> GetAllMatchingNumberParts(string inputString)
{
    List<string> allNumbers = new();

    for (int startIndex = 0; startIndex < inputString.Length - 1; startIndex++)
    {
        if (TryFindIndexOfTwinDigit(inputString, startIndex, out int twinIndex))
        {
            string matchingNumber = inputString[startIndex..twinIndex];
            allNumbers.Add(matchingNumber);
        }
    }

    return allNumbers;
}

bool TryFindIndexOfTwinDigit(string inputString, int startIndex, out int foundIndex)
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

void PrintAllNumbers(string inputString, List<string> listOfNumbers)
{
    Console.Clear();

    int startIndex = 0;
    foreach (string number in listOfNumbers)
    {
        PrintColoredRow(inputString, number, startIndex, out int previousNumberLocation);
        startIndex = previousNumberLocation + 1;

        Console.WriteLine();
    }	
}

void PrintColoredRow(string inputString, string number, int startIndex, out int positionOfNumber)
{
    positionOfNumber = inputString.IndexOf(number, startIndex);

    Console.ForegroundColor = ConsoleColor.White;

    string everythingBeforeTheNumber = inputString[0..positionOfNumber];
    Console.Write(everythingBeforeTheNumber);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(number);
    //string theNumber = inputString[positionOfNumber..(positionOfNumber + number.Length)];

    Console.ForegroundColor = ConsoleColor.White;

    string everythingAfterTheNumber = inputString[(positionOfNumber + number.Length)..^0];
    Console.Write(everythingAfterTheNumber);
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
