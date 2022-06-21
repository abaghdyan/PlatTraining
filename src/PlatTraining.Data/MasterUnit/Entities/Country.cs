using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatTraining.Data.MasterUnit.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Fips { get; set; }
        public string Iso { get; set; }
        public string DomainCode { get; set; }
        public string Name { get; set; }
    }
}