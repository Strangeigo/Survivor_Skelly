using System.Collections.Generic;
using UnityEngine;

public enum Stat {
    ATTACK, MOVEMENT_SPEED, PROJECTILE_SPEED, PROJECTILE_AMOUNT,
    COOLDOWN, SIZE, HP, REGEN_HP, LIFESTEAL, ARMOR, XP
}

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject
{
    public string NAME;

    [Header("Base Stats")]
    public float ATTACK = 1;
    public float MOVEMENT_SPEED = 5;
    public float PROJECTILE_SPEED = 10;
    public float PROJECTILE_AMOUNT = 1;
    public float COOLDOWN = 1;
    public float SIZE = 1;
    public float HP = 100;
    public float REGEN_HP = 0;
    public float LIFESTEAL = 0;
    public float ARMOR = 0;
    public float XP = 0;
}
