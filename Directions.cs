using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //A vector consists of a starting point, an endpoint, magnitude and direction.  The starting point is wherever the vecot is, the direction is where the vector is 
        //pointing to get to the endpoint and the magnitude is the length of the path itself.
        Vector3 myVector = new Vector3(10, 20, 10);

        Vector3.forward; // returns coordinates (0, 0, 1)
        Vector3.back; //returns coordinates (0, 0, -1)

        //The method of finding the location based on time is called Lerping
        Vector3 result = Vector3.Lerp(Start, end, .5f); // typically called every frame in update
        float timePassed += Time.deltaTime;
        float currentTime = timePassed / 1.0f;
        bullet.position = Vector3.Lerp(startPosition, endPosition, currentTime);
        //Lerping moves in a straight line.  Slerping takes magnitude into account and moves in a curve
    }
}
