#pragma warning disable IDE0062 // Make local function 'static'

string inputString = "29535123p487234875976457236458";

List<ulong> numbers = GetAllNumbers(inputString);

PrintMatrix(numbers);

PrintSumOfAllNumbers(numbers);


//Functions

List<ulong> GetAllNumbers(string inputString)
{
	List<ulong> allNumbers = new();

	for (int startIndex = 0; startIndex < inputString.Length - 1; startIndex++)
	{
		if (TryFindIndexOfTwin(inputString, startIndex, out int twinIndex))
		{
			string matchingNumber = inputString[startIndex..twinIndex];
			allNumbers.Add(Convert.ToUInt64(matchingNumber));
		}
	}

	return allNumbers;
}

/// <summary>
/// Tries to find the index of the next matching digit to the digit att the <paramref name="startIndex"/> position.
/// </summary>
/// <param name="inputString">The string to search in</param>
/// <param name="startIndex">Position in <paramref name="inputString"/>to start searching</param>
/// <param name="foundIndex">If successful this will contain the index for the twin</param>
/// <returns>Returns <c>True</c> if successfully found a match, otherwise <c>False</c></returns>
bool TryFindIndexOfTwin(string inputString, int startIndex, out int foundIndex)
{
	foundIndex = -1;
	char digitToMatch = inputString[startIndex];

	if (!char.IsDigit(digitToMatch))
	{
		return false;
	}
	else
	{
		for (int i = startIndex + 1; i < inputString.Length; i++)
		{
			char currentCharacter = inputString[i];

			if (!char.IsDigit(currentCharacter))
			{
				return false;
			}
			else if (digitToMatch.Equals(currentCharacter))
			{
				foundIndex = i + 1;
				return true;
			}
		}
		
		return false;
	}
}

void PrintMatrix(List<ulong> numbers)
{
	
}


void PrintSumOfAllNumbers(List<ulong> numbers)
{
	ulong sum = 0;

	foreach(int number in numbers)
	{
		sum += Convert.ToUInt64(number);
	}

	Console.WriteLine();
	Console.WriteLine($"Total: {sum}");
}
