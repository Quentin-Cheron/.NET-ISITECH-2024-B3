namespace mvc.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public int Age { get; set; }

    public double GPA { get; set; }

    public Major Major { get; set; }

    public DateTime AdmissionDate { get; set; }
}