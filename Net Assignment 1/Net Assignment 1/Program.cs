string file = Convert.ToString(Environment.CurrentDirectory);

file = file.Substring(0, file.Length - 16);
file = String.Concat(file, "Files/TextFile1.txt");
file = file.Replace("\\", "/");

string userInput = "";

while (userInput != "0")
{
    Console.WriteLine("Press 1 to read over all tickets | Press 2 to enter data for a new ticket | Press 0 to exit");
    userInput = Console.ReadLine();
    if (userInput == "1")
    {
        StreamReader sr = new StreamReader(file);
        sr.ReadLine();
        Console.WriteLine(sr.ReadToEnd());
        sr.Close();
    }

    if (userInput == "2")
    {
        StreamWriter sw = new StreamWriter(file, true);
        Console.WriteLine("Enter the ticket ID");
        string ticketID = Console.ReadLine();
        Console.WriteLine("Enter the ticket status");
        string status = Console.ReadLine();
        Console.WriteLine("Enter a summary of the ticket");
        string summary = Console.ReadLine();
        Console.WriteLine("Enter the priority of the ticket");
        string priority = Console.ReadLine();
        Console.WriteLine("Enter the name of preson who submitted the ticket");
        string personWhoSubmitted = Console.ReadLine();
        Console.WriteLine("Enter the name of the person who is assigned to the ticket");
        string personWhoIsAssigned = Console.ReadLine();

        Console.WriteLine("One at a time enter the names of the people who are watching the ticket");
        List<string> peopleWhoAreWatching = new List<string>();
        string watchingInput = "";
        do
        {
            watchingInput = Console.ReadLine();
            peopleWhoAreWatching.Add(watchingInput);
            if (watchingInput != "0")
            {
                Console.WriteLine("Enter the next name or enter 0 to exit");
            }
        } while (watchingInput != "0");
        peopleWhoAreWatching.RemoveAt(peopleWhoAreWatching.Count - 1);


        // Writting to the text file
        string forTextFileOne = string.Format("{0},{1},{2},{3},{4},{5},", ticketID, status, summary, priority,
            personWhoSubmitted, personWhoIsAssigned);
        string forTextFileTwo = string.Join('|', peopleWhoAreWatching);
        string forTextFileFinal = string.Concat(forTextFileOne, forTextFileTwo);
        sw.WriteLine(forTextFileFinal);
        sw.Close();
    }
}
