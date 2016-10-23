using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class CharacterMovement : MonoBehaviour
{

    //AudioSource jSound;
    //AudioSource cSound;
   

    public AudioSource jSound;
    public AudioSource cSound;
    public AudioSource hSound;
    

    public GameObject map;

    float damage;
    float hitSpeed;


    float currentTime = 0;
    float previousTime = 0;
    float deltaTime = 0;
    public float speed;
    Vector3 dir;
    float Jump;
    float jumpforce = 25000;
    bool grounded = true;
    public int Coins = 0;

    float h;
    float v;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Coin(Clone)")
        {
                Destroy(other.gameObject);
                Coins++;
                cSound.Play();
            
        }

       if (transform.position == other.transform.position)
            hSound.Play();
        
    }

    void Update()
    {


        currentTime = Time.time;
        deltaTime = currentTime - previousTime;
        previousTime = currentTime;

        h = Input.GetAxis("MoveX");
        v = Input.GetAxis("MoveZ");

        dir += (new Vector3(h, 0, v) / 25);
        Vector3 pos = transform.position;

        //int biggestnum = (a > b) ? a : b;
        Vector3 vel = (pos - transform.position) * Time.deltaTime;



        transform.position += Vector3.ClampMagnitude(((dir + vel) * speed * Time.deltaTime), 0.4f);


        if (transform.position.y - 1.5f >= map.transform.position.y)
            grounded = false;

        else
            grounded = true;

        if (!grounded)
            Jump /= (jumpforce * deltaTime) * 10;

        else
            if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump += jumpforce * deltaTime;
            jSound.Play();
        }

        Vector3 name = new Vector3(0, Jump, 0);
        transform.position += new Vector3(0, name.y * deltaTime, 0);


    }

}
