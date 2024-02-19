using AutoMapper;
using Test.App.DatabaseContext;
using Test.App.Models;
using Test.App.Service;
using Test.App.ViewModel;

namespace Test.App.RepositoryService;

public class StudentRepository : RepositoryService<Student, StudentVm>,IStudentRepository
{
    public StudentRepository(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
