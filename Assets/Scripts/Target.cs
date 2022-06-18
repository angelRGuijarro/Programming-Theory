using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public abstract class Target : MonoBehaviour
{
    [SerializeField] protected int pointsValue=1;
    [SerializeField] protected int health;

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
    public void HitBy(Ammunition ammunition)
    {
        DecreaseHealth(ammunition.damage);
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {        
        Ammunition ammunition = collision.gameObject.GetComponent<Ammunition>();
        if (ammunition != null)
        {            
            this.HitBy(ammunition);
        }
        
    }
}
