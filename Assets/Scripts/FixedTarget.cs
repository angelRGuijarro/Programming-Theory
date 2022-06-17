using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FixedTarget : Target
{
    /// <summary>
    /// Destroy Target if ammunition damage is equals or higher than target points value
    /// </summary>
    /// <param name="byAmmunition"></param>
    public override void isHitedBy(Ammunition byAmmunition)
    {        
        if (byAmmunition.dammage >= pointsValue)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {        
        Ammunition ammunition = collision.gameObject.GetComponent<Ammunition>();
        if (ammunition != null)
        {            
            this.isHitedBy(ammunition);
        }
        
    }
}
