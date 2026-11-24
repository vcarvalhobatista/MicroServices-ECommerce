using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public MySQLContext(){}
    }
}
