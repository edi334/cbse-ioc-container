namespace IocContainer;

public interface IDataBase
{
    List<Book> RetrieveBooks();
}
public class InMemoryDatabase : IDataBase
{
    private readonly INetworkCommunicator _networkCommunicator;

    public InMemoryDatabase(INetworkCommunicator networkCommunicator)
    {
        _networkCommunicator = networkCommunicator;
    }

    public List<Book> RetrieveBooks()
    {
        var connectedToNetwork = _networkCommunicator.ConnectionEstablished();
        if (connectedToNetwork)
        {
            return new List<Book>
            {
                new Book { Name = "To Kill a Mockingbird", Author = "Harper Lee", PublishDate = new DateTime(1960, 7, 11), Language = "English" },
                new Book { Name = "1984", Author = "George Orwell", PublishDate = new DateTime(1949, 6, 8), Language = "English" },
                new Book { Name = "Don Quixote", Author = "Miguel de Cervantes", PublishDate = new DateTime(1605, 1, 16), Language = "Spanish" },
                new Book { Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublishDate = new DateTime(1925, 4, 10), Language = "English" },
                new Book { Name = "Les Misérables", Author = "Victor Hugo", PublishDate = new DateTime(1862, 4, 3), Language = "French" }
            };
        }

        Console.WriteLine("Connection to the network failed!");
        return new List<Book>();
    }
}

public class SQLDatabase : IDataBase
{
    private readonly INetworkCommunicator _networkCommunicator;

    public SQLDatabase(INetworkCommunicator networkCommunicator)
    {
        _networkCommunicator = networkCommunicator;
    }

    public List<Book> RetrieveBooks()
    {
        var connectedToNetwork = _networkCommunicator.ConnectionEstablished();
        if (connectedToNetwork)
        {
            return new List<Book>
            {
                new Book { Name = "Moromeții", Author = "Marin Preda", PublishDate = new DateTime(1955, 1, 1), Language = "Romanian" },
                new Book { Name = "Enigma Otiliei", Author = "George Călinescu", PublishDate = new DateTime(1938, 1, 1), Language = "Romanian" },
                new Book { Name = "Ion", Author = "Liviu Rebreanu", PublishDate = new DateTime(1920, 1, 1), Language = "Romanian" },
                new Book { Name = "Baltagul", Author = "Mihail Sadoveanu", PublishDate = new DateTime(1930, 1, 1), Language = "Romanian" },
                new Book { Name = "Ultima noapte de dragoste, întâia noapte de război", Author = "Camil Petrescu", PublishDate = new DateTime(1930, 1, 1), Language = "Romanian" }
            };
        }

        Console.WriteLine("Connection to the network failed!");
        return new List<Book>();
    }
}