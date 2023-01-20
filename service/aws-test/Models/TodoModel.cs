using System.ComponentModel.DataAnnotations;

namespace aws_test.Models
{
    public class TodoList
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
    }
}
