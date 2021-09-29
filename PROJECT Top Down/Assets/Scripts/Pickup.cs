using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public string pickupName;
    public int amount;

    // Calling and accessing the GameManager script.
    public GameManager gameManager;

    // Called upon a trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        print("You picked up an " + pickupName);
        gameManager.hasKey = true;
        Destroy(gameObject);
    }
  
}
