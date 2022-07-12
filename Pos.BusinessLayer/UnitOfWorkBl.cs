using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.BusinessLayer;
public class UnitOfWorkBl : IUnitOfWorkBl
{
    public UnitOfWorkBl(
        IUserBl user
        , IRoleBl role
        , IProductBl productBl
    )
    {
        this.Role = role;
        this.User = user;
        this.Product = productBl;
    }
    public IUserBl User { get; }

    public IRoleBl Role { get; }

    public IProductBl Product {get;}
}
