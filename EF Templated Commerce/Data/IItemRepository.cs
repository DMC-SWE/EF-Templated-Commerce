using EF_Templated_Commerce.Model;
using Microsoft.AspNetCore.Http.Features;

namespace EF_Templated_Commerce.Data
{
    public interface IItemRepository 
    {
        IEnumerable<ItemModel> GetItems();
        IEnumerable<ItemModel> GetItems(string? filter);
        ItemModel? GetItemById(int id);
        void InsertItem(ItemModel item);
        void DeleteItem(int id);
        bool UpdateItem(ItemModel item);
    }
}
