using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movingSpeed;
    public float moveTime, waitTime;
    private float moveCount, waitCount;

    public Transform leftPoint, rightPoint, frog;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim;
    
    
    private bool movingRight;
    //private bool isJump;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    
    
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        moveCount = moveTime;
        movingRight = true;


        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(frog.position.y > -2.35f)
        {
            isJump = true;
            //Debug.Log("jump");
        }
        else
        {
            isJump = false;
            //Debug.Log("not");
        }*/

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

      
        
        
        if (moveCount > 0)
        {

            moveCount -= Time.deltaTime;
            
            if (movingRight && !isGrounded)
            {
                theRB.velocity = new Vector2(movingSpeed, theRB.velocity.y);

                theSR.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else if(!movingRight && !isGrounded)
            {
                theRB.velocity = new Vector2(-movingSpeed, theRB.velocity.y);

                theSR.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            else
            {
                theRB.velocity = new Vector2(0f, theRB.velocity.y);
            }
            
            if(moveCount <= 0)
            {
                waitCount = waitTime;
            }

            anim.SetBool("isMoving", true);
        }
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0)
            {
                moveCount = moveTime;
            }

            anim.SetBool("isMoving", false);
        }

        
    }

    

    
}
