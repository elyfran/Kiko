using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class EventType
    {
        public EventType()
        {
            Eventnotes = new List<Eventnote>();
         }
        [Required]
        public byte Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public virtual ICollection<Eventnote> Eventnotes { get; set; }

    }
}