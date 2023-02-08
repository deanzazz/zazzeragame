using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControllerTest : MonoBehaviour
{

    public float speed = 200f;
    public int hp;
    public int garbage = 10;
    public bool jump, isGrounded;
    public float jumpForce = 400; //y value for our jumping force
    public LayerMask groundLayers;
    public Transform groundCheck;
    private float groundCheckRadius = .1f;

    private bool isFacingRight, idle;

    private Animator anim;
    private Rigidbody2D myBody;

    // Use this for initialization
    void Start()
    {
        //initialize your stuffs here.
        anim = GetComponent<Animator> ();
        isFacingRight = true;
        idle = true;
        myBody = GetComponent<Rigidbody2D>();
        anim.SetBool ("idle", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Jump") && isGrounded) {
            jump = true;
		}
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayers);
        anim.SetBool ("isGrounded", isGrounded);
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat ("movingValue", moveX);
        if (jump)
        {
            jump = false;
            myBody.AddForce(new Vector2(0f, jumpForce));
        }
        //float moveY = Input.GetAxis("Vertical"); //needed for non jumping
        Vector2 moving = new Vector2 (moveX * speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        //Vector2 moving = new Vector2(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime);
        if (moveX == 0f)
        {  //REMEMBER THE f!!
            idle = true;
        }
        else
        {
            idle = false;
        }
        anim.SetBool ("idle", idle);
        if ((moveX > 0.0f && !isFacingRight) || (moveX < 0.0f && isFacingRight))
        {
            Flip();
        }
        //Vector2 moving = new Vector2 (moveX * maxSpeed, moveY * maxSpeed); //updates both x and y (for non jumping
        GetComponent<Rigidbody2D>().velocity = moving;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneRestart();
        }


    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        /*Vector3 playerScale = this.transform.localScale;
		playerScale.x *= -1;
		this.transform.localScale = playerScale;*/
        //SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //renderer.flipX = !renderer.flipX;
        transform.Rotate(0f, 180f, 0f);
    }

    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            hp--;
            if (hp == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

}
