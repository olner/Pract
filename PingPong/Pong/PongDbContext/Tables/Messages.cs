using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pong.PongDbContext.Tables
{
    [Table ("messages")]
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Text { get; set; }

        [Column("id_user")]
        [ForeignKey("userId")]
        public string IdUser { get; set; }

    }
}
