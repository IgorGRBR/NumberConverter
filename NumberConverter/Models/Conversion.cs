using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NumberConverter.Models
{
    [DataContract, Table(name: "Conversion")]
    public class Conversion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember, Column(name: "Id"), Key]
        public int Id { get; private set; }
        [DataMember, Column(name: "Original")]
        public string Original { get; set; }
        [DataMember, Column(name: "Converted")]
        public string Converted { get; set; }
        [DataMember, Column(name: "ConversionTime")]
        //SQLite doesn't seem to support datetimes
        public string ConversionTime { get; set; } 
        [DataMember, Column(name: "UserId")]
        public int UserId { get; set; }
    }
}