using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Ammunition loadedAmmo;
    [Tooltip("Rounds per second")]
    [SerializeField] float fireRate = 15f;

    private float nextRound=0;
    public Ray aimSight { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        aimSight = new Ray(transform.position,transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1")>0)
        {
            if (Time.time > nextRound)
            {
                /*
                Ammunition firedAmmo = Instantiate(loadedAmmo,
                                                    new Vector3(transform.position.x + transform.localScale.x / 2,
                                                                transform.position.y + transform.localScale.y / 2,
                                                                transform.position.z + transform.localScale.z / 2),
                                                    transform.rotation);
                */
                Ammunition firedAmmo = Instantiate(loadedAmmo, transform.position + transform.forward, transform.rotation);
                if (firedAmmo.GetType() == typeof(Bullet))
                {
                    Bullet bullet = (Bullet)firedAmmo;
                    bullet.Shoot();
                }
                nextRound = Time.time + (1/fireRate);  
            }
        }
    }
}
