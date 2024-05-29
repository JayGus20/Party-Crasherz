using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Ability
{
    public override bool UseAbility(PlayerStats playerStats)
    {
        Debug.Log("Fire used0");
        return true;
    }

}
