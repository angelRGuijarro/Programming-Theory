using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FixedTarget : Target
{
    public override void isHitedBy(Ammunition byAmmunition)
    {
        Debug.Log("Hited!");
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
        Debug.Log("Collision detected");
        Ammunition ammunition = collision.gameObject.GetComponent<Ammunition>();
        if (ammunition != null)
        {
            Debug.Log("Hited by " + ammunition.name);
            this.isHitedBy(ammunition);
        }
        
    }
}
