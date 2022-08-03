using System.ComponentModel.DataAnnotations;
using RPG.Models.Enums;

namespace RPG.Models;

public class RpgSystem : BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; }
    public BaseDiceSystem DiceSystem { get; set; }
    
    public ICollection<CharacterSheet> CharacterSheets { get; set; }
}