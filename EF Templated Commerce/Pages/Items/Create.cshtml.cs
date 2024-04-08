using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EF_Templated_Commerce.Data;
using EF_Templated_Commerce.Model;

namespace EF_Templated_Commerce.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly IItemRepository _repo;

         public CreateModel(IItemRepository repo)
        {
            _repo = repo;
        }      

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ItemModel ItemModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.InsertItem(ItemModel);

            return RedirectToPage("./Index");
        }
    }
}
