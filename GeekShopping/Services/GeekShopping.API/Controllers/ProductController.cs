using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.API.Data.ValueObjects;
using GeekShopping.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product =  await _repository.FinById(id);
            if(product.Id <= 0) return NotFound("Dados não encontrados.");

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductVO>>> FindAll()
        {
            var products =  await _repository.FindAll();
            if(products is null) return NotFound("Não existem dados para serem apresentados.");

            return Ok(products);
        }

        
        [HttpPost]
        public async Task<ActionResult<ProductVO>> CreateProduct(ProductVO productVO)
        {
            var product =  await _repository.Create(productVO);
            if(product is null) return BadRequest( "Não foi possível criar o produto.");

            return Ok(product);
        }

        
        [HttpPut]
        public async Task<ActionResult<ProductVO>> UpdateProduct(ProductVO productVO)
        {
            var product =  await _repository.Update(productVO);
            if(product is null) return BadRequest("Não foi possível atualizar o produto.");

            return Ok(product);
        }

        
        [HttpDelete("{ID:int}")]
        public async Task<ActionResult<ICollection<ProductVO>>> DeleteProduct(int ID)
        {   
            var status = await _repository.Delete(ID);

            if(!status) return BadRequest("Não foi possível excluir o produto.");

            return Ok();
        }
    }
}