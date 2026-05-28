public interface ITheOneAPIHandler
{
    Task<string> GetBooks();
    Task<List<string>> GetMovies();
}