using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASbackend.Models
{
    public class User
    {
        [Key]
        public Guid Id {get; set;}

        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string Email {get; set;}

        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string Password {get; set;}

        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string fullname {get; set;}

        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string cpf {get; set;}

        [Required]
        public required int age {get; set;}

        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string numberphone {get; set;}


        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string adress {get; set;}

        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string duedate {get; set;}

        [Required, Column(TypeName = "VARCHAR(300)")]
        public required string injuryhistory {get; set;}

        [Required, Column(TypeName = "VARCHAR(100)")]
        public required string numberemergency {get; set;}


    }
}