using System.ComponentModel.DataAnnotations;

namespace FoodBlazor.Data;

public class Category
{
   public int Id { get; set; }

   [Required(ErrorMessage = "Category Name is required")]
   public string Name { get; set; }
}