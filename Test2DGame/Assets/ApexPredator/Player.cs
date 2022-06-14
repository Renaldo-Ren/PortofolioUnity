using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Player : MonoBehaviour
{
    public float health;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
        FunctionPeriodic.Create(() => {
            if (health > .001f){
                health -= .001f;
                healthBar.SetSize(health);
            }

        }, .03f);
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 1f)
        {
            health = 1f;
        }
        //Starving();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bossTrigger"))
            return;
        else if (collision.CompareTag("jellyFish"))
            health -= .05f;
        else if (collision.CompareTag("bossJaw"))
            health -= .1f;
        else
        {
            ScoreScript.scoreValue += 10;
            health += .05f;
        }
        
    }
}
