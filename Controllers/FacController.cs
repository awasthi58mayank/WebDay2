using Newtonsoft.Json;
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
    public class FacController : ApiController
    {
        public class FacultyController : ApiController
        {
            FacBL obj;
            [HttpPost]
            [ActionName("AddFaculties")]
            public HttpResponseMessage AddNewFaculty(FacultyDTO facObj)
            {
                try
                {
                    obj = new FacBL();
                    int retValue = obj.AddNewFaculty(facObj);
                    if (retValue == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Faculty Inserted");
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (retValue == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("PSNO is already present!");
                        return response;
                    }
                    else if (retValue == -2)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Faculty EmailID is already present!");
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
                catch (Exception ex)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Something went wrong"));
                    return response;
                }
            }
        }
    }
}
