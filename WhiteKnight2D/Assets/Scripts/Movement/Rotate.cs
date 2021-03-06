using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Rotate")]
[RequireComponent(typeof(Rigidbody2D))]
public class Rotate : Physics2DObject // MonoBehaviour //
{
	[Header("Input keys")]
	//public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

	[Header("Rotation")]
	public float speed = 3f;
    public KeyCode spinLeft = KeyCode.O;
    public KeyCode spinRight = KeyCode.P;

    public float spinFactor = 1;

    private float spin = 0f;
	
	
	// Update gets called every frame
	void Update ()
	{
        //Register the spin from the player input
        //Moving with the arrow keys
        //if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        //{
        //    spin = Input.GetAxis("Horizontal");
        //}
        //else
        //{
        //    spin = Input.GetAxis("Horizontal2");
        //}
    }

    private void LateUpdate()
    {

        if (Input.GetKeyDown(spinLeft))
        {
            spin -= 1f;
        }

        if (Input.GetKeyDown(spinRight))
        {
            spin += 1f;
        }

    }


        // FixedUpdate is called every frame when the physics are calculated
        void FixedUpdate ()
	{
		// Apply the torque to the Rigidbody2D
		rigidbody2D.AddTorque(-spin * speed);
	}
}
