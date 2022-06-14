using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator_FollowMouse : MonoBehaviour
{
    //public float maxMoveSpeed = 10;
    //public float smoothTime = 0.3f;
    //public float minDistance = 1;
    public Transform predator;
    private float x = 1f;
    private float y = 1f;
    public float speed = 1;
    public StamminaBar staminaBar;

    public AudioSource playSound,jellySFX;

    private float dir;
    float runSpeedModifier = 2f;
    bool isRunning = false;

    public int velocity;
    private Vector3 movement;
    private Rigidbody2D predatorRigidbody2D;
    private Animator predatorAnimator;

    private bool predaIsFacingRight = false;
    // private bool predaIsJumping = false;
    // private bool predaIsGrounded = false;

    // public Transform groundCheck;
    // public float groundCheckRadius;
    // public LayerMask ground;
    public float moveInputX;
    public float moveInputY;
    public float xVal;
    public float yVal;
    public float predatorSpeed;
    public float predatorJumpForce;

    [SerializeField]
    private GameObject fish;

    void Start()
    {
        predatorRigidbody2D = GetComponent<Rigidbody2D>();
        predatorAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");
        //predatorAnimator.SetFloat("Horizontal", movement.x);
        //predatorAnimator.SetFloat("Vertical", movement.y);
        //predatorAnimator.SetFloat("Amount", movement.magnitude);

        transform.position = transform.position + movement * velocity * Time.deltaTime;
        
        if (Input.GetMouseButtonDown(1) && staminaBar.stamina.staminaAmount > 10f)
        {
            isRunning = true;
        }

        else if (Input.GetMouseButtonUp(1))
        {
            isRunning = false;
        }


    }
    private void FlipPredator()
    {
        predaIsFacingRight = !predaIsFacingRight;

        Vector3 predatorScale = transform.localScale;
        predatorScale.x *= -1;

        transform.localScale = predatorScale;
    }

    void FixedUpdate()
    {
        
        //predatorRigidbody2D.velocity = new Vector2(moveInput * predatorSpeed, predatorRigidbody2D.velocity.y);
        if (moveInputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveInputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        Move(moveInputX, moveInputY);
    }
    void Move(float dir, float dirY)
    {
        if (moveInputX != 0 && moveInputY != 0)
        {
            xVal = dir * speed * 100 * Time.deltaTime;
            yVal = dirY * speed * 50 * Time.deltaTime;
        }
        else
        {
            xVal = dir * speed * 100 * Time.deltaTime;
            yVal = dirY * speed * 100 * Time.deltaTime;
        }
        
        if (isRunning)
        {
            if(staminaBar.stamina.staminaAmount > 10f){
                xVal *= runSpeedModifier;
                yVal *= runSpeedModifier;
            }
            
        }

        Vector2 targetVelocity = new Vector2(xVal, yVal);
        predatorRigidbody2D.velocity = targetVelocity;
        if (moveInputX == 0 && moveInputY != 0)
        {
            predatorAnimator.SetFloat("xVelocity", Mathf.Abs(predatorRigidbody2D.velocity.y));
        }
        else
        {
            predatorAnimator.SetFloat("xVelocity", Mathf.Abs(predatorRigidbody2D.velocity.x));
        }

        Debug.Log(predatorRigidbody2D.velocity.x);
        Debug.Log(predatorRigidbody2D.velocity.y);
    }
    
    private void SpawnFish()
    {
        bool fishSpawned = false;
        while (!fishSpawned)
        {
            Vector3 fishPos = new Vector3(Random.Range(-(transform.position.x)-8f, (transform.position.x)+8f), Random.Range(-(transform.position.y) - 8f, (transform.position.y) + 8f), -1f);
            if ((fishPos - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(fish, fishPos, Quaternion.identity);
                fishSpawned = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bossTrigger"))
            return;
        else if (collision.CompareTag("jellyFish"))
            jellySFX.Play();
        else if (collision.CompareTag("bossJaw"))
            return;
        else
        {
            Vector3 predatorScale = transform.localScale;
            // predatorScale.x *= -1;
            // transform.localScale = predatorScale;
            if (predatorScale.x > 2.9f)
            {
                x += 0f;
                y += 0f;
            }
            else if (predatorScale.x > 0 && predatorScale.x <= 2.9f)
            {
                x += .1f;
                y += .1f;
            }
            predator.localScale = new Vector3(x, y);
            predatorAnimator.SetTrigger("Eat");
            Destroy(collision.gameObject);
            playSound.Play();
        }
            
    }
}
