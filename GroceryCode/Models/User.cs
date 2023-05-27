using System.ComponentModel.DataAnnotations;

namespace GroceryCode
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Salt { get; set; }
    }
}
