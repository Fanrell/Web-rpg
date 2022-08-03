using RPG.Models.Enums;

namespace RPG.Contracts;

public class RpgSystemContract
{
    public string Name { get; set; }
    public string DiceSystem { get; set; }
    public DateTime? Modified { get; set; }
}