using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public float speed = 10;
    public float jumpPower = 10;

    float horizontalMovement;
    bool isJumping = false;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    public static Player playerReference;



    // Start is called before the first frame update
    private void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (playerReference == null)
        {
            playerReference = FindObjectOfType<Player>();

        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Cancel") == 1)
        {
            SceneManager.LoadScene("Menu");
        }

        horizontalMovement = Input.GetAxis("Horizontal"); //Left + right
        isJumping = Input.GetAxis("Jump") > 0 ? true : false; //Jumping
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);

        if (isJumping)
        {
            Vector3 feetPosition = transform.GetChild(0).position;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition, 0.25f);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject == gameObject)
                    continue;

                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpPower);
                break;
            }

        }

        if (rb.velocity.magnitude > 0.05f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }


        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }


    }




    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Died");
        }

    }

}
