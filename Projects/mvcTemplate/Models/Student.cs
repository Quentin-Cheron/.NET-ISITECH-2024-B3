
namespace mvc.Models;

public enum Major
{
    Math,
    Science,
    English,
    History
}

public class Student
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

    public int Age { get; set; }

    public double GPA { get; set; }

    public Major Major { get; set; }

    public DateTime AdmissionDate { get; set; }
}