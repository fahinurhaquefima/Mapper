using Test.App.Models;
using Test.App.Service;
using Test.App.ViewModel;

namespace Test.App.RepositoryService;

public interface IStudentRepository: IRepositoryService<Student,StudentVm>
{
}
