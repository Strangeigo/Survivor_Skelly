using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private Stats currentCharacter;

    public Dictionary<Stat, float> characterStats = new Dictionary<Stat, float>();

    public string CharacterName => currentCharacter.NAME;

    void Awake()
    {
        InitializeStats();
    }

    private void InitializeStats()
    {
        characterStats[Stat.ATTACK] = currentCharacter.ATTACK;
        characterStats[Stat.MOVEMENT_SPEED] = currentCharacter.MOVEMENT_SPEED;
        characterStats[Stat.PROJECTILE_SPEED] = currentCharacter.PROJECTILE_SPEED;
        characterStats[Stat.PROJECTILE_AMOUNT] = currentCharacter.PROJECTILE_AMOUNT;
        characterStats[Stat.COOLDOWN] = currentCharacter.COOLDOWN;
        characterStats[Stat.SIZE] = currentCharacter.SIZE;
        characterStats[Stat.HP] = currentCharacter.HP;
        characterStats[Stat.REGEN_HP] = currentCharacter.REGEN_HP;
        characterStats[Stat.LIFESTEAL] = currentCharacter.LIFESTEAL;
        characterStats[Stat.ARMOR] = currentCharacter.ARMOR;
        characterStats[Stat.XP] = currentCharacter.XP;
    }

    public float GetStat(Stat stat)
    {
        return characterStats.ContainsKey(stat) ? characterStats[stat] : 0f;
    }

    public void ModifyStat(Stat stat, float amount)
    {
        if (characterStats.ContainsKey(stat))
            characterStats[stat] += amount;
    }

    public void SetStat(Stat stat, float value)
    {
        characterStats[stat] = value;
    }
}
