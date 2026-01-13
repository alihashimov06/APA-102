using _34_Front_To_BackSqlConnection.DAL;
using Microsoft.EntityFrameworkCore;

namespace _34_Front_To_BackSqlConnection.Services.Implementation
{
    public class LayoutServices : Interfaces.ILayoutServices
    {
        private readonly AppDbContext _context;

        public LayoutServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string,string>> GetSettingAsync()
        {
            Dictionary<string,string> settings = await _context.Settings
                .ToDictionaryAsync(s => s.Key, s => s.Value);
            return settings;
        }
    }
}
