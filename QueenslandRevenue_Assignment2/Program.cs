/*
    This program is for: Introduction to Programming
    Assignment 2 - Queensland Revenue
    Created by: Wakana Gushi 
    Created on: 23/10/2024
    Last modified: 06/11/2024
 */
using System;
using static System.Console;
class QueenslandRevenue
{
    static void Main(string[] args)
    {
        //Decrale variables
        int lastContestantsNum;
        int currentContestantsNum;
        const int LOWLIMIT = 0;
        const int HIGHLIMIT = 30;
        int twiceOfLastNum;
        char[] validCodes = new char[4] { 'S', 'D', 'M', 'O' };
        string[] talentTypes = new string[4] { "Singing", "Dancing", "Musical instrument", "Other" };
        string[] names;
        char[] codes;
        char entryCode;
        int x;
        int y;
        bool codeFound = false;
        int[] codeCounts = new int[validCodes.Length];
        bool quit = false;

        // prompt user for the number of contestants from last year's competition. 
        WriteLine("Please enter the number of contestants that participated in last year's competition.");
        lastContestantsNum = Convert.ToInt32(ReadLine());
        // validate the entry for the number of contestants last year.
        while (lastContestantsNum < LOWLIMIT || lastContestantsNum > HIGHLIMIT)
        {
            WriteLine("Invalid number. Please enter a valid number (between 1 and 30).");
            lastContestantsNum = Convert.ToInt32(ReadLine());
        }

        // prompt user for the number of contestants that participated in this year's competition. 
        WriteLine("Please enter the number of contestants that participated in this year's competition.");
        currentContestantsNum = Convert.ToInt32(ReadLine());
        // validate the entry for the number of contestants this year.
        while (currentContestantsNum < LOWLIMIT || currentContestantsNum > HIGHLIMIT)
        {
            WriteLine("Invalid number. Please enter a valid number (between 1 and 30)");
            currentContestantsNum = Convert.ToInt32(ReadLine());
        }

        // Display input data
        WriteLine("\nNumber of contestants");
        WriteLine("Last year: {0}", lastContestantsNum);
        WriteLine("This year: {0}", currentContestantsNum);

        // Display stats based on the numbers entered.
        twiceOfLastNum = lastContestantsNum * 2;
        if (currentContestantsNum > twiceOfLastNum)
        {
            WriteLine("\nThe competition is more than twice as big this year!\n");
        }
        else if ((currentContestantsNum >= lastContestantsNum) && (currentContestantsNum <= twiceOfLastNum))
        {
            WriteLine("\nThe competition is bigger than ever!\n");
        }
        else
        {
            WriteLine("\nA tighter race this year! Come out and cast your vote!\n");
        }

        //Prompt user for contestant's name and a code for type of talent
        WriteLine("For each entrant in this years competition, please enter the contestant's name and the code that corresponds with their talent.");
        WriteLine("Code: S (Singing), D (Dancing), M (Musical instrument), O (Other)");
        //set array lengths 
        names = new string[currentContestantsNum];
        codes = new char[currentContestantsNum];

        //store names and codes in arrays
        for (x = 0; x < currentContestantsNum; ++x)
        {
            Write("\nName {0} >> ", x + 1);
            names[x] = ReadLine();
            Write("Talent type code for name {0} >> ", x + 1);
            entryCode = Convert.ToChar(ReadLine());
            codeFound = false;

            while (!codeFound)
            {
                // validate the entered code
                for (y = 0; (y < validCodes.Length) && !codeFound; ++y)
                {
                    if (entryCode == validCodes[y])
                    {
                        codes[x] = entryCode;
                        codeFound = true;
                    }
                }
                // Re - prompt the code when entered code is invalid
                if (!codeFound)
                {
                    WriteLine("\nInvalid input. Please enter a valid code.");
                    Write("Talent type code for name {0} >> ", x + 1);
                    entryCode = Convert.ToChar(ReadLine());
                }
            }
        }

        //Display a count of each type of talent.
        WriteLine("\nNumber of contestants for each category. ");
        for (x = 0; x < validCodes.Length; ++x)
        {
            for (y = 0; y < names.Length; ++y)
            {
                if (validCodes[x] == codes[y])
                {
                    ++codeCounts[x];
                }
            }
            WriteLine("{0} ({1}): {2} ", talentTypes[x], validCodes[x], codeCounts[x]);
        }

        do
        {
            //Prompt user for a talent code to see the list of contestants for that category.
            Write("\nEnter talent code to see the list of contestants for that category. Enter \"#\" to quit. >> ");
            entryCode = Convert.ToChar(ReadLine());
            codeFound = false;
            if (entryCode == '#')
            {
                quit = true;
                break;
            }

            while (!codeFound)
            {
                // validate the entered code
                for (x = 0; (x < validCodes.Length) && !codeFound; ++x)
                {
                    if (entryCode == validCodes[x])
                    {
                        codeFound = true;
                        WriteLine("\nList of contestants for {0}", talentTypes[x]);
                    }
                }
                // Re - prompt the code when entered code is invalid
                if (!codeFound)
                {
                    WriteLine("\nInvalid input. ");
                    Write("Please enter a valid talent code to see the list of contestants. Enter \"#\" to quit. >> ");
                    entryCode = Convert.ToChar(ReadLine());
                    if (entryCode == '#')
                    {
                        quit = true;
                        break;
                    }
                }
                //Display the list of contestants in entered type
                for (y = 0; y < names.Length; ++y)
                {
                    if (entryCode == codes[y])
                    {
                        WriteLine("{0}", names[y]);
                    }
                }
            }
        }
        while (!quit);

        //Exit the program when # is entered
        WriteLine("\nQuit the program.");
    }
}
