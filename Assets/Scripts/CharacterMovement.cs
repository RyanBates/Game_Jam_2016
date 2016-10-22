using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    float currentTime = 0;
    float previousTime = 0;
    float deltaTime = 0;

    Vector3 Jump = new Vector3(0, 80, 0);

    void Update()
    {

        currentTime = Time.time;
        deltaTime = currentTime - previousTime;
        previousTime = currentTime;
        

        if (Input.GetKey(KeyCode.W))
            gameObject.transform.position += new Vector3(0, 0, 5) * deltaTime;
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.position += new Vector3(-5, 0, 0) * deltaTime;
        if (Input.GetKey(KeyCode.S))
            gameObject.transform.position += new Vector3(0, 0, -5) * deltaTime;
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.position += new Vector3(5, 0, 0) * deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
                gameObject.transform.position += Jump * deltaTime; 
        }
    }
}
