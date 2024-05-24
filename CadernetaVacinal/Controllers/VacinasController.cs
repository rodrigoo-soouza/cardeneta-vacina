using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadernetaVacinal.Data;
using CadernetaVacinal.Models;
using Microsoft.AspNetCore.Authorization;

namespace CadernetaVacinal.Controllers;

[Authorize] 
public class VacinasController : Controller
{
    private readonly ApplicationDbContext _context;

    public VacinasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Vacinas
    public async Task<IActionResult> Index()
    {
          return _context.Vacinas != null ? 
                      View(await _context.Vacinas
                      .ToListAsync()) :
                      Problem("Entity set 'ApplicationDbContext.Vacinas'  is null.");
    }

    // GET: Vacinas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Vacinas == null)
        {
            return NotFound();
        }

        var vacina = await _context.Vacinas
            .FirstOrDefaultAsync(m => m.VacinaId == id);
        if (vacina == null)
        {
            return NotFound();
        }
                
        return View(vacina);
    }

    // GET: Vacinas/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Vacinas/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("VacinaId,Lote,NomeVacina,Local,DataVacinação,Dose,CPF,Nome,Matricula,Funcionario,User")] Vacina vacina)
    {
        if (ModelState.IsValid)
        {
            vacina.User = User.Identity.Name; 
            _context.Add(vacina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(vacina);
    }

    // GET: Vacinas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Vacinas == null)
        {
            return NotFound();
        }

        var vacina = await _context.Vacinas.FindAsync(id);
        if (vacina == null)
        {
            return NotFound();
        }

        if (User.Identity.Name != "admin@admin.com")
        {
            if (vacina.User != User.Identity.Name)
            {
                return View("Denied");
            }
        }

            

        return View(vacina);
    }

    // POST: Vacinas/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VacinaId,Lote,NomeVacina,Local,DataVacinação,Dose,CPF,Nome,Matricula,Funcionario")] Vacina vacina)
    {
        if (id != vacina.VacinaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                vacina.User = User.Identity.Name;
                _context.Update(vacina);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacinaExists(vacina.VacinaId))
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
        return View(vacina);
    }

    // GET: Vacinas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Vacinas == null)
        {
            return NotFound();
        }

        var vacina = await _context.Vacinas
            .FirstOrDefaultAsync(m => m.VacinaId == id);
        if (vacina == null)
        {
            return NotFound();
        }

        if (User.Identity.Name != "admin@admin.com")
        {
            if (vacina.User != User.Identity.Name)
            {
                return View("Denied");
            }
        }

            

        return View(vacina);
    }

    // POST: Vacinas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Vacinas == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Vacinas'  is null.");
        }
        var vacina = await _context.Vacinas.FindAsync(id);
        if (vacina != null)
        {
            _context.Vacinas.Remove(vacina);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VacinaExists(int id)
    {
      return (_context.Vacinas?.Any(e => e.VacinaId == id)).GetValueOrDefault();
    }
}
