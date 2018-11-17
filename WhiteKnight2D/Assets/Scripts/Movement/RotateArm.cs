using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Playground/Movement/RotateArm")]
[RequireComponent(typeof(Rigidbody2D))]
public class RotateArm : Physics2DObject
{
    [Header("Input keys")]
    //public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;
    public KeyCode keyUp;
    public KeyCode keyDown;

    private float force;

    [Header("Rotation")]
    public float speed = 40f; //right arm 50 left 30
   // public float speed = 15f;
    public float hit = 6f; //right arm 7 left 4
    public float downForce = 2; //right arm 5 left 1
    public bool down = true;


    private float spin;


    // Update gets called every frame
    void Update()
    {
        // Register the spin from the player input
        // Moving with the arrow keys
        //if(typeOfControl == Enums.KeyGroups.ArrowKeys)
        //{
        //	spin = Input.GetAxis("Horizontal");
        //}
        //else
        //{
        //	spin = Input.GetAxis("Horizontal2");
        //}



    }
    private void LateUpdate()
    {

        if (Input.GetKeyDown(keyUp))
        {
            //spin -= 1f;
            StartCoroutine(WaitForRightHandUp(-1));
        }

        if (Input.GetKeyDown(keyDown))
        {
            //spin += 1f;
            StartCoroutine(WaitForRightHandUp(1));
        }

       

    }

    private IEnumerator WaitForRightHandUp(int suunta)
    {
        bool handup = false;
        spin = 0;
        while (!handup)
        {
            spin += 0.2f * suunta;
            if (spin > 0.3 || spin < -0.3) handup = true;
            //yield return new WaitUntil(() => !balloonIsActive);
        }
        yield return new WaitForSeconds(0.1f);
    }

    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        if (down)
        {
            force = -spin * speed * downForce;
        }
        else
        { force = -spin * speed; }
        // Apply the torque to the Rigidbody2D
        rigidbody2D.AddTorque(-spin * speed);
    }
}


