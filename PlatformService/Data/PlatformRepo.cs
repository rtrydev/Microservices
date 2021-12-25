using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private AppDbContext _context;
    
    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Platform> GetAll()
    {
        return _context.Platforms.ToList();
    }

    public Platform GetById(int id)
    {
        return _context.Platforms.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Platform platform)
    {
        if (platform is null) throw new ArgumentNullException(nameof(platform));
        _context.Platforms.Add(platform);
    }
}