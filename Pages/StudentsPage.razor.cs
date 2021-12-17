using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TASELZA.Models;
using TASELZA.Services;

namespace TASELZA.Pages
{
    public partial class StudentsPage
    {
        public List<Students> Student { get; set; } = new List<Students>();
        [Inject]
        public IStudentService StudentService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Student = (await StudentService.GetAll()).ToList();
        }
    }
}