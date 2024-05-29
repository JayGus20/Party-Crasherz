using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : Ability
{
    public override bool UseAbility(PlayerStats playerStats)
    {
        Debug.Log("ICESPIKE used");
        return true;
    }
}
