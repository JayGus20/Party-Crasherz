using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    string Name {
        get;
    }

    float remainingCoolDown {
        get;
        set;
    }

    //On successful cast, returns true.
    public bool UseAbility(PlayerStats playerStats);
    public void Awake();

}