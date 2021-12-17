using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject enemyPrefab;
    public GameObject[] enemyList;
    int randomEnemy;
    public bool isBoss;



    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public GameObject fireButton;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {

        randomEnemy = Random.Range(0, enemyList.Length);
        enemyPrefab = enemyList[randomEnemy];
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        if(RandomItems.fireMagicActive == true)
        {
            fireButton.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        playerUnit.animator.SetBool("IsAttacking", true);
        bool isDead = enemyUnit.TakeDamage(playerUnit.currentDamage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The enemy took " + playerUnit.currentDamage + " damage";

        yield return new WaitForSeconds(2f);
        playerUnit.animator.SetBool("IsAttacking", false);

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerFire()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.currentMagic);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The enemy took " + playerUnit.currentMagic + " damage";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks for " + enemyUnit.currentDamage;
        enemyUnit.animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(2f);
        enemyUnit.animator.SetBool("IsAttacking", false);
        bool isDead = playerUnit.TakeDamage(enemyUnit.currentDamage);

        playerHUD.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }
        else
        {
            enemyUnit.currentDamage = enemyUnit.maxDamage;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EndBattle()
    {
        if(state == BattleState.WON)
        {
            if(isBoss ==false)
            {
                enemyUnit.animator.SetBool("IsDead", true);
                dialogueText.text = "You Won";
                yield return new WaitForSeconds(3f);
                SceneManager.LoadScene("Rewards", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(RoomController.instance.currentWorldName + "Combat");
            }
            else if (isBoss == true)
            {
                enemyUnit.animator.SetBool("IsDead", true);
                dialogueText.text = "You Beat the Floor Boss";
                yield return new WaitForSeconds(3f);
                SceneManager.LoadScene("Boss Rewards", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(RoomController.instance.currentWorldName + "Boss");
            }
        }
        else if(state == BattleState.LOST)
        {
            if (isBoss == false)
            {
                playerUnit.animator.SetBool("IsDead", true);
                dialogueText.text = "You lost";
                yield return new WaitForSeconds(3f);
                SceneManager.LoadScene("FailScreen");
            }
            else if (isBoss == true)
            {
                playerUnit.animator.SetBool("IsDead", false);
                dialogueText.text = "You Beat the Floor Boss";
                yield return new WaitForSeconds(3f);
                SceneManager.LoadScene("FailScreen");
            }
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(playerUnit.currentMagic);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You have been healed";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerDefend()
    {
        enemyUnit.currentDamage /= 2;
        dialogueText.text = "You have blocked";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    public void OnDefendButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerDefend());
    }

    public void OnFireButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerFire());
    }
}
