using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HP;
    public int maxHP;

    // Start is called before the first frame update
    public void takeDamage(int damage)
    {
        HP -= damage;

        if(HP <= 0)
        {
            Death();
        }
    }

    // Update is called once per frame
    void Death()
    {
        Debug.Log("PlayerDead");
    }
}
