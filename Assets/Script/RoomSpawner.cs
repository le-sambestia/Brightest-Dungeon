using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 = need bottom room
    //2 = need top room
    //3 = need left room
    //4 = need right room

    void Update()
    {
        switch(openingDirection)
        {
            case 1:
                //spawn door with bottom entrance
                break;
            case 2:
                //spawn door with top entrance
                break;
            case 3:
                //spawn door with left entrance
                break;
            case 4:
                //spawn door with right entrance
                break;
        }

    }
}
