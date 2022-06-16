using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Ammunition : MonoBehaviour
{
    public float dammage = 1;
    protected Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }
}