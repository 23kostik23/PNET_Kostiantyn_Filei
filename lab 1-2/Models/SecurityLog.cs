using System.ComponentModel.DataAnnotations;

namespace lab_1_2.Models
{
    public class SecurityLog
    {
        [Key]
        public int Log_id { get; set; }
        public DateOnly AttemptDate { get; set; }
        public string Action_type { get; set; }
        public string Message { get; set; }
    }
}
