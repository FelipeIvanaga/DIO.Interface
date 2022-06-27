using DIO.Interface.Interfaces;

public class ShowsRepository : IReposotory<Show>
{
    private List<Show> showsList = new List<Show>();

    public void Delete(int id)
    {
        showsList[id].Inactivate();
    }

    public Show GetById(int id)
    {
        return showsList[id];
    }

    public void Insert(Show entity)
    {
        showsList.Add(entity);
    }

    public List<Show> List()
    {
        return showsList;
    }

    public int NextId()
    {
        return showsList.Count();
    }

    public void Update(int id, Show entity)
    {
        showsList[id] = entity;
    }
}