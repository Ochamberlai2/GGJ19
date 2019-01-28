using UnityEngine;

/*
 * Represents any items that may live in the game world
 */
 [CreateAssetMenu(fileName = "New Item", menuName = "Create New Item")]
public class ItemDefinition : ScriptableObject
{

    public Sprite itemSprite;
    public Sprite uiSprite;
    public Constants.InventorySlotType slotType;
    
}
