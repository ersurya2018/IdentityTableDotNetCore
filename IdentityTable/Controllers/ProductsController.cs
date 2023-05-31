using IdentityTable.Models;
using IdentityTable.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        [Route("getproductlist")]
        public async Task<List<Product>> GetProductList()
        {
            try
            {
                return await productService.GetProductListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("getproductbyid")]
        public async Task<IEnumerable<Product>> GetProductById(int id)
        {
            try
            {
                var response = await productService.GetProductByIdAsync(id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("addproduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            try
            {
                var response= await productService.AddProductAsync(product);
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("addproductxml")]
        public async Task<IActionResult> AddProductxml(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await productService.AddProductxml(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("updateproduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await productService.UpdateProductAsync(product);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<int> DeleteProduct(int id)
        {
            try
            {
                var response = await productService.DeleteProductAsync(id);
                return response;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
