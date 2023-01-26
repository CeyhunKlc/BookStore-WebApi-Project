using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{ 
    public class Author
    {
        //internal readonly string Surname;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Surname { get;  set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }  
    }
}