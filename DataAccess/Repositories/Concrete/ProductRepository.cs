using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstarct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsBestSellingAsync()
        {
            var products = await _context.Products
              .Where(pr => pr.BestSelling == true)
              .ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetProductsInSaleAsync()
        {
            var products = await _context.Products
                .Where(pr => pr.InSale == true)
                .ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetAllWithBrandAsync()
        {
            var product = await _context.Products.Include(br => br.Brand).ToListAsync();
            return product;
        }

        public async Task<Product> GetProductDetailsAsync(int id)
        {
            var product = await _context.Products.Include(br => br.Brand)
                .Include(ph => ph.ProductPhotos)
                .Include(c => c.Colors)
                .ThenInclude(c => c.Color)
                .Include(s => s.Sizes)
                .ThenInclude(s => s.Size)
                .FirstOrDefaultAsync(pr => pr.Id == id);
            return product;
        }
        public async Task<IQueryable<Product>> PaginateProductAsync(IQueryable<Product> products, int page, int take)
        {
            products = products
                .OrderByDescending(d => d.CreatedAt)
                .Skip((page - 1) * take)
                .Take(take);
            return products;
        }

        public async Task<int> GetPageCountAsync(IQueryable<Product> products, int take)
        {
            var pageCount = await products.CountAsync();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }

        public async Task<IQueryable<Product>> FilterByName(string? name)
        {
            return _context.Products
                .Include(pr => pr.Colors)
                .Include(pr => pr.Sizes)
                .Include(pr => pr.Brand)
                .Where(d => !string.IsNullOrEmpty(name) ? d.Title.Contains(name) : true);
        }

        public async Task<List<Product>> GetRelatedProductsAsync(int model, int gender)
        {
            var relatedProducts = await _context.Products
                .Include(pr => pr.Brand)
                .Where(pr => ((int)pr.Model) == model && ((int)pr.Gender) == gender)
                .Take(12).ToListAsync();
            return relatedProducts;
        }

        public async Task<Product> GetUpdateModelAsync(int id)
        {
            var product = await _context.Products
                .Include(pr => pr.Brand)
                .Include(pr => pr.Colors)
                .Include(pr => pr.Sizes)
                .Include(ph => ph.ProductPhotos)
                .FirstOrDefaultAsync(pr => pr.Id == id);
            return product;
        }

        public async Task<List<Product>> ProductsLoadMoreAsync(int skipRow)
        {
            var products = await _context.Products
                .Include(pr => pr.Brand)
                .OrderByDescending(p => p.Id)
                .Skip(4 * skipRow)
                .Take(4)
                .ToListAsync();

            return products;

        }

        public async Task<bool> CheckIsLastAsync(int skipRow)
        {
            if (((skipRow + 1) * 4) + 1 >= _context.Products.Count())
            {
                return true;
            }
            return false;
        }
    }
}
