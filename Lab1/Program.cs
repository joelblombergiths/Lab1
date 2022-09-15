using System.Numerics;

BigInteger sum;

do
{
    Console.WriteLine("Welcome to Fredrik's Fantastic Figit Finder");

    Console.WriteLine("Enter a Figit Sequence:");
    string inputString = Console.ReadLine();

    sum = 0;

    Console.Clear();

    for (int startIndex = 0; startIndex < inputString.Length - 1; startIndex++)
    {
        if (!char.IsDigit(inputString[startIndex])) continue;

        for (int next = startIndex + 1; next < inputString.Length; next++)
        {
            if (char.IsDigit(inputString[next]))
            {
                if (inputString[startIndex].Equals(inputString[next]))
                {
                    string matchingNumber = inputString[startIndex..(next + 1)];

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(inputString[0..startIndex]);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(matchingNumber);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(inputString[(startIndex + matchingNumber.Length)..^0]);

                    sum = BigInteger.Add(sum, BigInteger.Parse(matchingNumber));

                    break;
                }
            }
            else break;
        }
    }

    Console.WriteLine();
    if (sum > 0) Console.WriteLine($"Total: {sum}");
    else Console.WriteLine("Sequence Contained no Figits");

    Console.WriteLine();
    Console.WriteLine("Press ESC to Quit or the Any key to enter a new sequence.");

    if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape)) Environment.Exit(0);
    
    Console.Clear();
}
while (true);
