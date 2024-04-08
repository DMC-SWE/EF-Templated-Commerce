using EF_Templated_Commerce.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Templated_Commerce.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {
        }

        // whatever you name this collection will be your table name
        public DbSet<ItemModel> Items { get; set; } = default!;
    }
}
