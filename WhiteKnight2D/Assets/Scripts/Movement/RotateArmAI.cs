using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Playground/Movement/RotateArm AI")]
[RequireComponent(typeof(Rigidbody2D))]
public class RotateArmAI : Physics2DObject
{
    [Header("Input keys")]
    //public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;
    public KeyCode keyUp;
    public KeyCode keyDown;
    public float hit = 6f; //right arm 7 left 4
    public float downForce = 2; //right arm 5 left 1
    public bool down = true;

    private float force;

    [Header("Rotation")]
    public float speed = 40f; //right arm 50 left 30


    private float spin;

    void Start()
    {
        hit = hit / 10;
    }


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
        down = false;
        if (Random.value < 0.4f)
        {
            //spin += 1f;
            //downForce = 10f;
        }

        if (Random.value > 0.6f)
        {
            //spin -= 1f;
            StartCoroutine(WaitForRightHandUp(-1));
            down = true;
        }

        if (Random.value < 0.4f)
        {
            //spin += 1f;
            StartCoroutine(WaitForRightHandUp(1));
            
        }

       

    }

    private IEnumerator WaitForRightHandUp(int suunta)
    {
        spin = 0;
        bool handup = false;
        while (!handup)
        {
            spin += 0.2f * suunta;
            if (spin > 0.3 || spin < -0.3) handup = true;
            //yield return new WaitUntil(() => !balloonIsActive);
            Mathf.Clamp(spin, hit, hit);
        }
        yield return new WaitForSeconds(0.1f);
    }

    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        // Apply the torque to the Rigidbody2D
        if (down) {
            force = -spin * speed * downForce;
                }
        else
        { force = -spin * speed; }
        //rigidbody2D.AddTorque(-spin * speed * downForce);
        rigidbody2D.AddTorque(force);
    }
}


