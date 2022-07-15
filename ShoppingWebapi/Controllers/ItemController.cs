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
    public class ItemController : ApiController
    {
        private IItemRepository _SubCategoryList = null;
        public ItemController()
        {
            this._SubCategoryList = new ItemRepository();
        }
        [HttpGet]
        [Route("api/Item/Get")]
        public IEnumerable<SubCategories> Get()
        {
            return _SubCategoryList.Get();
        }
        [HttpGet]
        [Route("api/Item/Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var item = _SubCategoryList.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [HttpGet]
        [Route("api/Item/ItemList/{pid}")]
        public IEnumerable<SubCategories> ItemList(int pid)
        {
            return _SubCategoryList.GetSubCategories(pid);
        }
        [HttpGet]
        [Route("api/Item/Search/{name}")]
        public IHttpActionResult Search(string name)
        {
            var items = _SubCategoryList.Search(name);
            if (items == null)
                return NotFound();
            return Ok(items);
        }
    }
}
