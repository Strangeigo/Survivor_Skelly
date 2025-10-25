using System.Collections.Generic;
using UnityEngine;
public class ItemManager : MonoBehaviour
{
    public List<ItemData> equippedItems = new List<ItemData>();
    private Dictionary<ItemData, ItemEffect> activeItemsDict = new();
    private Dictionary<ItemData, ItemEffect> passiveEffectsDict = new();

    public void EquipItem(ItemData item)
    {
        if (!activeItemsDict.ContainsKey(item))
        {
            ItemEffect instance = Instantiate(item.effect); // make a unique instance
            instance.OnEquip(gameObject);
            activeItemsDict[item] = instance;
        }
    }

    public void UseItem(ItemData item)
    {
        if (activeItemsDict.TryGetValue(item, out ItemEffect effect))
        {
            effect.Trigger(gameObject);
        }
    }

    public void UnequipItem(ItemData item)
    {
        if (activeItemsDict.TryGetValue(item, out ItemEffect effect))
        {
            effect.OnUnequip(gameObject);
            activeItemsDict.Remove(item);
        }
    }
}

