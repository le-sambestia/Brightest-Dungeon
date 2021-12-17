using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomItems : MonoBehaviour
{
    public List<GameObject> itemList = new List<GameObject>();
    GameObject itemPrefab;
    public int randomItem;
    public Transform spawn;

    public static bool fireMagicActive = false;
    PlayerUnit prefab;
    Item chosenItem;
    Unit player;


    public Text itemText;

    public void Start()
    {
        GameObject sdinky = (GameObject)Resources.Load("Player");
        prefab = sdinky.GetComponent<PlayerUnit>();

        randomItem = Random.Range(0, itemList.Count);
        itemPrefab = itemList[randomItem];
        GameObject playerGO = Instantiate(itemPrefab, spawn);
        chosenItem = playerGO.GetComponent<Item>();
        itemList.RemoveAt(randomItem);

        itemText.text = "You got " + chosenItem.itemName + "\n" + chosenItem.itemDesc + "\n" + chosenItem.itemEffect;

        switch(randomItem)
        {
            case 0:
                GetStick();
                break;
            case 1:
                GetFireMagic();
                break;
            case 2:
                GetBigStick();
                break;
            case 3:
                GetBiggerStick();
                break;
            case 4:
                GetDetermination();
                break;
            case 5:
                GetWeirdPotion();
                break;
        }

        prefab.currentDamage = prefab.maxDamage;
        prefab.currentMagic = prefab.maxMagic;
        prefab.currentHP = prefab.maxHP;
    }

    void GetStick()
    {
        prefab.maxDamage += 5;
    }
    void GetFireMagic()
    {
        fireMagicActive = true;
    }
    void GetBigStick()
    {
        prefab.maxDamage += 7;
    }
    void GetBiggerStick()
    {
        prefab.maxDamage += 12;
    }
    void GetDetermination()
    {
        prefab.maxMagic += 5;
    }
    void GetWeirdPotion()
    {
        prefab.maxHP += 5;
    }
}
