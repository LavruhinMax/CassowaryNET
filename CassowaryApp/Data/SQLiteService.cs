namespace CassowaryApp.Data
{
    public class SQLiteService
    {
        private readonly AppDbContext _context;

        public SQLiteService(AppDbContext context)
        {
            _context = context;
        }
    }
}
