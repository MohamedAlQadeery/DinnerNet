using DinnerNet.Domain.Entities;

namespace DinnerNet.Application.Common.Interfaces.Repositories;
public interface IUserRepository
{
    User GetUserByEmail(string email);

    void AddUser(User user);
}