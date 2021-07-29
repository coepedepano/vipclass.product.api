using System;
using System.Threading.Tasks;
using vipclass.products.Domain.Models.Signature;

namespace vipclass.products.Services.Interface
{
    public interface ICourseServices
    {
        public Task Save(AddCourseSignature signature);
    }
}
