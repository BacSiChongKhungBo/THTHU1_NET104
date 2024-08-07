using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using THTHU1_NET104.Models;

namespace THTHU1_NET104.Controllers
{
    public class OtoesController : Controller
    {
        private readonly MyDBContext _context;

        public OtoesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Otoes
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.Otos.Include(o => o.Hang);
            return View(await myDBContext.ToListAsync());
        }

        // GET: Otoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oto = await _context.Otos
                .Include(o => o.Hang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oto == null)
            {
                return NotFound();
            }

            return View(oto);
        }

        // GET: Otoes/Create
        public IActionResult Create()
        {
            ViewData["IDHang"] = new SelectList(_context.Hangs, "ID", "ID");
            return View();
        }

        // POST: Otoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten,IDHang,Gia")] Oto oto)
        {
            if(oto != null)
            {
                _context.Add(oto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["IDHang"] = new SelectList(_context.Hangs, "ID", "ID", oto.IDHang);
            return View(oto);
        }

        public IActionResult RollBack()
        {
            Oto o = new Oto();
            o.ID = HttpContext.Session.GetString("IdOto");
            o.Ten = HttpContext.Session.GetString("TenOto");
            o.IDHang = HttpContext.Session.GetString("IdHang");
            o.Gia = double.Parse(HttpContext.Session.GetString("Gia"));
            //------------
            if (o != null)
            {
                _context.Add(o);
                _context.SaveChanges();
                return RedirectToAction("Index", "Otoes");
            }
            return RedirectToAction("Index", "Otoes");
        }

        // GET: Otoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oto = await _context.Otos.FindAsync(id);
            if (oto == null)
            {
                return NotFound();
            }
            ViewData["IDHang"] = new SelectList(_context.Hangs, "ID", "ID", oto.IDHang);
            return View(oto);
        }

        // POST: Otoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Ten,IDHang,Gia")] Oto oto)
        {
            if (id != oto.ID)
            {
                return NotFound();
            }

            if (oto != null)
            {
                try
                {
                    _context.Update(oto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtoExists(oto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            ViewData["IDHang"] = new SelectList(_context.Hangs, "ID", "ID", oto.IDHang);
            return View(oto);
        }

        // GET: Otoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oto = await _context.Otos
                .Include(o => o.Hang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oto == null)
            {
                return NotFound();
            }

            return View(oto);
        }

        // POST: Otoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var oto = await _context.Otos.FindAsync(id);
            if (oto != null)
            {
                _context.Otos.Remove(oto);
                HttpContext.Session.SetString("IdOto", oto.ID);
                HttpContext.Session.SetString("TenOto", oto.Ten);
                HttpContext.Session.SetString("IdHang", oto.IDHang);
                HttpContext.Session.SetString("Gia", oto.Gia.ToString());
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool OtoExists(string id)
        {
            return _context.Otos.Any(e => e.ID == id);
        }
    }
}
