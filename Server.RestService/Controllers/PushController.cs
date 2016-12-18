using Firebase.Database;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server.RestService.Controllers
{
    [RoutePrefix("api/push")]
    public class PushController : ApiController
    {

        [HttpPost, Route("to-all")]
        public async Task<IHttpActionResult> All([FromBody]string message)
        {
            //string postUrl = "";
            //NameValueCollection postData = new NameValueCollection()
            //{
            //    { "ime", "semin" },
            //    { "prezime", "music" }
            //};
            //string responsePageSource = "";
            //using (WebClient client = new WebClient())
            //{
            //    responsePageSource = System.Text.Encoding.UTF8.GetString(client.UploadValues(postUrl, postData));
            //}

            string serverKey = ConfigurationManager.AppSettings["FirebaseServerKey"];

            //FCMClient client = new FCMClient(serverKey);
            //var firebaseMessage = new Message()
            //{
            //    To = "/topics/android",
            //    Data = new Dictionary<string, string>
            //    {
            //        { "ime", "Semin" },
            //        { "prezime", "Musić" }
            //    }
            //};

            //var result = await client.SendMessageAsync(firebaseMessage);
            //return Ok(result);

            string baseUrl = ConfigurationManager.AppSettings["FirebaseBaseUrl"];
            FirebaseClient firebase = new FirebaseClient(baseUrl);

            // Add new item directly to the specified location (this will overwrite whatever data already exists at that location)
            //await firebase.Child("podaci").PutAsync(new[] {
            //    new { ime = message },
            //    new { ime = "Neko" },
            //    new { ime = "Drugo" }
            //});

            // Add new item to list of data and let the client generate new key for you (done offline)
            var a = await firebase.Child("podaci").PostAsync(new { ime = message });

            return Ok(a);
        }


        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
