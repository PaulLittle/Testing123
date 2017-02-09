using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAC_Web_Application.Models.ClubModel;
using System.Security.Claims;
using SAC_Web_Application.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

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
        public IActionResult Create(int? subId)
        {
            if (subId != null)
            {
                var sub = _context.Subscriptions.Where(s => s.SubID == subId).First();
                ViewData["SubName"] = sub.Item;
                ViewData["SubID"] = sub.SubID;
            }

            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberID,Identifier,Address1,Address2,City,County,CountyOfBirth,DOB,DateRegistered,Email,FirstName,Gender,LastName,MembershipPaid,PhoneNumber,PostCode,Province,TeamName")]
            Members members
            /*, IServiceProvider serviceProvider*/) //for adding to member role
        {
            // GETS THE EMAIL ADDRESS OF THE USER THAT IS CURRENTLY LOGGED IN
            var userEmail = User.FindFirstValue(ClaimTypes.Name);
            int subNum = members.Identifier;
            int viewCount;
            
            if (subNum == 4 || subNum == 7 || subNum == 12)
                viewCount = 1;
            else if (subNum == 5 || subNum == 8 || subNum == 10)
                viewCount = 2;
            else if (subNum == 6 || subNum == 9 || subNum == 11)
                viewCount = 3;
            else viewCount = 0;
            //for adding to member role
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (ModelState.IsValid)
            {
                members.Email = userEmail;
                // addional columns that must be added
                members.MembershipPaid = false;
                members.DateRegistered = DateTime.Now;

                _context.Add(members);

                //for adding to member role
                /*ApplicationUser user1 = await userManager.FindByEmailAsync(userEmail);
                if (user1 != null)
                {
                    await userManager.AddToRolesAsync(user1, new string[] { "Member" });
                }*/

                await _context.SaveChangesAsync();
                if (viewCount == 0)
                    return RedirectToAction("Index");
                else
                    viewCount--;
                    return RedirectToAction("Create2", "Members", new { subId = subNum, viewCount = viewCount });

            }

            // If we got this far, something failed, redisplay form
            return View(members);
        }

        // GET: Members/Create2
        public IActionResult Create2(int? subId, int viewCount)
        {
            if (subId != null)
            {
                var sub = _context.Subscriptions.Where(s => s.SubID == subId).First();
                ViewData["SubName"] = sub.Item;
                ViewData["SubID"] = sub.SubID;
                //ViewData["viewCount"] = viewCount;
            }

            return View();
        }

        // POST: Members/Create2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("MemberID,Identifier,Address1,Address2,City,County,CountyOfBirth,DOB,DateRegistered,Email,FirstName,Gender,LastName,MembershipPaid,PhoneNumber,PostCode,Province,TeamName")]
            Members members
            /*, IServiceProvider serviceProvider*/) //for adding to member role
        {
            // GETS THE EMAIL ADDRESS OF THE USER THAT IS CURRENTLY LOGGED IN
            //var userEmail = User.FindFirstValue(ClaimTypes.Name);
            int subNum = members.Identifier;
            int viewCount;

            if (subNum == 5 || subNum == 8 || subNum == 10)
                viewCount = 1;
            else if (subNum == 6 || subNum == 9 || subNum == 11)
                viewCount = 2;
            else viewCount = 0;
            //for adding to member role
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (ModelState.IsValid)
            {
                //members.Email = userEmail;
                // addional columns that must be added
                members.MembershipPaid = false;
                members.DateRegistered = DateTime.Now;

                _context.Add(members);

                //for adding to member role
                /*ApplicationUser user1 = await userManager.FindByEmailAsync(userEmail);
                if (user1 != null)
                {
                    await userManager.AddToRolesAsync(user1, new string[] { "Member" });
                }*/

                await _context.SaveChangesAsync();
                if (viewCount == 0)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Create3", "Members", new { subId = subNum, viewCount = viewCount });

            }

            // If we got this far, something failed, redisplay form
            return View(members);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Create([Bind
            ("MemberID,Address1,Address2,City,County,CountyOfBirth,DOB,DateRegistered,Email,FirstName,Gender,LastName,MembershipPaid,PhoneNumber,PostCode,Province,TeamName")]
            Members member1
            /*, IServiceProvider serviceProvider*/)
        {
            return PartialView(new Members()
            {
                Address1 = member1.Address1,
                Address2 = member1.Address2,
                PostCode = member1.PostCode,
                County = member1.County,
                City = member1.City,
                Province = member1.Province
            });
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

        // GET: Members/Subscriptions
        public IActionResult Subscriptions()
        {
            return View();
        }
    }
}
