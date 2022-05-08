using FacultyApp_RSWEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacultyApp_RSWEB.ViewModels
{
    public class CourseTitleViewModel
    {
        public IList<Course>? Courses { get; set; }
        public SelectList? Programmes { get; set; }

        public SelectList? Semesters { get; set; }

        public string? Programme { get; set; }

        public string? Title { get; set; }

        public int Semester { get; set; }

    }

}
