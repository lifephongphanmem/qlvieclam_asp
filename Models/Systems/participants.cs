using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class participants
    {
        [Key]
        public long id { get; set; }
        public long thread_id { get; set; }
        public long user_id { get; set; }
        public DateTime last_read { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
