using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ToastBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Vector3 direction;

    public void Start()
    {
        direction = Camera.main.transform.forward;
        rb = GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }
    public void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy hit");
        }
    }
}
