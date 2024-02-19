using Microsoft.AspNetCore.Mvc;
using Test.App.RepositoryService;
using Test.App.ViewModel;

namespace Test.App.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }

    public async Task<ActionResult<StudentVm>>  Index( CancellationToken cancellationToken)=>
              View(await studentRepository.GetAllAsync(cancellationToken));
    [HttpGet]
    public async Task<ActionResult<StudentVm>> CreateOrEdit(long id,CancellationToken cancellationToken)
    {
        if (id == 0) return View(new StudentVm());
        else return View(await studentRepository.GetByIdAsync(id, cancellationToken));
    }
    [HttpPost]
    public async Task<ActionResult<StudentVm>> CreateOrEdit(long id,StudentVm studentVm, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            await studentRepository.InsertAsync(studentVm, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await studentRepository.UpdateAsync(id,studentVm, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    public async Task<ActionResult<StudentVm>> Delete(long id,CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await studentRepository.DeleteAsync(id,cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }


}
