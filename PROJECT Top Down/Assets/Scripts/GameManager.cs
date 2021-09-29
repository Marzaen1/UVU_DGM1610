using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool hasKey;
    public bool isDoorLocked;


    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isDoorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Checking for Key and Door Lock to allow entry.
        // Short hand for below IF would be hasKey && !isDoorLocked
        if(hasKey == true && isDoorLocked == false)
        {
            print("You exit the room. Yay!");
        }
    }
}
