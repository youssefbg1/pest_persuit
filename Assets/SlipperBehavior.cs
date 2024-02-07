using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperBehavior : MonoBehaviour
{
    public Rigidbody ThrowableRb;
    public float speed;
    public Vector3 direction;
    public GameObject throwable;
    public bool ReadyToThrow;
    public Vector3 UpwardForce;
    public Vector3 throwdirection;
    public int throwforce=10;
    // Start is called before the first frame update
    void Start()
    {
        ReadyToThrow = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0)&& ReadyToThrow==true) {
            throwSlipper();
            Invoke("Restthrow", 2f);
        }
        
        
    }
    public void throwSlipper()
    {
        ReadyToThrow = false;
        GameObject projectile = Instantiate(throwable, transform.position,Quaternion.identity);
       /* ThrowableRb=projectile.GetComponent<Rigidbody>();
        direction=Camera.main.transform.forward;
        UpwardForce = Vector3.up;
        throwdirection = (direction + UpwardForce).normalized;
        ThrowableRb.AddForce(throwdirection * throwforce, ForceMode.Impulse);*/
        
    }
    public void Resetthrow()
    {
        ReadyToThrow = true;
    }
}
