using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EntrancePoint
{

}

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] Ability ability1;
    [SerializeField] Ability ability2;

    protected PlayerStats playerStats; 

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void UseWeapon() {
        Debug.Log("No Weapon");
    }

    public void UseAbility1() {
        ability1.UseAbility(playerStats);
    }

    public void UseAbility2() {
        ability2.UseAbility(playerStats);
    }
}