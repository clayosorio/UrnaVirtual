using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Threading;
using UrnaVirtual.Constantes;

namespace UrnaVirtual.Modelos
{
    public class Aspirant
    {
		[JsonIgnore]
		[Key]
        public Guid AspirantId { get; set; }
        [Required]
        public string FullNameAspirant { get; set; }
        [Required]
        [MaxLength(10)]
        public string ID { get; set; }
        [Required]
        public DateTime ExpeditionDateID { get; set; }
        [Required]
        public string PoliticParty { get; set; }
        public Cities City { get; set; }
        [Required]
        public Departments Departments { get; set; }
    }
}

