using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject roomcont;

    PlayerUnit prefab;

    public static GameObject RoomCont { get; private set; }

    void Awake()
    {
        roomcont = GameObject.Find("RoomController");
        GameManager.RoomCont = roomcont;

        GameObject sdinky = (GameObject)Resources.Load("Player");
        prefab = sdinky.GetComponent<PlayerUnit>();

        prefab.maxDamage = 10;
        prefab.currentDamage = prefab.maxDamage;
        prefab.maxMagic = 5;
        prefab.currentMagic = prefab.maxMagic;
        prefab.maxHP = 25;
        prefab.currentHP = prefab.maxHP;
    }
}
