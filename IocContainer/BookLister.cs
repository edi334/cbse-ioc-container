namespace IocContainer;

public class BookLister
{
    private readonly IBookRepository _bookRepository;

    public BookLister(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void ListMovies()
    {
        var movies = _bookRepository.GetBooks();

        foreach (var movie in movies)
        {
            Console.WriteLine(movie);
        }
    }
}