using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
        public bool Top { get; set; }
        public int ParentId { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Content { get; set; }
    }
}
