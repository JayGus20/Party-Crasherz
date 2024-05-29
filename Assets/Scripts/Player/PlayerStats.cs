using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] string characterName;
    [SerializeField] float damage;
    [SerializeField] float health;
    [SerializeField] float effectiveness;
    [SerializeField] float damageReduction;
    [SerializeField] float speed;
    [SerializeField] Ability defaultAbility;
}