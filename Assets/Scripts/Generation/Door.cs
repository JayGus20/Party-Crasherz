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
                Player.instance.entrancePoint = EntrancePoint.South;
                break;
            case ExitType.South:
                Player.instance.entrancePoint = EntrancePoint.North;
                break;
            case ExitType.East:
                Player.instance.entrancePoint = EntrancePoint.West;
                break;
            case ExitType.West:
                Player.instance.entrancePoint = EntrancePoint.East;
                break;
        }
    }
}
