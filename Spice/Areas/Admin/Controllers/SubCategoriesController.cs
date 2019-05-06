using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public SubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET - INDEX
        public async Task<IActionResult> Index()
        {
            var subCategories = await _context.SubCategories.Include(s => s.Category).ToListAsync();
            return View(subCategories);
        }

        // GET - CREATE
        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await _context.Categories.ToListAsync(),
                SubCategory = new SubCategory(),
                SubCategoriesList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct()
                    .ToListAsync()
            };

            return View(model);
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _context.SubCategories.Include(s => s.Category)
                    .Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);

                if (doesSubCategoryExists.Any())
                {
                    StatusMessage = "Error: Sub Category exists under " + doesSubCategoryExists.First().Category.Name +
                                    " category. Please use another name.";
                }
                else
                {
                    _context.SubCategories.Add(model.SubCategory);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await _context.Categories.ToListAsync(),
                SubCategory = model.SubCategory,
                SubCategoriesList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };

            return View(modelVM);
        }

        [ActionName("GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            var subCategories = new List<SubCategory>();

            subCategories = await (from subCategory in _context.SubCategories
                where subCategory.CategoryId == id
                select subCategory).ToListAsync();

            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        // GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var subCategory = await _context.SubCategories.SingleOrDefaultAsync(s => s.Id == id);

            if (subCategory == null)
                return NotFound();

            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await _context.Categories.ToListAsync(),
                SubCategory = subCategory,
                SubCategoriesList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct()
                    .ToListAsync()
            };

            return View(model);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _context.SubCategories.Include(s => s.Category)
                    .Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);

                if (doesSubCategoryExists.Any())
                {
                    StatusMessage = "Error: Sub Category exists under " + doesSubCategoryExists.First().Category.Name +
                                    " category. Please use another name.";
                }
                else
                {
                    var subCategoryFromDb = await _context.SubCategories.FindAsync(model.SubCategory.Id);
                    subCategoryFromDb.Name = model.SubCategory.Name;
                    
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await _context.Categories.ToListAsync(),
                SubCategory = model.SubCategory,
                SubCategoriesList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };

            return View(modelVM);
        }
    }
}