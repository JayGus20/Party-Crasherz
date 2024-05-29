using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Ability : MonoBehaviour, IAbility
{
    private string _name;
    public string Name { get => _name; }

    private float _remainingCoolDown;
    public float remainingCoolDown { get => _remainingCoolDown; set => _remainingCoolDown = value; }
    public virtual void Awake()
    {
        // Do nothing
    }

    public abstract bool UseAbility(PlayerStats playerStats);
}