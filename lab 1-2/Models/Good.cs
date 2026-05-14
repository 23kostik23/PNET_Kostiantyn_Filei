using System.ComponentModel.DataAnnotations;

namespace lab_1_2.Models
{
    public class Good
    {
        [Key]
        public int Good_id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Producer { get; set; }
        public static int Dept_id { get; }
        public string Description { get; set; }
    }
}
