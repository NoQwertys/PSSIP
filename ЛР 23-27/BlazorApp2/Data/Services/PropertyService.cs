using BlazorApp2.Data;
using Microsoft.EntityFrameworkCore;

public class PropertyService
{
    private readonly ApplicationDbContext _context;

    public PropertyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Property>> GetAllPropertiesAsync()
    {
        return await _context.Properties.Where(p => p.Status == "В продаже").ToListAsync();
    }
}