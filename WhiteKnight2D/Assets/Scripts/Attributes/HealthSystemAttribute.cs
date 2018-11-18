using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Playground/Attributes/Health System")]
public class HealthSystemAttribute : MonoBehaviour
{
    public int health = 3;

    private UIScript ui;
    private int maxHealth;

    // Will be set to 0 or 1 depending on how the GameObject is tagged
    // it's -1 if the object is not a player
    private int playerNumber;

    private GameObject[] SceneRoots;



    private void Start()
    {
        SceneRoots = SceneManager.GetSceneByName("Skene1").GetRootGameObjects();
        // Find the UI in the scene and store a reference for later use
        ui = GameObject.FindObjectOfType<UIScript>();

        // Set the player number based on the GameObject tag
        switch (gameObject.tag)
        {
            case "Player":
                playerNumber = 0;
                break;
            case "Player2":
                playerNumber = 1;
                break;
            default:
                playerNumber = -1;
                break;
        }

        // Notify the UI so it will show the right initial amount
        if (ui != null
            && playerNumber != -1)
        {
            ui.SetHealth(health, playerNumber);
        }

        maxHealth = health; //note down the maximum health to avoid going over it when the player gets healed
    }


    // changes the energy from the player
    // also notifies the UI (if present)
    public void ModifyHealth(int amount)
    {
        //avoid going over the maximum health by forcin
        if (health + amount > maxHealth)
        {
            amount = maxHealth - health;
        }

        health += amount;

        // Notify the UI so it will change the number in the corner
        if (ui != null
            && playerNumber != -1)
        {
            ui.ChangeHealth(amount, playerNumber);
        }

        //DEAD
        if (health <= 0 && playerNumber == 0) //pelaaja häviää
        {
            Debug.Log("NO NYT ON RITARI VOITETTU!!! : " + playerNumber);
            //SceneManager.UnloadScene("MiekkaTaistelu");
            //foreach (var root in SceneRoots)
            //{
            //    Debug.Log(root);
            //    root.SetActive(true);
            //}
            SceneManager.UnloadSceneAsync("MiekkaTaistelu");
            SceneManager.LoadScene("Lopetus");
            Destroy(gameObject);
        }

        if (health <= 0 && playerNumber == 1) //vastustaja häviää
        {
            EnemyKilled();
        }
    }

    public void EnemyKilled()
    {
        Debug.Log("Onnittelut, vastustaja voitettu!!! : " + playerNumber);
        //SceneManager.UnloadScene("MiekkaTaistelu");
        foreach (var root in SceneRoots)
        {
            Debug.Log(root);
            if (root != null)
            {
                root.SetActive(true);
                //if (root.tag == "Player2") { Destroy(root); }
            }
        }
        SceneManager.UnloadSceneAsync("MiekkaTaistelu");
        //SceneManager.LoadScene("Skene1");
        Destroy(gameObject);
    }
}
