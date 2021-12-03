using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject roomcont;

    public static GameObject RoomCont { get; private set; }

    void Awake()
    {
        roomcont = GameObject.Find("RoomController");
        GameManager.RoomCont = roomcont;
    }
}
