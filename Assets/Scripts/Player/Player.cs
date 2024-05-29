using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EntrancePoint
{
    None,
    North,
    South,
    East,
    West
}

public class Player : MonoBehaviour
{
    public static Player instance;
    public EntrancePoint entrancePoint;

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
}
