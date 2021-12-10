using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public PlayerUnit prefab;
    public static PlayerUnit instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        GameObject sdinky = (GameObject)Resources.Load("Player");
        prefab = sdinky.GetComponent<PlayerUnit>();

        DontDestroyOnLoad(instance);
    }
    private void OnDestroy()
    {
        prefab.unitName = unitName;
        prefab.unitLevel = unitLevel;

        prefab.maxDamage = maxDamage;
        prefab.maxHP = maxHP;
        prefab.maxMagic = maxMagic;

        prefab.currentDamage = prefab.maxDamage;       
        prefab.currentMagic = prefab.maxMagic;        
        prefab.currentHP = prefab.maxHP;
    }
}
