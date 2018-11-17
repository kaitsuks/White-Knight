using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShutDownSkene1 : MonoBehaviour {

    //This is Main Camera in the Scene    
    //public Camera m_MainCamera;
    //public GameObject myCamera;
    private Camera myCamera;
    private Camera secondCamera;
    private Camera miekkaCamera;

    //public static IEnumerable<GameObject> SceneRoots();
    private GameObject[] SceneRoots;

    //bool m_SceneLoaded = false;

    // Use this for initialization
    void Start()
    {
        // This gets the Main Camera from the Scene
        //myCamera = Camera.main;
        //myCamera = m_MainCamera.GetComponent<Camera>();
        //myCamera = GameObject.FindWithTag("CameraSkene1");
        //m_MainCamera = myCamera.GetComponent<Camera>();
        // myCamera = GameObject.FindWithTag("CameraSkene1").GetComponent<Camera>();
        // Debug.Log("Kamera löydetty " + myCamera.name.ToString());

        //  secondCamera = GameObject.FindWithTag("CameraVara").GetComponent<Camera>();
        //  Debug.Log("Kamera 2 löydetty " + secondCamera.name.ToString());
        SceneRoots = SceneManager.GetActiveScene().GetRootGameObjects();

        miekkaCamera = GameObject.FindWithTag("CameraMiekkailu").GetComponent<Camera>();
        Debug.Log("Miekkailukamera löydetty " + miekkaCamera.name.ToString());

        //This disables Main Camera
        //Debug.Log("DISABLOIDAAN KAMERA!");
       // secondCamera.enabled = true;
      //  myCamera.enabled = false;
       // myCamera.targetDisplay = 4;
        //myCamera.enabled = false;
        miekkaCamera.enabled = true;

        foreach (var root in SceneRoots)
        {
            Debug.Log(root);
            root.SetActive(false);
        }

        //SceneRoots().Select(g => g.transform).ToList();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
