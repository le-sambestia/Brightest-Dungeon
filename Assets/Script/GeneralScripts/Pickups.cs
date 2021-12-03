using UnityEngine;

public class LootItem
{
    public string itemName;
    public int dropChance;

    public LootItem(string newItemName, int newItemDropChance)
    {
        itemName = newItemName;
        dropChance = newItemDropChance;
    }
}
public class Pickups : MonoBehaviour
{
    float[] myArray = new float[] { 1,2,3,4,5,6,7,8,9,10};
    
}
