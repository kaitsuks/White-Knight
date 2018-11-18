using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillEnemy : MonoBehaviour {

    public GameObject enemy;
    public int testi = 3;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Kill()
    {
       Destroy(enemy);
    }
}
