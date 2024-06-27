using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaWebApp.Datos;
using PruebaWebApp.Models;

namespace PruebaWebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.Include(u => u.Categoria).ToListAsync();

            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Categoria)
                .Include(u => u.Oficina)
                .Include(u => u.UsuarioProyectos)
                    .ThenInclude(up => up.Proyecto)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Cedula,CategoriaId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", usuario.CategoriaId);
            return View();
        }


        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.UsuarioProyectos)
                .ThenInclude(up => up.Proyecto)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", usuario.CategoriaId);
            ViewBag.Proyectos = new SelectList(_context.Proyectos, "Id", "Nombre");
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Cedula,CategoriaId")] Usuario usuario, int? proyectoId)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit), new { id = usuario.Id });
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", usuario.CategoriaId);
            ViewBag.Proyectos = new SelectList(_context.Proyectos, "Id", "Nombre");
            return View(usuario);
        }

        // POST: Usuarios/AsignarProyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarProyecto(int usuarioId, int proyectoId)
        {

            if (proyectoId != null)
            {
                var usuarioProyecto = new UsuarioProyecto
                {
                    IdUsuario = usuarioId,
                    IdProyecto = proyectoId
                };
                _context.UsuarioProyectos.Add(usuarioProyecto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = usuarioId });
        }

        // POST: Usuarios/DesasignarProyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesasignarProyecto(int usuarioId, int proyectoId)
        {
            var usuarioProyecto = await _context.UsuarioProyectos
                .FirstOrDefaultAsync(up => up.IdUsuario == usuarioId && up.IdProyecto == proyectoId);

            if (usuarioProyecto != null)
            {
                _context.UsuarioProyectos.Remove(usuarioProyecto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = usuarioId });
        }


        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
