using FacultyApp_RSWEB.Models;

namespace FacultyApp_RSWEB.ViewModels
{
    public class StudentsFilter
    {
        public IList<Student>? Students { get; set; }
        
        public string? FullName { get; set; }

        public string? studentID { get; set; }
    }
}
