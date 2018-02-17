using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    //[Route("api")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/products")]
        //[Authorize(Policy = "Admin")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_repository.Get());


            //Usuario autenticado
            //return Ok(new {user = User.Identity.Name});
        }
    }
}
