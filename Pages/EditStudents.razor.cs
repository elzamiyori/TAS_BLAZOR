using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TASELZA.Models;
using TASELZA.Services;

namespace TASELZA.Pages
{
    public partial class EditStudents
    {
        public Students Student { get; set; } = new Students();

        [Inject]
        public IStudentService StudentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Student = await StudentService.GetById(int.Parse(Id));
        }
        protected async Task HandleValidSubmit()
        {
            Students result = await StudentService.Update(int.Parse(Id), Student);
            NavigationManager.NavigateTo("studentspage");
        }
    }
}