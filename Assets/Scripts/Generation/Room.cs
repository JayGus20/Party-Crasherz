using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour, IEquatable<Room>
{
    [Header("Room Information")]
    public string sceneName;
    public bool containsEnemies;
    public List<Enemy> enemies;
    public float canLeaveTimer;
    [Header("Door Information")]
    public bool containsNorthDoor;
    public bool containsSouthDoor;
    public bool containsWestDoor;
    public bool containsEastDoor;
    public bool containsNoDoors;
    public bool multipleSameNorthDoors;
    public bool multipleSameSouthDoors;
    public bool multipleSameEastDoors;
    public bool multipleSameWestDoors;
    public List<Transform> northSpawnPos;
    public List<Transform> southSpawnPos;
    public List<Transform> eastSpawnPos;
    public List<Transform> westSpawnPos;


    public bool Equals(Room room) 
    {
        if (sceneName != room.sceneName) {
            return false;
        }
        return true;
    }

    void OnEnable()
    {
        DetermineWherePlayersSpawn();
    }

    void DetermineWherePlayersSpawn()
    {
        switch(RoomManager.instance.lastExit)
        {
            case ExitType.None: 
                break;
            case ExitType.North:
                if(multipleSameNorthDoors)
                {
                    Transform randomNorthPos = northSpawnPos[Random.Range(0, northSpawnPos.Count)];
                    Player.instance.transform.position = randomNorthPos.position;
                }
                else
                {
                    Player.instance.transform.position = northSpawnPos[0].position;
                }
                break;
            case ExitType.South:
                if(multipleSameSouthDoors)
                {
                    Transform randomSouthPos = southSpawnPos[Random.Range(0, southSpawnPos.Count)];
                    Player.instance.transform.position = randomSouthPos.position;
                } 
                else
                {
                    Player.instance.transform.position = southSpawnPos[0].position;
                }               
                break;
            case ExitType.East:
                if(multipleSameEastDoors)
                {
                    Transform randomEastPos = eastSpawnPos[Random.Range(0, eastSpawnPos.Count)];
                    Player.instance.transform.position = randomEastPos.position;
                }
                else
                {
                    Player.instance.transform.position = eastSpawnPos[0].position;
                }
                break;
            case ExitType.West:
                if(multipleSameWestDoors)
                {
                    Transform randomWestPos = westSpawnPos[Random.Range(0, eastSpawnPos.Count)];
                    Player.instance.transform.position = randomWestPos.position;
                }
                else
                {
                    Player.instance.transform.position = westSpawnPos[0].position;
                }
                break;
        }
    }
}
