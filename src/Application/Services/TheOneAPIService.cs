public class TheOneAPIService
{
    private readonly ITheOneAPIHandler _handler;
    public TheOneAPIService(ITheOneAPIHandler handler)
    {
        _handler = handler;
    }

    public async Task<string> GetBooks()
    {
        return await _handler.GetBooks();
    }
}