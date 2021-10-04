using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Movement Variables
    public float moveSpeed;             // Movement Speed in units per second
    public float jumpForce;             // Force applied upwards
    public float lookSens;              // Mouse & Camera sensitivity
    
    // Limits the Camera angles on X axis, to prevent broken neck
    public float maxLookX;              // Looking down limit   
    public float minLookX;              // Looking up limit
    // Limits the Camera angles on Y axis, to prevent owl behavior
    private float rotX;                 // Current X rotation of the camera
    
    // Other Variables
    private Camera camera;              // Fetching our handsome camera man
    private Rigidbody rig;              // Working with the rigidbody
    
    // Start is called before the first frame update
    void Start()
    {
        camera = camera.main;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    // Graphing Movement
    void Move()
    {
        // Keybinds for direction
        float x = Input.GetAxis("Horizontal") * moveSpeed; 
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Movement goes Brrrrrrr
        rig.velocity = new Vector3(x, rig.velocity.y, z);
    }

    // Controlling the First Person Camera
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSens;
        rotX += Input.GetAxis("Mouse Y") * lookSens;                // Same as rotX = rotX + Input.GetAxis("Mouse Y") * lookSens
    }
}
