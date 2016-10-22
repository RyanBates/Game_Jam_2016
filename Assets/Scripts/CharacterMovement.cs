using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController character;
    float currentTime = 0;
    float previousTime = 0;
    float deltaTime = 0;

    float Jump;
    float jumpforce = 10;
    float gravity = 14;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

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
        if (character.isGrounded)
        {
            Jump = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
                Jump = jumpforce;

            else
                Jump -= gravity * Time.deltaTime;
        }
        Vector3 name = new Vector3(0, Jump, 0);
        character.Move(name * Time.deltaTime);
    }
}
