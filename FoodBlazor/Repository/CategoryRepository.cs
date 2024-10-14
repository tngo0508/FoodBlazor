using FoodBlazor.Data;
using FoodBlazor.Repository.IRepository;

namespace FoodBlazor.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public Category Create(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
        return category;
    }

    public Category Update(Category category)
    {
        var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == category.Id);
        if (objFromDb == null) return new Category();
        objFromDb.Name = category.Name;
        _db.Categories.Update(objFromDb);
        _db.SaveChanges();
        return objFromDb;
    }

    public bool Delete(int id)
    {
        var obj = _db.Categories.FirstOrDefault(x => x.Id == id);
        if (obj == null) return false;
        _db.Categories.Remove(obj);
        return (_db.SaveChanges() > 0);
    }

    public Category Get(int id)
    {
        var obj = _db.Categories.FirstOrDefault(x => x.Id == id);
        return obj ?? new Category();
    }

    public IEnumerable<Category> GetAll()
    {
        return _db.Categories.ToList();
    }
}