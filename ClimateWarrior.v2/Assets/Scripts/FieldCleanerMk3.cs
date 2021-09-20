using UnityEngine;

public class FieldCleanerMk3 : MonoBehaviour,IItem
{
    public bool OnPickUp(PlayerControl.PlayerInventory inventory)
    {
        if (inventory.ClearField)
        {
            return false;
        }
        return inventory.ClearField = true;
    }
}