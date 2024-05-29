using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public enum ExitType
{
    None,
    North,
    South, 
    West,
    East
}

public enum RoomType
{
    None,
    Shop,
    Gold,
    Abilities,
    UltimateAbilities,
    Boss,
    Miniboss
}

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public List<Room> availableRooms;
    public int currentRoomCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void GetNewRoom(ExitType exitType, Room room)
    {
        //TODO: if statements for when currentRoomCount = a certain thing
        currentRoomCount++;
        availableRooms.Remove(room);
        //chooose random room thatll match the opposite direction where they exited from the last room
        List<Room> matchingRooms = new List<Room>();
        
        foreach(Room availRooms in availableRooms)
        {
            if(GetOppositeDoor(exitType, availRooms))
            {
                matchingRooms.Add(availRooms);
            }
        }

        if(matchingRooms.Count > 0)
        {
            Room newRoom = matchingRooms[Random.Range(0, matchingRooms.Count)];
            // Load the scene associated with the new room
            SceneManager.LoadScene(newRoom.sceneName);
        }
    }

    private bool GetOppositeDoor(ExitType exitType, Room room)
    {
        switch(exitType)
        {
            case ExitType.North: return room.containsSouthDoor;
            case ExitType.South: return room.containsNorthDoor;
            case ExitType.West: return room.containsEastDoor;
            case ExitType.East: return room.containsWestDoor;
            default: return false;
        }
    }
}
