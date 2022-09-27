using Microsoft.AspNetCore.Mvc;
using MVC_API_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC_API_Client.Controllers
{
    public class StudentController : Controller
    {
        string Baseurl = "https://localhost:7233";
        public async Task<ActionResult> Index()
        {
            List<Student> StudInfo = new List<Student>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Students");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var StudResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    StudInfo = JsonConvert.DeserializeObject<List<Student>>(StudResponse);

                }
                //returning the employee list to view  
                return View(StudInfo);
            }
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(Student e)
        {
            Student studobj = new Student();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(e),
              Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7233/api/Students", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studobj = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateStudent(int id)
        {
            Student stud = new Student();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7233/api/Students/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stud = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return View(stud);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateStudent(Student e)
        {
            Student receivedstud = new Student();

            using (var httpClient = new HttpClient())
            {
                #region
                //var content = new MultipartFormDataContent();
                //content.Add(new StringContent(reservation.Empid.ToString()), "Empid");
                //content.Add(new StringContent(reservation.Name), "Name");
                //content.Add(new StringContent(reservation.Gender), "Gender");
                //content.Add(new StringContent(reservation.Newcity), "Newcity");
                //content.Add(new StringContent(reservation.Deptid.ToString()), "Deptid");
                #endregion
                int id = e.RollNo;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(e)
         , Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7233/api/Students/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedstud = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            TempData["RollNo"] = id;
            Student e = new Student();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7233/api/Students/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return View(e);
        }


        [HttpPost]
        // [ActionName("DeleteStudent")]
        public async Task<ActionResult> DeleteStudent(Student e)
        {
            int rollno = Convert.ToInt32(TempData["RollNo"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7233/api/Students/" + rollno))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

    }
}
