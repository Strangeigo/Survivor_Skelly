using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Scriptable Objects/Character Stats")]
public class CharacterStats : Stats
{
    [Header("Character Settings")]
    [SerializeField] private GameObject CharacterPrefab;
}