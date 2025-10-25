using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private StatsManager stats;
    [SerializeField] private Transform firePoint;

    [Header("Inventory")]
    public int maxActiveSlots = 3;
    public List<ActiveItem> activeItems = new();
    public List<PassiveItem> passiveItems = new();

    private void Update()
    {
        foreach (var active in activeItems)
        {
            active.UpdateItem(stats, transform, firePoint);
        }
    }

    public void PickupItem(ItemData item)
    {
        if (item is ActiveItem active)
        {
            ActiveItem existing = activeItems.Find(i => i.itemName == active.itemName);
            if (existing != null)
            {
                existing.OnUpgrade(stats);
            }
            else if (activeItems.Count < maxActiveSlots)
            {
                activeItems.Add(active);
                active.OnPickup(stats);
            }
        }
        else if (item is PassiveItem passive)
        {
            PassiveItem existing = passiveItems.Find(i => i.itemName == passive.itemName);
            if (existing != null)
            {
                existing.OnUpgrade(stats);
            }
            else
            {
                passiveItems.Add(passive);
                passive.OnPickup(stats);
            }
        }
    }
}
