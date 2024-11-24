namespace IocContainer;

public interface IBookRepository
{
    List<Book> GetBooks();
}
public class BookRepository : IBookRepository
{
    private readonly IDataBase _dataBase;

    public BookRepository(IDataBase dataBase)
    {
        _dataBase = dataBase;
    }

    public List<Book> GetBooks()
    {
        return _dataBase.RetrieveBooks();
    }
}