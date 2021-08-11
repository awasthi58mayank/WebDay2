
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectXDTO;
using ProjectXBL;
using Newtonsoft.Json;

namespace ActivityWebApi.Controllers
{
    public class CourseController : ApiController
    {
        CoursesBL objBAL;
        [HttpGet]
        [ActionName("GetAllCourses")]
        public HttpResponseMessage GetCourses()
        {
            try
            {
                objBAL = new CoursesBL();
                List<CourseDTO> courseList = objBAL.GetCourses();
                if (courseList != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(courseList));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("No Table Found");
                    return response;
                }

            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Oops!");
                return response;
            }
        }

        [HttpGet]
        [ActionName("GetFacultyByCID")]
        public HttpResponseMessage GetFacultyFromCId(string cid)
        {
            try
            {
                objBAL = new CoursesBL();
                List<CourseFacultyMappingDTO> courseList = objBAL.GetFacultyFromCId(cid);
                if (courseList != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(courseList));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("No Table Found");
                    return response;
                }

            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Oops!");
                return response;
            }
        }

    }
}

