using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://noobtuts.com/unity/2d-pong-game

public class MoveRacket : MonoBehaviour
{
    public float speed = 3;
    public string axis = "Vertical";

    //FixedUpdate() function is called over and over in a fixed time interval 
    void FixedUpdate()
    {
        //Assigning Vertical input to the rackets (W,S, Up,Dwn)
        float v = Input.GetAxisRaw(axis);
        //Making rackets move
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;

    }
}
