using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Order Number Attribute")]
[RequireComponent(typeof(Collider2D))]
public class OrderNumberAttribute : MonoBehaviour
{
	public int orderNumber = 0;
    private NumberCollection numberCollection;
    public bool alive = true;

	// Start is called at the beginning
	private void Start()
	{
        // Find the Collection in the scene and store a reference for later use
        
            numberCollection = GameObject.FindObjectOfType<NumberCollection>();
        if (numberCollection != null)
        {
            Debug.Log("Collection hnr = " + numberCollection.highNumber);
        }
    }

	// This function gets called everytime this object collides with another
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		string playerTag = otherCollider.gameObject.tag;
        Debug.Log("Collision orderNumber = " + orderNumber);

        // is the other object a player?
        if (playerTag == "Player" || playerTag == "Player2")
		{            
            if (numberCollection != null)
            {
                // add one item if in this is collected in order
                if (orderNumber == numberCollection.highNumber)
                {
                    // then destroy this object
                    Debug.Log("Destroying orderNumber = " + orderNumber);
                    Destroy(gameObject);
                    numberCollection.AddNumber();
                }
            }            
		}
	}
}
