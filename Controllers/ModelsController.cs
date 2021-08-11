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
    public class ModelsController : ApiController
    {
        ModelBL objBAL;
        [HttpGet]
        [ActionName("GetAllModelDetails")]
        public HttpResponseMessage GetModelDetails()
        {
            try
            {
                objBAL = new ModelBL();
                List<ModelDTO> modelList = objBAL.GetModelDetails();
                if (modelList != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(modelList));
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

