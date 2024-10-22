using FoodBlazor.Data;
using FoodBlazor.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FoodBlazor.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Category> CreateAsync(Category category)
    {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        var objFromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == category.Id);
        if (objFromDb == null) return new Category();
        objFromDb.Name = category.Name;
        _db.Categories.Update(objFromDb);
        await _db.SaveChangesAsync();
        return objFromDb;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (obj == null) return false;
        _db.Categories.Remove(obj);
        return (await _db.SaveChangesAsync() > 0);
    }

    public async Task<Category> GetAsync(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        return obj ?? new Category();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _db.Categories.ToListAsync();
    }
}