using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject spriteObjekti; // vaihda oman objektisi nimi! 
    public GameObject oSword; // vaihda oman objektisi nimi! 
    public GameObject oCrossbow; // vaihda oman objektisi nimi! 
    public GameObject oJavelin; // vaihda oman objektisi nimi! 
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
        sword = Resources.Load<UnityEngine.Sprite>("Weapons/Sword");
        lasergun = Resources.Load<UnityEngine.Sprite>("Weapons/Crossbow");
        javelin = Resources.Load<UnityEngine.Sprite>("Weapons/Javelin");

        //oSword = GameObject.Find("Sword");
        //oCrossbow = GameObject.Find("Crossbow");
        //oJavelin = GameObject.Find("Javelin");
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
        oSword.SetActive(false);
        oCrossbow.SetActive(false);
        oJavelin.SetActive(false);

        if (selected == 0) { m_SpriteRenderer.sprite = sword; oSword.SetActive(true); }
        if (selected == 1) { m_SpriteRenderer.sprite = lasergun; oCrossbow.SetActive(true); }
        if (selected == 2) { m_SpriteRenderer.sprite = javelin; oJavelin.SetActive(true); }
        }
    }

