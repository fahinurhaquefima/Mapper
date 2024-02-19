using AutoMapper;
using Test.App.Models;

namespace Test.App.ViewModel;
[AutoMap(typeof(Student),ReverseMap =true)]
public class StudentVm

{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Eamil { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

}


