using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
[SelectionBase]
public class MovingTarget : Target
{
    protected Vector3 startingPoint;
    [SerializeField] Vector3 endingPoint;
    [SerializeField] float speed;

    private Ray path;
    private float startMovingTime = 0;

    //Awake is called when the script instance is being loaded.
    private void Awake()
    {
        startingPoint = transform.position;
        // ABSTRACTION
        RestartMovement();
    }


    // Start is called before the first frame update
    void Start()
    {        

    }

    
    // Update is called once per frame
    void Update()
    {
        float elapsedDistance = (Time.time - startMovingTime) * speed;
        if ((endingPoint-startingPoint).magnitude >= elapsedDistance)
        {
            transform.position = path.GetPoint(elapsedDistance);
        }else
        {
            // ABSTRACTION
            ReverseMovement();
            RestartMovement();
        }
    }

    // ABSTRACTION
    private void ReverseMovement()
    {
        Vector3 tempPoint = endingPoint;
        endingPoint = startingPoint;
        startingPoint = tempPoint;
    }

    private void RestartMovement()
    {
        path = new Ray(startingPoint, endingPoint - startingPoint);
        startMovingTime = Time.time;
    }
    
}
