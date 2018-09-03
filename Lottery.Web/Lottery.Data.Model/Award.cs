using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lottery.Data.Model
{
    // This attribute is here if we want to give a specific name of the table created for awards in SQL
    [Table("Awards")]
    public class Award : IEntity
    {
        [Key] // Attribute for defining a primary key
        [Column("AwardID", Order = 0)] // Binding this property to a specific column in the SQL table
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating an auto increment primary key
        public int Id { get; set; }
        public string AwardName { get; set; }
        public string AwardDescription { get; set; }
        public int Quantity { get; set; }
        // We put byte here because we know we are going to have less than 8 types here
        public byte RuffledType { get; set; } //ENUM values: Immediate/PerDay/Final
    }
}
