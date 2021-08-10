using System.Threading.Tasks;
using vipclass.products.Domain.Models;
using vipclass.products.Domain.Models.Signature;

namespace vipclass.products.Repository.Interface
{
    public interface ICoinsRepository : IGenericRepository<Coins>
    {
        Task<int> Add(AddCoinsSignature entity);
    }
}
