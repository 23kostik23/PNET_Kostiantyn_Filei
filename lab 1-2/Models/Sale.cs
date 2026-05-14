using System.ComponentModel.DataAnnotations;

namespace lab_1_2.Models
{
    public class Sale
    {
        [Key]
        public int Sale_id { get; set; }
        public int Check_no { get; set; }
        public static int Good_id { get; }
        public DateOnly Date_sale {  get; set; }
        public int Quantity { get; set; }
    }
}
