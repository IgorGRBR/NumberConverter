using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NumberConverter.Models
{
    [DataContract, Table(name: "User")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember, Column(name: "Id"), Key]
        public int Id { get; private set; }
        [DataMember, Column(name: "Name")]
        public string Name { get; set; }
        [DataMember, Column(name: "Password")]
        public string Password { get; set; }
        [DataMember, Column(name: "CurrentToken")]
        public string CurrentToken { get; set; }
    }
}