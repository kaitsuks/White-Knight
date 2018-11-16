using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Playground/Movement/Move Fight")]
[RequireComponent(typeof(Rigidbody2D))]
public class MoveFight : Physics2DObject
{
    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 5f;
    public Enums.MovementType movementType = Enums.MovementType.AllDirections;

    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that will face the player
    public Enums.Directions lookAxis = Enums.Directions.Up;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;

    Animator animator;
    private void Start() { animator = GetComponentInChildren<Animator>(); }


    // Update gets called every frame
    void Update()
    {
        

        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        //else
        //{
        //    moveHorizontal = Input.GetAxis("Horizontal2");
        //    moveVertical = Input.GetAxis("Vertical2");
        //}

        //zero-out the axes that are not needed, if the movement is constrained
        switch (movementType)
        {
            case Enums.MovementType.OnlyHorizontal:
                moveVertical = 0f;
                break;
            case Enums.MovementType.OnlyVertical:
                moveHorizontal = 0f;
                break;
        }

        movement = new Vector2(moveHorizontal, moveVertical);


        //rotate the gameObject towards the direction of movement
        //the axis to look can be decided with the "axis" variable
        if (orientToDirection)
        {
            if (movement.sqrMagnitude >= 0.01f)
            {
                cachedDirection = movement;
            }
            Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
        }
    }



    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        
        // Apply the force to the Rigidbody2d
        rigidbody2D.AddForce(movement * speed * 10f);
    }

    private void LateUpdate()
    {
        //{ animator.SetTrigger("Jump"); }
        if (Input.GetKeyDown("space")) //välilyönti - tai muu näppäin 
        { animator.SetTrigger("Jump"); }
        if (Input.GetKeyDown("left")) //välilyönti - tai muu näppäin 
        { animator.SetTrigger("Step"); }
        if (Input.GetKeyDown("right")) //välilyönti - tai muu näppäin 
        { animator.SetTrigger("Step"); }
        //else
        //{ animator.SetTrigger("Jump"); }

    }
}