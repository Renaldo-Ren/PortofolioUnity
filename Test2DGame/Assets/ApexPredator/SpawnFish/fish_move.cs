using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_move : MonoBehaviour
{
    public bool fishIsFacingRight;



    public float minTime = 1f;
    public float maxTime = 8f;

    public float minVelocity_Horizontal = -5f;
    public float maxVelocity_Horizontal = 5f;

    public float minVelocity_Vertical = -3f;
    public float maxVelocity_Vertical = 3f;

    private float timer = 0f;
    private float count = 0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Timer = Random.Range(0f, 10f);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0 && count == 0)
        {
            timer = Random.Range(minTime, maxTime);
            fish_behavior();
        }
        else
        {
            count += 1 * Time.deltaTime;
            if(count >= timer)
            {
                timer = 0;
                count = 0;
            }
        }
        Debug.Log(timer);
    }
    private void fish_behavior()
    {
        float velocity_horizontal = Random.Range(minVelocity_Horizontal, maxVelocity_Horizontal);
        float velocity_vertical = Random.Range(minVelocity_Vertical, maxVelocity_Vertical);
        rb.velocity = new Vector2(velocity_horizontal, velocity_vertical);
        if (velocity_horizontal > 0 && fishIsFacingRight == false) // Facing left
        {
            FlipFish();
        }
        else if(velocity_horizontal < 0 && fishIsFacingRight == true) // Facing Right
        {
            FlipFish();
        }
    }
    private void FlipFish()
    {
        fishIsFacingRight = !fishIsFacingRight;

        Vector3 fishScale = transform.localScale;
        fishScale.x *= -1;

        transform.localScale = fishScale;
    }
}
