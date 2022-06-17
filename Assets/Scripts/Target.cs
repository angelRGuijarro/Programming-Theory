using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public abstract class Target : MonoBehaviour
{
    [SerializeField] protected int pointsValue=1;
    [SerializeField] protected int health;
    
    //public abstract void IsHitedBy(Ammunition ammunition);

    private void Start()
    {        
        
    }

    // ENCAPSULATION
    // It assures health is never negative
    protected void DecreaseHealth(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
    }
    // ENCAPSULATION
    /// <summary>
    /// Check is hited by an Ammunition object and check health to be destroied
    /// </summary>
    /// <param name="ammunition"></param>
    protected void IsHitedBy(Ammunition ammunition)
    {
        DecreaseHealth(ammunition.dammage);
        if (health>=0)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {        
        Ammunition ammunition = collision.gameObject.GetComponent<Ammunition>();
        if (ammunition != null)
        {            
            this.IsHitedBy(ammunition);
        }
        
    }
}
