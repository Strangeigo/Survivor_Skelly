using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveItem", menuName = "Scriptable Objects/ActiveItem")]
public class ActiveItem : ItemData
{
    private float COOLDOWN;
    [SerializeField] private Stats itemStats;
    public Transform _Target;
    private Dictionary<Stat, float> currentItemStats = new Dictionary<Stat, float>();

    private Dictionary<Stat, float> stats = new Dictionary<Stat, float>();

        private void InitializeStats()
    {
        stats[Stat.ATTACK] = itemStats.ATTACK;
        stats[Stat.MOVEMENT_SPEED] = itemStats.MOVEMENT_SPEED;
        stats[Stat.PROJECTILE_SPEED] = itemStats.PROJECTILE_SPEED;
        stats[Stat.PROJECTILE_AMOUNT] = itemStats.PROJECTILE_AMOUNT;
        stats[Stat.COOLDOWN] = itemStats.COOLDOWN;
        stats[Stat.SIZE] = itemStats.SIZE;
        stats[Stat.HP] = itemStats.HP;
        stats[Stat.REGEN_HP] = itemStats.REGEN_HP;
        stats[Stat.LIFESTEAL] = itemStats.LIFESTEAL;
        stats[Stat.ARMOR] = itemStats.ARMOR;
        stats[Stat.XP] = itemStats.XP;
    }

    public float GetStat(Stat stat)
    {
        return stats.ContainsKey(stat) ? stats[stat] : 0f;
    }

    public void ModifyStat(Stat stat, float amount)
    {
        if (stats.ContainsKey(stat))
            stats[stat] += amount;
    }

    public void SetStat(Stat stat, float value)
    {
        stats[stat] = value;
    }
}
