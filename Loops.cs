using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int counter;
        int answer = 0;

        for (counter = 1; counter <= 20; counter++)
        {

            if (counter % 3 == 0)
            {
                answer = counter + answer;
            }
            Console.WriteLine(answer);
        }
    }
}
