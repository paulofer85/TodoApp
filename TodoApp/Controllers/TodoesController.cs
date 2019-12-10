using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp
{
    [EnableCors("_allowMyOrigin")]
    [Produces("application/json")]
    [Route("api/Todoes")]
    public class TodoesController : Controller
    {
        private readonly TodoAppContext _context;

        public TodoesController(TodoAppContext context)
        {
            _context = context;
        }

        public class TodoParameters
        {
            public string descripcion { get; set; }
            public string  estatus { get; set; }
            public IFormFile documento{ get; set; }

            public bool IsValid => (!string.IsNullOrEmpty(descripcion)) && (estatus != null) ;
        }

        // GET: api/Todoes
        [HttpGet]
        public IEnumerable<Todoes> GetTodoes()
        {
            return _context.Todoes;
        }

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoes = await _context.Todoes.SingleOrDefaultAsync(m => m.TodoId == id);

            if (todoes == null)
            {
                return NotFound();
            }

            return Ok(todoes);
        }

        /// <summary>
        /// GET: api/Todoes/byFilters?descripcion=XXXXXX
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        [HttpGet("{byFilters}")]
        public IEnumerable<Todoes> GetTodoesFilter(int? id, string descripcion, string estatus)
        {
            List<Todoes> rdoTodoes = new List<Todoes>();
            if (id != null)
                rdoTodoes.Add(_context.Todoes.FirstOrDefault(m => m.TodoId == id));
            else if(!string.IsNullOrEmpty(descripcion))
            {
                rdoTodoes = _context.Todoes.Where(m => m.Descripcion.Contains(descripcion)).ToList();
                if (!string.IsNullOrEmpty(estatus))
                    return rdoTodoes.Where(m => m.Estatus.Contains(estatus.ToUpper()));
            }
            else if(!string.IsNullOrEmpty(estatus))
                rdoTodoes = _context.Todoes.Where(m => m.Estatus.Contains(estatus.ToUpper())).ToList();

            return rdoTodoes;
        }

        // PUT: api/Todoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoes([FromRoute] int id, [FromBody] Todoes todoes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != todoes.TodoId)
                return BadRequest();
            
            Todoes currentTodo = _context.Todoes.SingleOrDefault(m => m.TodoId == id);
            if (currentTodo.Estatus != todoes.Estatus)
            {
                try
                {
                    _context.Entry(currentTodo).State = EntityState.Modified;
                    _context.Entry(currentTodo).Entity.Documento = currentTodo.Documento;
                    _context.Entry(currentTodo).Entity.Descripcion = currentTodo.Descripcion;
                    
                    _context.Entry(currentTodo).Entity.Estatus = todoes.Estatus;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoesExists(id))
                        return NotFound();
                    else
                        throw;
                }
                return Ok();
            }
            return NoContent();
        }

        // POST: api/Todoes
        [HttpPost]
        public async Task<IActionResult> PostTodoes([FromForm] TodoParameters paramTodoes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Todoes todoAdd = new Todoes();
            todoAdd.Descripcion = paramTodoes.descripcion;
            todoAdd.Estatus = paramTodoes.estatus;
            todoAdd.Documento = paramTodoes.documento != null ? paramTodoes.documento.FileName : "";

            if (todoAdd.Documento.Length > 0)
            {
                string timeStamp = DateTime.Now.Ticks.ToString();
                using (var fileStream = new FileStream("wwwroot/App_Data/" + timeStamp + "_" + paramTodoes.documento.FileName, FileMode.Create))
                {
                    paramTodoes.documento.CopyTo(fileStream);
                    todoAdd.Documento = fileStream.Name;
                }
            }
            _context.Add(todoAdd);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoes", new { id = todoAdd.TodoId }, todoAdd);
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoes = await _context.Todoes.SingleOrDefaultAsync(m => m.TodoId == id);
            if (todoes == null)
            {
                return NotFound();
            }

            _context.Todoes.Remove(todoes);
            await _context.SaveChangesAsync();

            return Ok(todoes);
        }

        private bool TodoesExists(int id)
        {
            return _context.Todoes.Any(e => e.TodoId == id);
        }
    }
}