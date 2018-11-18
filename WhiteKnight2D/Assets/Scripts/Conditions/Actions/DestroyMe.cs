using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Playground/Actions/Destroy Me")]
public class DestroyMe : MonoBehaviour
{

    //private Vector3 spherePosition;
    //private float xzPosition, yPosition;

    public void DestroyThis()
    {
  
        Debug.Log("TUHOTAAN TÄMÄ OBJEKTI!");
        //spherePosition = new Vector3(2.0f * Mathf.Sin(xzPosition), 4.0f * Mathf.Sin(yPosition), 2.0f * Mathf.Cos(xzPosition));
        //transform.position = spherePosition;
        Invoke("Finally", 0.5f);

    }

    void Finally()
    {
        Destroy(this);
        Debug.Log("TUHOTAAN VIHDOINKIN");
    }

}
