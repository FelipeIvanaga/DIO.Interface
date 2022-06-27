public class Show : BaseEntity
{
    private Genre Genre { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    private int Year { get; set; }
    private bool Inactive { get; set; }

    public Show(int id, Genre genre, string title, string description, int year)
    {
        this.Id = id;
        this.Genre = genre;
        this.Title = title;
        this.Description = description;
        this.Year = year;
        this.Inactive = false;
    }

    public override string ToString()
    {
        string respose = "";
        respose += "Genre: " + this.Genre + Environment.NewLine;
        respose += "Title: " + this.Title + Environment.NewLine;
        respose += "Description: " + this.Description + Environment.NewLine;
        respose += "Year: " + this.Year + Environment.NewLine;
        respose += "Inactive: " + this.Inactive + Environment.NewLine;
        return respose;
    }

    public string returnTitle()
    {
        return this.Title;
    }

    public int returnId()
    {
        return this.Id;
    }

    public bool returnInactive()
    {
        return this.Inactive;
    }

    public void Inactivate()
    {
        this.Inactive = true;
    }
}