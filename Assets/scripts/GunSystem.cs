
using UnityEngine;
using TMPro;
using System;

public class GunSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] Projectiles;
    public int ammo;
    public GameObject cameraObject;
    public GameObject firepoint;
    public   bool reloading;
    public int maxammo; 
    

    public void Start()
    {
        ammo = maxammo;
        reloading = false;

    }
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            shoot(Projectiles[0]);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            reload(ammo, reloading);
        }
        
    }
    public void shoot(GameObject projectile)
    {
        if (ammo > 0)
        {
            var dir = cameraObject.transform.forward;
            Instantiate(projectile, firepoint.transform.position, Quaternion.identity);
            ammo--;
        }

    }
    public void reload( int ammo, bool reloading)
    {
        if (!reloading && ammo<maxammo ) {
            reloading=true;
            Debug.Log("reloading");
            Invoke("donereloading", 1);
        }

    }
    public void donereloading()
    {
        ammo = maxammo;
        reloading = false;
        Debug.Log("done reloading");
    }
}
