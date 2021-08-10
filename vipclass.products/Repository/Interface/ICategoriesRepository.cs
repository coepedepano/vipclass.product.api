using System.Threading.Tasks;
using vipclass.products.Domain.Models;
using vipclass.products.Domain.Models.Signature;

namespace vipclass.products.Repository.Interface
{
    public interface ICategoriesRepository : IGenericRepository<Categories>
    {
        Task<int> Add(AddCategoriesSignature entity);
    }
}
