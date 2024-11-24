namespace IocContainer;

public class Book
{
    public string Name { get; set; }
    public string Author { get; set; }
    public DateTime PublishDate { get; set; }
    public string Language { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Author: {Author}, Publish Date: {PublishDate}, Language: {Language}";
    }
}