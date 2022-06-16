using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Bullet : Ammunition
{
    [SerializeField] float shootForce = 10;

    
    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {         
        rb.AddForce(transform.forward * shootForce);
        Destroy(gameObject, 3);
    }
}
