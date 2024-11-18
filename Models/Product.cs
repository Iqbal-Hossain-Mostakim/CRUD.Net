using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDWithRepository.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public String ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
