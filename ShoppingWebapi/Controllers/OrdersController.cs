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
    public class OrdersController : ApiController
    {
        private IOrdersRepository _OrdersList = null;
        public OrdersController()
        {
            _OrdersList = new OrdersRepository();
        }
        [HttpGet]
        [Route("api/Orders/Get")]
        public IEnumerable<Orders> Get()
        {
            return _OrdersList.Get();
        }
        [HttpGet]
        [Route("api/Orders/Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var order= _OrdersList.GetById(id);
            if (order ==null)
                return NotFound();
            return Ok(order);
        }
        [HttpDelete]
        [Route("api/Orders/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var order = _OrdersList.DeleteItem(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }
        [HttpGet]
        [Route("api/Orders/AddToCart/{id}")]
        public IHttpActionResult AddToCart(int id)
        {
            var order = _OrdersList.AddToCart(id);
            if (order != null)
            {
                _OrdersList.Insert(order);
                _OrdersList.Save();
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/Orders/ConfirmCheckout")]
        public IHttpActionResult ConfirmCheckout()
        {
            _OrdersList.ConfirmCheckout();
            return Ok();  
        }

    }
}
