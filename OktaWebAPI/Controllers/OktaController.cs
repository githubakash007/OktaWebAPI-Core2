using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okta.Core.Clients;

namespace OktaWebAPI.Controllers
{

    [Route("api/[controller]")]
    public class OktaController : Controller
    {
        //This APi key name in OKTA is "oktaWebApi"
        private readonly string token = "00k2Ltuw8RWyzAlRcgwyzLhf3L_1oww1VQ93hBOM2u";
        private readonly string domain = "https://dev-409691.oktapreview.com";

        // GET: api/Okta
        [HttpGet("getallusers")]
        public IList<string> GetAllUsers()
        {
            //Get an user based on the username  from okta server
            var usersClient = new UsersClient(token, new Uri(domain));
            IList<string> userNameList = new List<string>();

            foreach (var usr in usersClient)
            {
                userNameList.Add(usr.Profile.FirstName);
            }

            return userNameList;
        }

        [HttpGet("getuser")]
        public Okta.Core.Models.User GetUser()
        {

            //var usersClient1 = new UsersClient(token, new Uri(domain));
            //var rr = usersClient1.GetByUsername("testuser@testuser.com");
            //Get an user based on the username  from okta server
            var oktaClient = new OktaClient(token, new Uri(domain));
            var usersClient = oktaClient.GetUsersClient();
            var user = usersClient.GetByUsername("testuser@testuser.com");
            return user;
        }

        // POST: api/Okta
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var oktaClient = new OktaClient(token, new Uri(domain));

        }

        // PUT: api/Okta/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
