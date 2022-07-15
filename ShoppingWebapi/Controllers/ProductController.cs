using ShoppingCore.Entities;
using RepositoryImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCore.BaseInterfaces;

namespace ShoppingWebapi.Controllers
{
    public class ProductController : ApiController
    {
        private IRepository<Products> _ProductsRepository = null;
        public ProductController()
        {
            this._ProductsRepository = new Repository<Products>();
        }
        [HttpGet]
        [Route("api/Product/Get")]
        public IEnumerable<Products> Get()
        {
            return _ProductsRepository.Get();
        }
    }
}
