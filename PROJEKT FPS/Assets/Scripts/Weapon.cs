using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Projectile Management
    public GameObject bulletPrefab;
    public Transform muzzle;

    // Ammo Management
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    // Gun Behaviors
    public float bulletSpeed;
    public float shootRate;
    private float lastShootTime;
    
    private bool isPlayer;

    // Awake is called...
    void Awake()
    {
        if(GetComponent<PlayerController>())
            isPlayer = true;

    }
   
    // When can we fire the gun
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        { 
            if(curAmmo > 0 || infiniteAmmo == true)
            return true;
        }

        return false;
    }

    public void Shoot()
    {
        // Cooldown
        lastShootTime = Time.time;
        curAmmo--;

        // Creating an instance of the bullet prefab at the muzzle's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        
        // Add Velocity to bullets
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
