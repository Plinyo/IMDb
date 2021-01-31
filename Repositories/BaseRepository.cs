using IMDb.Data;

namespace IMDb.Repositories
{
    public class BaseRepository
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }      
    }
}