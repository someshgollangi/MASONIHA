using RepositoryImplementation;
using ShoppingCore.BaseInterfaces;
using ShoppingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingWebapi.Controllers
{
    public class AccountController : ApiController
    {
        private IAccountRepository _Account = null;
        public AccountController()
        {
            this._Account = new AccountRepository();
        }
        [HttpPost]
        [Route("api/Account/Register")]
        public IHttpActionResult Register(User_tbl user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            user = _Account.Register(user);
            user=_Account.Insert(user);
            return Ok(user);
        }

        [HttpPost]
        [Route("api/Account/Login")]
        public IHttpActionResult Login(User_tbl user)
        {
            user= _Account.Login(user);
            return Ok(user);
        }

    }
}
