using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On Trigger is called upon a certain trigger
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
}