using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utilities;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        [BindProperty]
        public MenuItemViewModel menuItemVM { get; set; }

        public MenuItemController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            menuItemVM = new MenuItemViewModel()
            {
                Categories = _context.Categories,
                MenuItem = new MenuItem()
            };
        }
        public async Task<IActionResult> Index()
        {
            var menuItems = await _context.MenuItems.Include(c => c.Category).Include(s => s.SubCategory).ToListAsync();

            return View(menuItems);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View(menuItemVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            menuItemVM.MenuItem.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());

            if (!ModelState.IsValid)
                return View(menuItemVM);

            _context.MenuItems.Add(menuItemVM.MenuItem);
            await _context.SaveChangesAsync();

            // Work on the image saving section
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDB = await _context.MenuItems.FindAsync(menuItemVM.MenuItem.Id);

            if (files.Any())
            {
                // files has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, menuItemVM.MenuItem.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }

                menuItemFromDB.Image = @"\images\" + menuItemVM.MenuItem.Id + extension;
            }
            else
            {
                // No files have been uploaded, so use default
                var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultFoodImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + menuItemVM.MenuItem.Id + ".jpg");
                menuItemFromDB.Image = @"\images\" + menuItemVM.MenuItem.Id + ".jpg";
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            menuItemVM.MenuItem = await _context.MenuItems.Include(m => m.Category).Include(m => m.SubCategory)
                .SingleOrDefaultAsync(m => m.Id == id);
            menuItemVM.SubCategories = await _context.SubCategories
                .Where(s => s.CategoryId == menuItemVM.MenuItem.CategoryId).ToListAsync();

            if (menuItemVM.MenuItem == null)
                return NotFound();

            return View(menuItemVM);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
                return NotFound();

            menuItemVM.MenuItem.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());

            if (!ModelState.IsValid)
            {
                menuItemVM.SubCategories = await _context.SubCategories
                    .Where(s => s.CategoryId == menuItemVM.MenuItem.CategoryId).ToListAsync();
                return View(menuItemVM);
            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _context.MenuItems.FindAsync(menuItemVM.MenuItem.Id);

            if (files.Any())
            {
                // New file has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extensionNew = Path.GetExtension(files[0].FileName);

                // Delete original file
                var imagePath = Path.Combine(webRootPath, menuItemFromDb.Image.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);

                // Upload the new file
                using (var filesStream = new FileStream(Path.Combine(uploads, menuItemVM.MenuItem.Id + extensionNew), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }

                menuItemFromDb.Image = @"\images\" + menuItemVM.MenuItem.Id + extensionNew;
            }

            menuItemFromDb.Name = menuItemVM.MenuItem.Name;
            menuItemFromDb.Description = menuItemVM.MenuItem.Description;
            menuItemFromDb.Price = menuItemVM.MenuItem.Price;
            menuItemFromDb.Spicyness = menuItemVM.MenuItem.Spicyness;
            menuItemFromDb.CategoryId = menuItemVM.MenuItem.CategoryId;
            menuItemFromDb.SubCategoryId = menuItemVM.MenuItem.SubCategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}