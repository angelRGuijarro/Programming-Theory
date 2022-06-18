using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// INHERITANCE
public class Bullet : Ammunition
{
    [SerializeField] float shotForce = 10;
    [Tooltip("Let bullets to stand for a while before disposing")]
    [SerializeField] float objectLifeTime = 3f;
    

    public override void Fired()
    {
        rb.AddForce(transform.forward * shotForce);
        Destroy(gameObject, objectLifeTime);
    }    
}
