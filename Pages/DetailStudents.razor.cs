using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TASELZA.Models;
using TASELZA.Services;

namespace TASELZA.Pages
{
    public partial class DetailStudents
    {
        [Parameter]
        public string id { get; set; }
        [Inject]
        public IStudentService StudentService { get; set; }
        public Students Student { get; set; } = new Students();

        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Student = await StudentService.GetById(int.Parse(id));
        }
    }
}