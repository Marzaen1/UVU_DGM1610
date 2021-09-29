using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    
    void Start()
    {

    }

    // Upon colliding with the door, the player either unlocks it or is stuck.
    void OnTriggerEnter2D(Collider2D other);
    {
        if(other.CompareTag("Player") == true && gameManager.hasKey == true)
        {
            print("You unlocked the Arcane Gate with the Arcane Key.");
            gameManager.isDoorLocked = false;
        }

        else
        {
            print("The Arcane Gate is locked. There must be a key around here somwhere...");
        }
    }
}
