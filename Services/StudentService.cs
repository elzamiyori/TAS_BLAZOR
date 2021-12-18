using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TASELZA.Models;

namespace TASELZA.Services
{
    public class StudentService : IStudentService
    {
        private HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Students>> GetAll()
        {
            var results = await _httpClient.GetFromJsonAsync<IEnumerable<Students>>("api/Student");
            return results;
        }
        public async Task<Students> GetById(int id){
            var results = await _httpClient.GetFromJsonAsync<Students>($"api/Student/{id}");
            return results;
        }
        public async Task<Students> Update(int id, Students employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Student/{id}",employee);
            if (response.IsSuccessStatusCode){
                return await JsonSerializer.DeserializeAsync<Students>(await response.Content.ReadAsStreamAsync());
            }
            else
            {
                throw new Exception("Gagal update data employee");
            }
        }
    }
}