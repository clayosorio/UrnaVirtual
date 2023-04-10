using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UrnaVirtual.Modelos
{
    public class Vote
    {
        [Key]
        public Guid VoteId { get; set; }
        [ForeignKey("VoterId")]
        public Guid VoterId { get; set; }
        [ForeignKey("AspirantId")]
        public Guid AspirantId { get; set; }

        [JsonIgnore]
        public virtual Voter? Voter { get; set; }
        [JsonIgnore]
        public virtual Aspirant? Aspirant { get; set; }
        [Required]
        public DateTime VoteDate { get; set; }
    }
}
