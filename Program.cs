
ShowsRepository repository = new ShowsRepository();

string userOption = GetUserOption();

while (userOption != "X")
{
    switch (userOption)
    {
        case "1":
            ListShows();
            break;
        case "2":
            InsertShow();
            break;
        case "3":
            UpdateShow();
            break;
        case "4":
            InactivateShow();
            break;
        case "5":
            ViewShow();
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
    userOption = GetUserOption();
}

void ListShows()
{
    Console.WriteLine("List shows");

    var list = repository.List();

    if (list.Count == 0)
    {
        Console.WriteLine("Empty list");
        return;
    }

    foreach (Show show in list)
    {
        var inactive = show.returnInactive();
        if (!inactive)
        {
            Console.WriteLine("#Id {0}: - {1}", show.returnId(), show.returnTitle());
        }
    }

}

void ViewShow()
{
    Console.WriteLine("View show");

    Console.Write("Insert show id: ");
    int showId = int.Parse(Console.ReadLine()!);

    Show show = repository.GetById(showId);
    Console.WriteLine(show.ToString());
}

void InsertShow()
{
    Console.WriteLine("Insert Show");

    foreach (int i in Enum.GetValues(typeof(Genre)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
    }
    Console.Write("Insert a genre from those above: ");
    int genreEntry = int.Parse(Console.ReadLine()!);


    Console.Write("Insert the Title: ");
    string titleEnrtry = Console.ReadLine()!;

    Console.Write("Insert the Description: ");
    string descriptionEntry = Console.ReadLine()!;

    Console.Write("Insert the Year of launch: ");
    int yearEntry = int.Parse(Console.ReadLine()!);

    Show newShow = new Show(id: repository.NextId(), genre: (Genre)genreEntry, title: titleEnrtry, description: descriptionEntry, year: yearEntry);

    repository.Insert(newShow);
}

void UpdateShow()
{
    Console.WriteLine("Update show");

    Console.Write("Insert show id: ");
    int showId = int.Parse(Console.ReadLine()!);

    foreach (int i in Enum.GetValues(typeof(Genre)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
    }
    Console.Write("Insert a genre from those above: ");
    int genreEntry = int.Parse(Console.ReadLine()!);


    Console.Write("Insert the Title: ");
    string titleEnrtry = Console.ReadLine()!;

    Console.Write("Insert the Description: ");
    string descriptionEntry = Console.ReadLine()!;

    Console.Write("Insert the Year of launch: ");
    int yearEntry = int.Parse(Console.ReadLine()!);

    Show updatedShow = new Show(id: showId, genre: (Genre)genreEntry, title: titleEnrtry, description: descriptionEntry, year: yearEntry);

    repository.Update(showId, updatedShow);

}

void InactivateShow()
{
    Console.WriteLine("Delete show");

    Console.Write("Insert Show id: ");
    int showId = int.Parse(Console.ReadLine()!);

    repository.Delete(showId);
}

static string GetUserOption()
{
    Console.WriteLine();
    Console.WriteLine("Tv shows!");
    Console.WriteLine("Choose your desired operation");

    Console.WriteLine("1 - List Shows");
    Console.WriteLine("2 - Add new Show");
    Console.WriteLine("3 - Update Show");
    Console.WriteLine("4 - Delete Show");
    Console.WriteLine("5 - View Show");
    Console.WriteLine("C - Clear console");
    Console.WriteLine("X - Exit");
    Console.WriteLine();

    string userOption = Console.ReadLine()!.ToUpper();
    Console.WriteLine();
    return userOption;
}