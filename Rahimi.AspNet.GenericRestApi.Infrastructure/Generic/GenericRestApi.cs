using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rahimi.AspNet.GenericRestApi.Infrastructure.DataAccess;

namespace Rahimi.AspNet.GenericRestApi.Infrastructure.Generic
{
    public abstract class GenericRestApi<TEntity> : ControllerBase
        where TEntity : class
    {
        private readonly IRepository _repository;

        protected GenericRestApi(IRepository repository)
        {
            _repository = repository;
        }


        // GET All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetQueryable<TEntity>().ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await _repository.GetByIdAsync<TEntity>(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            var primaryKey = await _repository.InsertAsync(entity);
            return CreatedAtAction("Get", new { id = primaryKey[0] }, entity);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync<TEntity>(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<TEntity>(id);

            return NoContent();
        }

        private bool Exists(int id)
        {
            var entity = _repository.GetByIdAsync<TEntity>(id);
            return entity != null;
        }
    }
}
