using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //Speed of the enemy
    public float speed = 1.5F;
    //1.5 = Easy, 2 = Medium, 2.5 = Hard, 3 = Impossible

    //the ball
    Transform ball;

    //the ball's rigidbody 2D
    Rigidbody2D ballRig2D;

    //bounds of enemy
    public float topBound = 1.75F;
    public float bottomBound = -2.33F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //finding the ball
        ball = GameObject.FindGameObjectWithTag("Ball").transform;

        //setting the ball's rigidbody to a variable
        ballRig2D = ball.GetComponent<Rigidbody2D>();

        //checking x direction of the ball
        if (ballRig2D.velocity.x > 0)
        {

            //checking y direction of ball
            if (ball.position.y < this.transform.position.y)
            {
                //move ball down if lower than paddle
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (ball.position.y > this.transform.position.y)
            {
                //move ball up if higher than paddle
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

        }

        //set bounds of enemy
        if (transform.position.y > topBound)
        {
            
            transform.position = new Vector3(transform.position.x, topBound, 0);
        }
        else if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, bottomBound, 0);
        }
    }
}