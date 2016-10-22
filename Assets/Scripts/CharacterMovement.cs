using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    Vector3 Jump = new Vector3(0, 100, 0);
    
	
    void Update ()
    {
        if(Input.GetKey(KeyCode.W))
            gameObject.transform.position += new Vector3(0, 0, 5) * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.position += new Vector3(-5, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            gameObject.transform.position += new Vector3(0, 0, -5) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.position += new Vector3(5, 0, 0) * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
            gameObject.transform.position += (Jump * Time.deltaTime); 
    }
}
