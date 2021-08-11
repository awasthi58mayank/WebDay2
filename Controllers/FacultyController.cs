using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectXBL;
using ProjectXDTO;
using ProjectXDAL;

namespace ActivityWebApi.Controllers
{
    public class FacultyController : ApiController
    {
        FacultyBL obj;

        [HttpGet]
        [ActionName("GetAllFaculties")]
        public HttpResponseMessage GetFaculties()
        {   
            try
            {
                obj = new FacultyBL();
                List<FacultyDTO> facLst = obj.GetFaculties();
                if (facLst != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(facLst));
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
                response.Content = new StringContent("Oops!!");
                return response;
            }
        }

        [HttpGet]
        [ActionName("GetCourseByFacultyName")]
        public HttpResponseMessage GetCoursesByFacultyName(string facname)
        {
            try
            {
                obj = new FacultyBL();
                List<CourseFacultyMappingDTO> facLst = obj.GetCoursesByFacultyName(facname);
                if (facLst != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(facLst));
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
                response.Content = new StringContent("Oops!!");
                return response;
            }
        }
       

    }

}

