using System;
using System.Threading.Tasks;
using AutoMapper;
using vipclass.products.Domain.Models.Signature;
using vipclass.products.Repository.Interface;
using vipclass.products.Services.Interface;

namespace vipclass.products.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICoursesRepository _coursesRepository;

        public CourseServices(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task Save(AddCourseSignature signature)
        {
            await _coursesRepository.Save(signature);
        }
    }
}
