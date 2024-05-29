using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wizard : Player
{
    [SerializeField] Ability ability3;

    public override void UseWeapon() {
        ability3.UseAbility(playerStats);
    }
}