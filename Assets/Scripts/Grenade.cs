using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// INHERITANCE
public class Grenade : Ammunition
{
    [SerializeField] float throwForce = 100;
    [SerializeField] float throwImpulse = 3;
    [SerializeField] float detonationDelay = 3f;
    [SerializeField] float explosionRadius = 5f;    

    private int dormantDamage;
    protected override void Awake()
    {
        dormantDamage = damage;
        damage=0;        
        base.Awake();
    }
    
    public override void Fired()
    {
        rb.AddForce((transform.forward + (transform.up*throwImpulse)) * throwForce);        
        Invoke("ActivateDetonation", detonationDelay);        
    }

    private void ActivateDetonation()
    {           
        damage = dormantDamage;
        BOOM();
    }

    private void BOOM()
    {
        Collider[] objectsAround = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider obj in objectsAround)
        {
            Target nearTarget = obj.GetComponent<Target>();
            if (nearTarget != null)
            {
                nearTarget.HitBy(this);
            }            
        }
        Destroy(gameObject);
    }
}
