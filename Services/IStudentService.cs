using System.Collections.Generic;
using System.Threading.Tasks;
using TASELZA.Models;

namespace TASELZA.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAll();
        
        Task<Students> GetById(int id);
    }
}