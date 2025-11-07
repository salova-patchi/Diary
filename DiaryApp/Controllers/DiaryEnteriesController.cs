using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Controllers
{
    public class DiaryEnteriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryEnteriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int page = 1, string search = "", string sortBy = "date", string mood = "all")
        {
            int pageSize = 10; // Changed to 10 entries per page

            var query = _db.DiaryEntries.AsQueryable();

            // Search filter
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Title.Contains(search) || e.Description.Contains(search));
            }

            // Mood filter
            if (mood != "all" && int.TryParse(mood, out int moodValue))
            {
                query = query.Where(e => (int)e.Mood == moodValue);
            }

            // Sorting
            query = sortBy switch
            {
                "date_asc" => query.OrderBy(e => e.Created),
                "title" => query.OrderBy(e => e.Title),
                "title_desc" => query.OrderByDescending(e => e.Title),
                _ => query.OrderByDescending(e => e.Created)
            };

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            page = Math.Max(1, Math.Min(page, totalPages == 0 ? 1 : totalPages));

            var entries = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;
            ViewBag.SearchTerm = search;
            ViewBag.SortBy = sortBy;
            ViewBag.MoodFilter = mood;

            return View(entries);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaryEntry = await _db.DiaryEntries
                .FirstOrDefaultAsync(m => m.Id == id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiaryEntry diaryEntry)
        {
            // Server-side validation
            if (string.IsNullOrWhiteSpace(diaryEntry.Title))
            {
                ModelState.AddModelError("Title", "Title is required");
            }

            if (string.IsNullOrWhiteSpace(diaryEntry.Description))
            {
                ModelState.AddModelError("Description", "Description is required");
            }

            if (diaryEntry.Title?.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters");
            }

            if (diaryEntry.Description?.Length < 10)
            {
                ModelState.AddModelError("Description", "Description must be at least 10 characters");
            }

            if (ModelState.IsValid)
            {
                diaryEntry.Created = DateTime.Now;
                _db.DiaryEntries.Add(diaryEntry);
                await _db.SaveChangesAsync();

                TempData["SuccessMessage"] = "Diary entry created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If we got here, something failed, redisplay form
            return View(diaryEntry);
        }


        // GET: DiaryEnteries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaryEntry = await _db.DiaryEntries.FindAsync(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        // POST: DiaryEnteries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DiaryEntry diaryEntry)
        {
            if (id != diaryEntry.Id)
            {
                return NotFound();
            }

            // Server-side validation
            if (string.IsNullOrWhiteSpace(diaryEntry.Title))
            {
                ModelState.AddModelError("Title", "Title is required");
            }

            if (string.IsNullOrWhiteSpace(diaryEntry.Description))
            {
                ModelState.AddModelError("Description", "Description is required");
            }

            if (diaryEntry.Title?.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters");
            }

            if (diaryEntry.Description?.Length < 10)
            {
                ModelState.AddModelError("Description", "Description must be at least 10 characters");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Ensure Created date is preserved
                    var existingEntry = await _db.DiaryEntries.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
                    if (existingEntry != null)
                    {
                        diaryEntry.Created = existingEntry.Created;
                    }

                    _db.Update(diaryEntry);
                    await _db.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Diary entry updated successfully!";
                    return RedirectToAction(nameof(Details), new { id = diaryEntry.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaryEntryExists(diaryEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(diaryEntry);
        }

        private bool DiaryEntryExists(int id)
        {
            return _db.DiaryEntries.Any(e => e.Id == id);
        }
        // GET: DiaryEnteries/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaryEntry = await _db.DiaryEntries.FindAsync(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        // POST: DiaryEnteries/Edit/5
        [HttpPost]
       
        public async Task<IActionResult> Delete(int id, DiaryEntry diaryEntry)
        {
            if (id != diaryEntry.Id)
            {
                return NotFound();
            }




            
              

                _db.Remove(diaryEntry);
                await _db.SaveChangesAsync();

                TempData["SuccessMessage"] = "Diary entry Deleted successfully!";




            return RedirectToAction(nameof(Index));

        }

        
    }
}

