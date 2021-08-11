using ProjectXBL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivityWebApi.Controllers
{
    public class CoController : ApiController
    {
        CoBL obj;
        [HttpPost]
        [ActionName("AddCourses")]
        public HttpResponseMessage AddNewCourse(CourseDTO courseObj)
        {
            try
            {
                obj = new CoBL();
                int retValue = obj.AddNewCourse(courseObj);
                if (retValue == 1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Course Inserted");
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else if (retValue == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("CourseID is already present!");
                    return response;
                }
                else if (retValue == -2)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("CourseTItle is already present!");
                    return response;
                }
                else if (retValue == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Please input all values");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    response.Content = new StringContent("");
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
