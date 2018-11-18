using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Modify Health Original")]
[RequireComponent(typeof(PolygonCollider2D), typeof(Rigidbody2D))]
public class ModifyHealthOriginal : MonoBehaviour
{

	public int healthChange = -1;
   // public string otherPlayerTag;


	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		HealthSystemOriginal healthScript = collisionData.gameObject.GetComponent<HealthSystemOriginal>();
        string tag = collisionData.gameObject.tag; 

        if (healthScript != null && gameObject.tag != tag)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);
		}
	}

	private void OnTriggerEnter2D(Collider2D colliderData)
	{
		HealthSystemOriginal healthScript = colliderData.gameObject.GetComponent<HealthSystemOriginal>();
        string tag = colliderData.gameObject.tag;
        if (healthScript != null && gameObject.tag != tag)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);
		}
	}
}
