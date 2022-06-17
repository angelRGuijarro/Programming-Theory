using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _testing : MonoBehaviour
{
    public Ammunition testingShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet m_shot = Instantiate(testingShot) as Bullet; //if it's not a Bullet returns null            
            m_shot.Shoot();
        }
    }
}
