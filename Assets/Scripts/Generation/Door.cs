using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Room room;
    [SerializeField] ExitType exitType;
    
    void Awake()
    {
        room = GetComponentInParent<Room>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            RoomManager.instance.GetNewRoom(exitType, room);
            SetPlayerNextPosition();
        }
    }

    void SetPlayerNextPosition()
    {
        switch(exitType)
        {
            case ExitType.None: 
                break;
            case ExitType.North:
                RoomManager.instance.lastExit = ExitType.South;
                break;
            case ExitType.South:
                RoomManager.instance.lastExit = ExitType.North;
                break;
            case ExitType.East:
                RoomManager.instance.lastExit = ExitType.West;
                break;
            case ExitType.West:
                RoomManager.instance.lastExit = ExitType.East;
                break;
        }
    }
}
