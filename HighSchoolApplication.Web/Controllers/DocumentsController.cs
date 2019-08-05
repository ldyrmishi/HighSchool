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
    public class DocumentsController : Controller
    {
        private readonly HighSchoolContext _context;

        public DocumentsController(HighSchoolContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var highSchoolContext = _context.Documents.Include(d => d.DocumentCategory).Include(d => d.Subject).Include(d => d.User);
            var listDocuments = new List<Documents>();
            for (int i = 0; i < 5; i++)
            {
                Documents documents = new Documents();
                documents.DocumentUrl = "http://e-shkollaime.al";
                documents.DocumentId = i;
                documents.DocumentDescription = "Ky eshte nje pershkrim per dokumentin";
                listDocuments.Add(documents);
            }
            
            //return View(await highSchoolContext.ToListAsync());
            return View(listDocuments);
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents
                .Include(d => d.DocumentCategory)
                .Include(d => d.Subject)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (documents == null)
            {
                return NotFound();
            }

            return View(documents);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["DocumentCategoryId"] = new SelectList(_context.DocumentCategory, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,DocumentDescription,DocumentUrl,UserId,SubjectId,CreatedAt,ModifiedAt,DocumentCategoryId,Id")] Documents documents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentCategoryId"] = new SelectList(_context.DocumentCategory, "Id", "Id", documents.DocumentCategoryId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", documents.SubjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", documents.UserId);
            return View(documents);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents.FindAsync(id);
            if (documents == null)
            {
                return NotFound();
            }
            ViewData["DocumentCategoryId"] = new SelectList(_context.DocumentCategory, "Id", "Id", documents.DocumentCategoryId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", documents.SubjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", documents.UserId);
            return View(documents);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,DocumentDescription,DocumentUrl,UserId,SubjectId,CreatedAt,ModifiedAt,DocumentCategoryId,Id")] Documents documents)
        {
            if (id != documents.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentsExists(documents.DocumentId))
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
            ViewData["DocumentCategoryId"] = new SelectList(_context.DocumentCategory, "Id", "Id", documents.DocumentCategoryId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", documents.SubjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", documents.UserId);
            return View(documents);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents
                .Include(d => d.DocumentCategory)
                .Include(d => d.Subject)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (documents == null)
            {
                return NotFound();
            }

            return View(documents);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documents = await _context.Documents.FindAsync(id);
            _context.Documents.Remove(documents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentsExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }
    }
}
