using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;

    public float hInput;
    public float vInput;
    // Limiting the Play Area to prevent character from leaving Camera Range.
    public float xRange = 9.3f;
    public float yRange = 4.5f;

    // public float for Health
  

    // Update is called once per frame
    void Update()
    {
    // Player Movement Controls.
      hInput = Input.GetAxis("Horizontal");  
      vInput = Input.GetAxis("Vertical");

      transform.Translate(Vector3.right * speed * hInput * Time.deltaTime);
      transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);

    // Creating Barrier Wall on the Left Side.
      if (transform.position.x < -xRange)
      {
          transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
      }
    // Creating Barrier Wall on the Right Side.
       if (transform.position.x > xRange)
      {
          transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
      }
    // Creating Barrier Wall on the Bottom Side.
      if (transform.position.y < -yRange)
      {
          transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
      }
    // Creating Barrier Wall on the Top Side.
      if (transform.position.y > yRange)
      {
          transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
      }
    }
}
