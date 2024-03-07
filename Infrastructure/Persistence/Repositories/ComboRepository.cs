using Domain.Combos;

namespace Infrastructure.Persistence.Repositories;

public class ComboRepository : IComboRepository
{
    private readonly ApplicationDbContext _context;

    public ComboRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Combo combo) => _context.Combos.Add(combo);
    public void Delete(Combo combo) => _context.Combos.Remove(combo);
    public void Update(Combo combo) => _context.Combos.Update(combo);
    public async Task<bool> ExistsAsync(ComboId id) => await _context.Combos.AnyAsync(combo => combo.Id == id);
    public async Task<Combo?> GetByIdAsync(ComboId id) => await _context.Combos.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Combo>> GetAll() => await _context.Combos.ToListAsync();
}