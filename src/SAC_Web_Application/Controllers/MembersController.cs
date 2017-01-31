using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAC_Web_Application.Models.ClubModel;
using System.Security.Claims;

//Members Controller
namespace SAC_Web_Application.Controllers
{
    public class MembersController : Controller
    {
        private ClubContext _context;

        public MembersController(ClubContext context)
        {
            _context = context;    
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.SingleOrDefaultAsync(m => m.MemberID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberID,Address1,Address2,City,County,CountyOfBirth,DOB,DateRegistered,Email,FirstName,Gender,LastName,MembershipPaid,PhoneNumber,PostCode,Province,TeamName")] Members members)
        {
            // GETS THE EMAI ADDRESS OF THE USER THAT IS CURRENTLY LOGGED IN
            var userEmail = User.FindFirstValue(ClaimTypes.Name);

            if (ModelState.IsValid)
            {
                members.Email = userEmail;
                // addional columns that must be added
                members.MembershipPaid = false;
                members.DateRegistered = DateTime.Now;

                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            // If we got this far, something failed, redisplay form
            return View(members);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.SingleOrDefaultAsync(m => m.MemberID == id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberID,Address1,Address2,City,County,CountyOfBirth,DOB,DateRegistered,Email,FirstName,Gender,LastName,MembershipPaid,PhoneNumber,PostCode,Province,TeamName")] Members members)
        {
            if (id != members.MemberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.MemberID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(members);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.SingleOrDefaultAsync(m => m.MemberID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Members.SingleOrDefaultAsync(m => m.MemberID == id);
            _context.Members.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.MemberID == id);
        }
    }
}
