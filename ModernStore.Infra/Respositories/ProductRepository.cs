using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ModernStore.Shared;

namespace ModernStore.Infra.Respositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            //Usando o dapper
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                var query = "SELECT id, title, price, image from product";
                conn.Open();
                return conn.Query<GetProductListCommandResult>(query);
            }
        }
    }
}
