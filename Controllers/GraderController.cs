using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ProjectXBL;
using ProjectXDTO;

namespace ActivityWebApi.Controllers
{
    public class GraderController : ApiController
    {
        GraderBL objBAL;
        [HttpGet]
        [ActionName("GetPSNoFromGrader")]
        public HttpResponseMessage GetGradesFitered()
        {
            try
            {
                objBAL = new GraderBL();
                List<GraderDTO> graderList = objBAL.GetGradesFitered();
                if (graderList != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(graderList));
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
        [ActionName("GetGraderFromGrader")]
        public HttpResponseMessage GetGradesFromPSNo(int psno)
        {
            try
            {
                objBAL = new GraderBL();
                List<GraderDTO> graderFilteredList = objBAL.GetGradesFromPSNo(psno);
                if (graderFilteredList != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(graderFilteredList));
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
