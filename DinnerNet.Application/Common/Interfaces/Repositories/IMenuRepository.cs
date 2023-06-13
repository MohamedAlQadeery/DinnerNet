using DinnerNet.Domain.MenuAggregate;

namespace DinnerNet.Application.Common.Interfaces.Repositories;

public interface IMenuRepository
{
    void CreateMenu(Menu menu);
}