using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorEat : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Eat();
        }
    }

    void Eat()
    {
        animator.SetTrigger("Eat");
    }
}
