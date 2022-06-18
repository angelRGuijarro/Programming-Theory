using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [RequireComponent(typeof(Rigidbody))]
    public abstract class Ammunition : MonoBehaviour
    {
        public int damage = 1;
        protected Rigidbody rb;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public abstract void Fired();
    }