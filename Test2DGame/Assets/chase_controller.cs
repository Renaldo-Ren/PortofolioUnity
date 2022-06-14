using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase_controller : MonoBehaviour
{
    public boss_move[] bossArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (boss_move boss in bossArray)
            {
                boss.chase = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (boss_move boss in bossArray)
            {
                boss.chase = false;
            }
        }
    }
}
