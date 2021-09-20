using UnityEngine;

public class AmmoItem : MonoBehaviour,IItem
{
    public int m_bullet;
    public bool OnPickUp(PlayerControl.PlayerInventory inventory)
    {
        inventory.TotalAmountOfBullet += m_bullet;
        ItemMarker.itemUpdateRequest+=1;
        return true;
    }
}