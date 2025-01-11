using AppBlog.Entities.Domain;

namespace AppBlog.Web.Services;

public class UserService : IUserService
{
    private HttpClient _httpClient;
    private ILogger _logger;

    public UserService(HttpClient httpClient, ILogger logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<User>?> GetUsers()
    {
        try
        {
            var users = await _httpClient
                .GetFromJsonAsync<IEnumerable<User>>("v1/user");
            return users;
        }
        catch (Exception e)
        {
            _logger.LogError("Não foi possível consultar a api users");
            throw;
        }
    }
}