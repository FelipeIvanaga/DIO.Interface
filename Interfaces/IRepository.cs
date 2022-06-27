namespace DIO.Interface.Interfaces
{
    public interface IReposotory<T>
    {
        List<T> List();
        T GetById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }

}