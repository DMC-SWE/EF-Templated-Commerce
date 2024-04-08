using EF_Templated_Commerce.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Templated_Commerce.Data
{
    public class ItemRepositoryEF : IItemRepository
    {
        private ItemContext _context;

        public ItemRepositoryEF(ItemContext context)
        {
            _context = context;
        }

        public void DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return;
            }


            _context.Items.Remove(item);
           
            _context.SaveChangesAsync();
        }

        public ItemModel GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<ItemModel> GetItems()
        {
            return _context.Items.ToList();
        }

        public IEnumerable<ItemModel> GetItems(string? filter)
        {
            if (string.IsNullOrEmpty(filter))
                return _context.Items.ToList();
           
            return _context.Items.Where(i => i.Name.Contains(filter)).ToList();
        }

        public void InsertItem(ItemModel item)
        {
            _context.Items.Add(item);

            _context.SaveChanges();
        }

        public bool UpdateItem(ItemModel item)
        {
            _context.Attach(item).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
    }
}
