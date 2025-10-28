using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public abstract class ItemData : ScriptableObject
{
    
[Header("Item Info")]
    public string itemName;
    public string description;
    public Sprite icon;

    [Header("Leveling")]
    public int level = 1;
    public int maxLevel = 5;

    public abstract void OnPickup(StatsManager stats);
    public abstract void OnUpgrade(StatsManager stats);
}