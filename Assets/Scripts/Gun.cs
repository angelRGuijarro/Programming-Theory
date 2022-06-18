using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] protected Ammunition primaryAmmo;
    [SerializeField] protected Ammunition secondaryAmmo;
    [Tooltip("Rounds per second")]
    [SerializeField] float primaryFireRate = 15f;
    [Tooltip("Rounds per second")]
    [SerializeField] float secondaryFireRate = 0.25f;

    private float nextRound = 0;
    public Ray aimSight { get; private set; }

    enum AmmunitionSlot { Primary, Secondary };

    // Start is called before the first frame update
    void Start()
    {
        aimSight = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            Shoot(typeof(Bullet));
        }
        if (Input.GetAxis("Fire2") > 0)
        {
            Shoot(AmmunitionSlot.Secondary);
        }
    }

    // POLYMORPHISM --Not necesary for my project, but to show polymorphism
    private float primaryNexRound = 0;
    private float secondaryNexRound = 0;
    // POLYMORPHISM
    private void Shoot(AmmunitionSlot slot)
    {
        float nextRound = (slot == AmmunitionSlot.Primary) ? primaryNexRound : secondaryNexRound;
        if (Time.time > nextRound)
        {
            Ammunition firedAmmo = Instantiate((slot == AmmunitionSlot.Primary) ? primaryAmmo : secondaryAmmo, 
                                               transform.position + (transform.forward * transform.localScale.z/2), 
                                               transform.rotation);
            firedAmmo.Fired();
            switch (slot)
            {
                case AmmunitionSlot.Primary:
                    primaryNexRound = Time.time + (1 / primaryFireRate);
                    break;
                case AmmunitionSlot.Secondary:
                    secondaryNexRound = Time.time + (1 / secondaryFireRate);
                    break;
            }
        }
    }
    // POLYMORPHISM
    private void Shoot(System.Type ammoType)
    {
        if (ammoType == primaryAmmo.GetType())
        {
            Shoot(AmmunitionSlot.Primary);
        }else if (ammoType == secondaryAmmo.GetType())
        {
            Shoot(AmmunitionSlot.Secondary);
        }
    }
}