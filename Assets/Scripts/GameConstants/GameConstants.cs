namespace GameConstants
{
    public enum GameState
    {
        UI,
        Gameplay,
        Pause,
    }
    public enum ItemType
    {
        Equipment,
        Consumable,
        Resource,
    }
    public enum EquipmentType
    {
        Weapon,
        Armor,
        Ring,
    }
    public enum ConsumableType
    {
        Food,
        Potion,
    }
    public enum ResourceType
    {
        Metal,
        Ore,
        Rock,
        Herb,
    }
    public enum IntDataReference
    {
        Health,
        MaxHealth,
    }
    public enum BoolDataReference {}
    public enum FloatDataReference
    {
        WalkSpeed,
        RunSpeed,
    }
    public enum ActionReference {}
}
