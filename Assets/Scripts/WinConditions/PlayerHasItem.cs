[System.Serializable]
public class PlayerHasItem : WinCondition
{
    public int itemId;
    public override bool PlayerWins() {
        Inventory inventory = LevelManager.Instance.Player.GetComponent<Inventory>();
        return inventory.characterItems.Exists(x => x.id == itemId);
    }
}
