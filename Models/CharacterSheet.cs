using System.ComponentModel.DataAnnotations;

namespace RPG.Models;

public class CharacterSheet : BaseEntity
{
    [StringLength(50)]
    public string CharacterName { get; set; }
    [StringLength(255)]
    public string CharacterDescription { get; set; }
    public string Abilities { get; set; }
    public string Skills { get; set; }
    public string Inventory { get; set; }
    public string AdditonalFields { get; set; }
    public Guid RpgSystemId { get; set; }
    
    public RpgSystem RpgSystem { get; set; }
}