using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public abstract class Target : MonoBehaviour
{
    [SerializeField] protected int pointsValue=1;

    
    public abstract void isHitedBy(Ammunition ammunition);

    private void Start()
    {        
        
    }
}
