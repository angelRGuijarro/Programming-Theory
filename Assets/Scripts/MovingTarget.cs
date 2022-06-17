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

    private void RestartMovement()
    {
        path = new Ray(startingPoint, endingPoint - startingPoint);
        startMovingTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {        

    }

    
    // Update is called once per frame
    void Update()
    {
        float distance = elapsedDistance(Time.time - startMovingTime);
        if ((endingPoint-startingPoint).magnitude >= distance)
        {
            transform.position = path.GetPoint(distance);
        }else
        {
            Vector3 tempPoint = endingPoint;
            endingPoint = startingPoint;
            startingPoint = tempPoint;
            RestartMovement();
        }
    }

    private float elapsedDistance(float elapsedTime)
    {
        return elapsedTime * speed;
    }
}
