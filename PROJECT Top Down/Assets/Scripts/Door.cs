using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameManager gameManager;

    // Called upon a trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && gameManager.hasKey == true)
        {
            print("You unlock the Arcane Gate with the Arcane Key!");
            gameManager.isDoorLocked = false;
        }
        else
        {
            print("The Arcane Gate is locked. There must be a key around here somewhere...");
        }
    }
}
