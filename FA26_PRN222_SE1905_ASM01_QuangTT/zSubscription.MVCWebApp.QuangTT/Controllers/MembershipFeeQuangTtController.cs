using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zSubscription.Entities.QuangTT.Models;
using zSubscription.Repositories.QuangTT.DBContext;

namespace zSubscription.MVCWebApp.QuangTT.Controllers
{
    public class MembershipFeeQuangTtController : Controller
    {
        private readonly PRN222Context _context;

        public MembershipFeeQuangTtController(PRN222Context context)
        {
            _context = context;
        }

        // GET: MembershipFeeQuangTt
        public async Task<IActionResult> Index()
        {
            var pRN222Context = _context.MembershipFeeQuangTts.Include(m => m.FeePackageQuangTt);
            return View(await pRN222Context.ToListAsync());
        }

        // GET: MembershipFeeQuangTt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipFeeQuangTt = await _context.MembershipFeeQuangTts
                .Include(m => m.FeePackageQuangTt)
                .FirstOrDefaultAsync(m => m.MembershipFeeQuangTtid == id);
            if (membershipFeeQuangTt == null)
            {
                return NotFound();
            }

            return View(membershipFeeQuangTt);
        }

        // GET: MembershipFeeQuangTt/Create
        public IActionResult Create()
        {
            ViewData["FeePackageQuangTtid"] = new SelectList(_context.FeePackageQuangTts, "FeePackageQuangTtid", "PackageName");
            return View();
        }

        // POST: MembershipFeeQuangTt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembershipFeeQuangTtid,MemberName,Amount,PaymentDate,PaymentMethod,TransactionCode,StartDate,EndDate,Notes,Status,PublishDate,UpdateAt,FeePackageQuangTtid,IsActive")] MembershipFeeQuangTt membershipFeeQuangTt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membershipFeeQuangTt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeePackageQuangTtid"] = new SelectList(_context.FeePackageQuangTts, "FeePackageQuangTtid", "PackageName", membershipFeeQuangTt.FeePackageQuangTtid);
            return View(membershipFeeQuangTt);
        }

        // GET: MembershipFeeQuangTt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipFeeQuangTt = await _context.MembershipFeeQuangTts.FindAsync(id);
            if (membershipFeeQuangTt == null)
            {
                return NotFound();
            }
            ViewData["FeePackageQuangTtid"] = new SelectList(_context.FeePackageQuangTts, "FeePackageQuangTtid", "PackageName", membershipFeeQuangTt.FeePackageQuangTtid);
            return View(membershipFeeQuangTt);
        }

        // POST: MembershipFeeQuangTt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipFeeQuangTtid,MemberName,Amount,PaymentDate,PaymentMethod,TransactionCode,StartDate,EndDate,Notes,Status,PublishDate,UpdateAt,FeePackageQuangTtid,IsActive")] MembershipFeeQuangTt membershipFeeQuangTt)
        {
            if (id != membershipFeeQuangTt.MembershipFeeQuangTtid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membershipFeeQuangTt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipFeeQuangTtExists(membershipFeeQuangTt.MembershipFeeQuangTtid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeePackageQuangTtid"] = new SelectList(_context.FeePackageQuangTts, "FeePackageQuangTtid", "PackageName", membershipFeeQuangTt.FeePackageQuangTtid);
            return View(membershipFeeQuangTt);
        }

        // GET: MembershipFeeQuangTt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipFeeQuangTt = await _context.MembershipFeeQuangTts
                .Include(m => m.FeePackageQuangTt)
                .FirstOrDefaultAsync(m => m.MembershipFeeQuangTtid == id);
            if (membershipFeeQuangTt == null)
            {
                return NotFound();
            }

            return View(membershipFeeQuangTt);
        }

        // POST: MembershipFeeQuangTt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membershipFeeQuangTt = await _context.MembershipFeeQuangTts.FindAsync(id);
            if (membershipFeeQuangTt != null)
            {
                _context.MembershipFeeQuangTts.Remove(membershipFeeQuangTt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipFeeQuangTtExists(int id)
        {
            return _context.MembershipFeeQuangTts.Any(e => e.MembershipFeeQuangTtid == id);
        }
    }
}
