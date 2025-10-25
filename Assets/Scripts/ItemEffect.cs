using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "Scriptable Objects/ItemEffect")]
public abstract class ItemEffect : ScriptableObject
{
    [HideInInspector] public int stackCount = 1;

    public abstract void OnEquip(GameObject owner);
    public abstract void Trigger(GameObject owner);
    public abstract void OnUnequip(GameObject owner);

    // Called when the player gets the same item again
    public virtual void Stack(GameObject owner)
    {
        stackCount++;
    }
}
