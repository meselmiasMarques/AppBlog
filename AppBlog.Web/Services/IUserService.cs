using AppBlog.Entities.Domain;

namespace AppBlog.Web.Services;

public interface IUserService
{
    Task<IEnumerable<User>?> GetUsers();

    Task AddUser(User user);

}