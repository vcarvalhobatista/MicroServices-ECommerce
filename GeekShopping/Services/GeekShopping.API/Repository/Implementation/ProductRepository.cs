using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekShopping.API.Data.ValueObjects;
using GeekShopping.API.Model;
using GeekShopping.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.API.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context , IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductVO> FinById(long id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ?? new Product();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }
        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();
                
                if (product is null)
                {
                    return false;
                }                
                
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
                
            }
            catch (System.Exception)
            {                
                return false;
            }
        }


        
    }
}