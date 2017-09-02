using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public bool Jumping { get; set; }
    public bool Attacking { get; set; }

    public GameObject YouDiedPanel;
    public Slider HealthBar;

    public float speed = 20f,
        maxSpeed = 5f,
        jumpForce = 300f;
    
    private Rigidbody2D rb2d;
    private Animator anim;

    private const int maxHealth = 5;
    private const float attackLength = 0.5f,
        dieLength = 1f;

    private bool alive, hurtFlag;

	// Use this for initialization
	void Start ()
    {
        if (YouDiedPanel != null)
            YouDiedPanel.SetActive(false);

        if (HealthBar != null)
            HealthBar.value = maxHealth;

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        alive = true;
        hurtFlag = false;

        Attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        // animate speed

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Jumping", Jumping);

        Debug.Log("Anim speed: " + anim.GetFloat("Speed"));

        // handle input

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attacking!");
            //playerAnimator.Attack();
            StartCoroutine(Attack());
        }

        // death

        if (HealthBar.value <= 0 && alive)
        {
            //playerAnimator.Die();
            StartCoroutine(Die());
            alive = false;
        }

        if (!alive)
            YouDiedPanel.SetActive(true);
    }

    void FixedUpdate()
    {
        if (alive)
        {
            // friction

            //if (!playerAnimator.Jumping)
            if(!Jumping)
            {
                Vector3 velocity = rb2d.velocity;
                velocity.x *= 0.8f;
                rb2d.velocity = velocity;
            }

            // handle input

            //if (Input.GetButtonDown("Jump") && !playerAnimator.Jumping)
            if(Input.GetButtonDown("Jump") && !Jumping)
                rb2d.AddForce(Vector2.up * jumpForce);

            float axis = Input.GetAxis("Horizontal");

            rb2d.AddForce(Vector2.right * axis * speed);

            if (hurtFlag)
            {
                hurtFlag = false;
                rb2d.AddForce(Vector2.up * 20);
            }

            // clamp the max speed

            if (rb2d.velocity.x > maxSpeed)
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

            if (rb2d.velocity.x < -maxSpeed)
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

            // flip on X-axis

            if (rb2d.velocity.x < -0.1f)
                transform.localScale = new Vector3(-1, 1, 1);

            if (rb2d.velocity.x > 0.1f)
                transform.localScale = new Vector3(1, 1, 1);
            //playerAnimator.Speed = Mathf.Abs(rb2d.velocity.x);
        }
    }

    public void GetHurt()
    {
        hurtFlag = true;

        HealthBar.value -= 1;
    }

    private IEnumerator Attack()
    {
        Attacking = true;

        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(attackLength);

        Attacking = false;
    }

    private IEnumerator Die()
    {
        anim.SetTrigger("Dying");

        yield return new WaitForSeconds(dieLength);

        anim.SetBool("Dead", true);
    }
}
