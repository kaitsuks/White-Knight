using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject spriteObjekti; // vaihda oman objektisi nimi! 
    Dropdown dd;
    SpriteRenderer m_SpriteRenderer;
    Sprite sword;
    Sprite javelin;
    Sprite lasergun;
    Color color;
    int selected;
    // Use this for initialization    
    void Start()
    {
        dd = GetComponent<Dropdown>();
        m_SpriteRenderer = spriteObjekti.GetComponent<SpriteRenderer>(); // vaihda oman objektisi nimi!
        sword = Resources.Load<UnityEngine.Sprite>("Characters/human");
        javelin = Resources.Load<UnityEngine.Sprite>("Characters/human2");
        lasergun = Resources.Load<UnityEngine.Sprite>("Characters/human3");
    }
    // Update is called once per frame
    void Update()
    {
        //byte b = (byte)(sl.value * 255);
        //color = new Color32(128, 128, b, 255);
        //m_SpriteRenderer.color = color;
        



    }
    public void Vaihda()
    {
        selected = dd.value;
        Debug.Log("Valittu " + selected);

        if (selected == 0) m_SpriteRenderer.sprite = sword;
        if (selected == 1) m_SpriteRenderer.sprite = javelin;
        if (selected == 2) m_SpriteRenderer.sprite = lasergun;
    }
}
