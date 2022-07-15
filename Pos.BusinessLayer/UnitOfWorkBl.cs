using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.BusinessLayer;
public class UnitOfWorkBl : IUnitOfWorkBl
{
    public UnitOfWorkBl(
        IUserBl user
        , IRoleBl role
        , IProductBl productBl
        , ISaleBl saleBl
        , IStoreBl storeBl
    )
    {
        this.Role = role;
        this.User = user;
        this.Product = productBl;
        this.Store = storeBl;
        this.Sale = saleBl;
    }
    public IUserBl User { get; }

    public IRoleBl Role { get; }

    public IProductBl Product { get; }

    public ISaleBl Sale { get; }

    public IStoreBl Store { get;}
}
