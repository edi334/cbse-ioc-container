// See https://aka.ms/new-console-template for more information

using IocContainer;

var configPath = "config.xml";
var container = new IocContainer.IocContainer();
container.LoadConfig(configPath);

var bookLister = container.Resolve<BookLister>("bookLister");
bookLister.ListMovies();