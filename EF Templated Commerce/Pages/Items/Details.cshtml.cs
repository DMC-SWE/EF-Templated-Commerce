using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EF_Templated_Commerce.Data;
using EF_Templated_Commerce.Model;

namespace EF_Templated_Commerce.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly IItemRepository _repo;

        public DetailsModel(IItemRepository repo)
        {
            _repo = repo;
        }

        public ItemModel ItemModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemmodel = _repo.GetItemById(id.Value);

            if (itemmodel == null)
            {
                return NotFound();
            }
            else
            {
                ItemModel = itemmodel;
            }
            return Page();
        }
    }
}
