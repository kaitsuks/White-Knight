using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotHymyNaama2 : MonoBehaviour {
    public GameObject hymynaama;
    Slider sl;
    SpriteRenderer m_SpriteRenderer;
    Color color;

    // Use this for initialization
    void Start () {

        sl = GetComponent<Slider>();
        m_SpriteRenderer = hymynaama.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        byte b = (byte)(sl.value * 255);
        color = new Color32(b, 0, b, 255);
        m_SpriteRenderer.color = color;
        //Displays the value of the slider in the console.
        //Debug.Log(sl.value);

    }
}
