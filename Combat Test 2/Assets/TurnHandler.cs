using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

public enum BattleState
{
    Start, // Start of battle
    PlayerTurn, // Player action
    EnemyTurn, // Enemy action
    FinishedTurn, // All turns finished
    Won, // No enemies left
    Lost // Player dead
}


public class TurnHandler : MonoBehaviour
{
    public BattleState state;

    //public EnemyProfile[] EnemiesInBattle; //each enemy in battle
    private bool enemyActed;
    private GameObject[] EnemyAttacks; //all enemy attacks

    public GameObject PlayerUI; //all active UI during player turn
    public PlayerMovement Player;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        enemyActed = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BattleState.Start)
        {
            //setup the UI
            PlayerUI.SetActive(true);
            state = BattleState.PlayerTurn; 
        }
        else if (state == BattleState.PlayerTurn)
        {
            // get input from player
            // or wait until player time is up
        }
        else if (state == BattleState.EnemyTurn)
        {
            if (EnemiesInBattle.Length <= 0)
            {
                // if there are no enemies still alive end battle
                EnemyFinishedTurn();
            }
            else
            {
                if (!enemyActed)
                {
                    // let player move around/use defensive actions
                    Player.gameObject.SetActive(true);
                    //Player.SetHeart();

                    foreach(EnemyProfile enemy in EnemiesInBattle) 
                    {
                        // for every enemy
                        // pick a random number attacks between 0 and how many they know
                        int AttackNumb = Random.Range(0, enemy.EnemyAttacks.Length);

                        Instantiate(enemy.EnemyAttacks[AttackNumb], Vector3.zero, Quaternion.identity);

                    }

                    // find all attacks in scene to check when theyre done
                    HostileAttacks = GameObject.FindGameObjectsWithTag("Enemy");
                    enemyActed = true;
                }
                else 
                {
                    bool enemyFinished = true;
                    foreach (GameObject enemy in HostileAttacks)
                    {
                        if(!enemy.GetComponent<EnemyTurnHandle>().FinishedTurn)
                        {
                            enemyFinished = false;
                        }
                    }

                    if (enemyFinished)
                    {
                        EnemyFinishedTurn();
                    }
                }
            }
            //enemy take turn
        }
        else if (state == BattleState.FinishedTurn)
        {
            // turn is over turn off player movement
            Player.gameObject.SetActive(false);

            //check if the player is alive at the end of turn
            if (Player.GetComponent<PlayerHealth>().HP < 0)
            {
                state = BattleState.Lost;
            }
            else
            {
                // if enemy health at 0, then win
                state = BattleState.Start;
            }
        }
        else if (state == BattleState.Won)
        {

        }
    }

    public void PlayerAct()
    {
        // bring up the menu of player actions

        PlayerFinishedTurn();
    }

    void PlayerFinishedTurn()
    {
        PlayerUI.SetActive(false);

        state = BattleState.EnemyTurn;
    }

    void EnemyFinishedTurn()
    {
        //destroy all attacks
        foreach(GameObject obj in HostileAttacks)
        {
            Desroy(obj);
        }

        enemyActed = false;
        state = BattleState.FinishedTurn;
    }
}

*/
