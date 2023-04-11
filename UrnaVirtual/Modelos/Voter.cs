using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UrnaVirtual.Constantes;

namespace UrnaVirtual.Modelos
{
    public class Voter
    {

		[JsonIgnore]
		[Key]
        public Guid VoterId { get; set; }
        [Required]
        public string FullNameVoter { get; set; }
        [Required]
        public string ID { get; set; }
        [Required]
        public DateTime ExpeditionDateID { get; set; }
        [Required]
        public Cities City { get; set; }
        [Required]
        public Departments Departments { get; set; }

    }
}


