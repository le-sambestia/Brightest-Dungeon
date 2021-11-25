using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Start", 0, 0);
        foreach (Vector2Int roomLocation in rooms)
        {
            RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
        }
    }
}


//Create other rooms in Unity with different names i.e. "TreasureRoom", "ShopRoom".  And then create a function to randomly select one of these as a string and replace "Empty" with that randomly selected string.

//private string GetRandomRoom()
//{
//    int i = Random.Range(0, 2);

//    switch (i)
//    {
//        case 0:
//            return "TreasureRoom";
//            break;
//        case 1:
//            return "ShopRoom";
//            break;
//    }

//    return "Empty";
//}

//Then change this:
//RoomController.Instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);

//to:
//RoomController.Instance.LoadRoom(GetRandomRoom(), roomLocation.x, roomLocation.y);
