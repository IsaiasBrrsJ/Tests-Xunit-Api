namespace WebApiAndTestsxUnit.Domain.Model.User
{
    public interface IUserRepository<T> where T : class
    {
        bool Add(T User);

        bool Delete(int Id);

        bool Update(T User);

        IEnumerable<T> GetAll();

        T Get(int Id);

    }
}
