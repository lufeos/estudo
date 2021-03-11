using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;

        public ProAgilRepository(ProAgilContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this._context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this._context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return(await this._context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventoAsync(bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = this._context.Eventos
                .Include(c => c.lotes)
                .Include(c => c.redesSociais);

            if (incluirPalestrante)
            {
                query = query
                    .Include(pe => pe.palestranteEvento).ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.dataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool incluirPalestrante = false)
        {

            IQueryable<Evento> query = this._context.Eventos
                .Include(c => c.lotes)
                .Include(c => c.redesSociais);

            if (incluirPalestrante)
            {
                query = query
                    .Include(pe => pe.palestranteEvento).ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.dataEvento)
                .Where(c => c.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();

        }

        public async Task<Evento> GetEventoAsyncById(int eventoId, bool incluirPalestrante = false)
        {

            IQueryable<Evento> query = this._context.Eventos
                .Include(c => c.lotes)
                .Include(c => c.redesSociais);

            if (incluirPalestrante)
            {
                query = query
                    .Include(pe => pe.palestranteEvento).ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.dataEvento)
                .Where(c => c.id == eventoId);

            return await query.FirstOrDefaultAsync();
                                    
        }

        public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string nome, bool incluirEvento = false)
        {

            IQueryable<Palestrante> query = this._context.Palestrantes
                .Include(p => p.redesSociais);

            if (incluirEvento)
            {
                query = query
                    .Include(pe => pe.palestranteEvento)
                    .ThenInclude(e => e.evento);
            }

            query = query.Where(p => p.nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();

        }

        public async Task<Palestrante> GetPalestranteAsyncById(int palestranteId, bool incluirEvento = false)
        {

            IQueryable<Palestrante> query = this._context.Palestrantes
                .Include(p => p.redesSociais);

            if (incluirEvento)
            {
                query = query
                    .Include(pe => pe.palestranteEvento)
                    .ThenInclude(e => e.evento);
            }

            query = query.OrderBy(p => p.nome)
                .Where(p => p.id == palestranteId);

            return await query.FirstOrDefaultAsync();                                               

        }
    }
}