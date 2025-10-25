using UnityEngine;

[CreateAssetMenu(menuName = "Items/Passive Item")]
public class PassiveItem : ItemData
{
    [Header("Stat Bonuses")]
    public float attackBonus = 0;
    public float moveSpeedBonus = 0;
    public float projectileAmountBonus = 0;
    public float regenBonus = 0;

    public override void OnPickup(StatsManager stats)
    {
        ApplyBonuses(stats);
    }

    public override void OnUpgrade(StatsManager stats)
    {
        level++;
        ApplyBonuses(stats);
    }

    private void ApplyBonuses(StatsManager stats)
    {
        stats.ModifyStat(Stat.ATTACK, attackBonus);
        stats.ModifyStat(Stat.MOVEMENT_SPEED, moveSpeedBonus);
        stats.ModifyStat(Stat.PROJECTILE_AMOUNT, projectileAmountBonus);
        stats.ModifyStat(Stat.REGEN_HP, regenBonus);
    }
}