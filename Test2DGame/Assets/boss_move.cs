using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_move : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    private bool bossFacingRight = false;
    public Transform startingPoint;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
            ReturnStartPoint();
        Flip();
    }

    private void Chase()
    {
        Vector2 accuratePlayerPos = player.transform.position;
        accuratePlayerPos.y = accuratePlayerPos.y - 4f;
        transform.position = Vector2.MoveTowards(transform.position, accuratePlayerPos, speed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x+6f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //FlipBoss();
            //bossFacingRight = true;
        }
        else if (transform.position.x <= player.transform.position.x-6f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //FlipBoss();
            //bossFacingRight = false;
        }
    }
    private void FlipBoss()
    {
        bossFacingRight = !bossFacingRight;
        Vector3 bossScale = transform.localScale;
        bossScale.x *= -1;
        transform.localScale = bossScale;
    }
}
