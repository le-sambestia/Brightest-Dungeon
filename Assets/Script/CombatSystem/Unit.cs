using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;

    public int maxDamage;
    public int currentDamage;
    public int maxMagic;
    public int currentMagic;

    public Animator animator;

    public int maxHP;
    public int currentHP;

    void Start()
    {
        animator = animator == null ? GetComponent<Animator>() : animator;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
