using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public GameObject map;
    float currentTime = 0;
    float previousTime = 0;
    float deltaTime = 0;

    float Jump;
    float jumpforce = 15;
    //float gravity = 14;
    public bool grounded = true;

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

        if (transform.position.y - .5f >= map.transform.position.y)
            grounded = false;

        else
            grounded = true;

        if (!grounded)
            Jump -= jumpforce;
      
        
        else
            if (Input.GetKeyDown(KeyCode.Space))
                Jump += jumpforce * deltaTime;

        Vector3 name = new Vector3(0, Jump, 0);
        transform.position += new Vector3(0, name.y * deltaTime, 0);
    }
}
