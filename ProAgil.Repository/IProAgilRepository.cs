using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventoAsync(bool incluirPalestrante);
        Task<Evento> GetEventoAsyncById(int eventoId, bool incluirPalestrante);

        //PALESTRANTE
        Task<Palestrante[]> GetAllPalestranteAsyncByName(string nome, bool incluirEvento);
        Task<Palestrante> GetPalestranteAsyncById(int palestranteId, bool incluirEvento);

    }
}