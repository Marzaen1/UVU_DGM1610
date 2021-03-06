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
    private Weapon weapon;                 // Accessing our gun / weapon
    
    // Awake is called as soon as the script becomes active
    void Awake()
    {
        // Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;

        weapon = GetComponent<Weapon>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        // Firing the weapon button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
        // Jumping by pressing a key/button
        if(Input.GetButtonDown("Jump"))
            Jump();
    }
    
    // Graphing Movement
    void Move()
    {
        // Keybinds for movement
        float x = Input.GetAxis("Horizontal") * moveSpeed; 
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Movement goes Brrrrrrr
                // rig.velocity = new Vector3(x, rig.velocity.y, z);            // Old Code: Movement went in the wrong direction, didn't follow the camera direction
        Vector3 dir = transform.right * x + transform.forward * z;
        // Add direction with force to Jump
        dir.y = rig.velocity.y;
        // Add force to movement
        rig.velocity = dir;
    }

    // Controlling the First Person Camera
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSens;
        rotX += Input.GetAxis("Mouse Y") * lookSens;                // Same as rotX = rotX + Input.GetAxis("Mouse Y") * lookSens

        // Looking around using the mouse movements
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
    
    // Jumping goes boing, boing!
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
