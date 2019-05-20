﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CouponController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CouponController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupons)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    coupons.Picture = p1;
                }

                _context.Coupons.Add(coupons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(coupons);
        }

        // GET - EDIT Coupon
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var coupon = await _context.Coupons.SingleOrDefaultAsync(m => m.Id == id);

            if (coupon == null)
                return NotFound();

            return View(coupon);
        }

        // POST - EDIT Coupon
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coupon coupon)
        {
            if (coupon.Id == 0)
                return NotFound();

            var couponFromDb = await _context.Coupons.Where(c => c.Id == coupon.Id).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    couponFromDb.Picture = p1;
                }

                couponFromDb.MinimumAmount = coupon.MinimumAmount;
                couponFromDb.Name = coupon.Name;
                couponFromDb.Discount = coupon.Discount;
                couponFromDb.CouponType = coupon.CouponType;
                couponFromDb.IsActive = coupon.IsActive;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(coupon);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var coupon = await _context.Coupons.FirstOrDefaultAsync(m => m.Id == id);

            if (coupon == null)
                return NotFound();

            return View(coupon);
        }

        // GET - DELETE Coupon
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            
            var coupon = await _context.Coupons.SingleOrDefaultAsync(m => m.Id == id);

            if (coupon == null)
                return NotFound();

            return View(coupon);
        }

        // POST - DELETE Coupon

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coupons = await _context.Coupons.SingleOrDefaultAsync(m => m.Id == id);
            _context.Coupons.Remove(coupons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}