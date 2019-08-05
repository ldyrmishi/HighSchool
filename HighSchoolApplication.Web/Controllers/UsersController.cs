using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly HighSchoolContext _context;

        public UsersController(HighSchoolContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            //var highSchoolContext = _context.Users.Include(u => u.Address).Include(u => u.Role).Include(u => u.School).Include(u => u.Status);
            return View();
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Role)
                .Include(u => u.School)
                .Include(u => u.Status)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id");
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId");
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.UsersStatus, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Firstname,Lastname,Gender,Username,Email,PhoneNumber,Birthdate,RegistrationDate,Password,ConfirmPassword,IsActive,AddressId,RoleId,SchoolId,CreatedAt,ModifiedAt,Notes,NrAmze,StatusId,Id")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", users.AddressId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", users.RoleId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Id", users.SchoolId);
            ViewData["StatusId"] = new SelectList(_context.UsersStatus, "Id", "Id", users.StatusId);
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", users.AddressId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", users.RoleId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Id", users.SchoolId);
            ViewData["StatusId"] = new SelectList(_context.UsersStatus, "Id", "Id", users.StatusId);
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Firstname,Lastname,Gender,Username,Email,PhoneNumber,Birthdate,RegistrationDate,Password,ConfirmPassword,IsActive,AddressId,RoleId,SchoolId,CreatedAt,ModifiedAt,Notes,NrAmze,StatusId,Id")] Users users)
        {
            if (id != users.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UserId))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", users.AddressId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", users.RoleId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Id", users.SchoolId);
            ViewData["StatusId"] = new SelectList(_context.UsersStatus, "Id", "Id", users.StatusId);
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Role)
                .Include(u => u.School)
                .Include(u => u.Status)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
