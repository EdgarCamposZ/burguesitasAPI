namespace Domain.Combos;

public interface IComboRepository
{
    Task<List<Combo>> GetAll();
    Task<Combo?> GetByIdAsync(ComboId id);
    Task<bool> ExistsAsync(ComboId id);
    void Add(Combo combo);
    void Update(Combo combo);
    void Delete(Combo combo);
}