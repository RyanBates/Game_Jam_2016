using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class CharacterMovement : MonoBehaviour
{
    public AudioSource cSound;
    public AudioSource hSound;
    public AudioSource flySound;
    public GameObject Coin;

    public GameObject map;

    bool isFly = false;
    
    float currentTime = 0;
    float previousTime = 0;
    float deltaTime = 0;
    public float speed;
    float Jump;
    float jumpforce = 25000;
    bool grounded = true;
    public int Coins = 5;
    Vector3 dir = Vector3.zero;
    Vector3 fly;

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

        if (other.gameObject.name == "Fist")
        {
            
            hSound.Play();
            if (Coins > 0)
            {
                Instantiate(Coin, other.transform.position + new Vector3(5, 5, 5), other.transform.localRotation);
            }
            Coins--;
            if (Coins <= 0)
            {
                fly = new Vector3(2000, 2000, 2000);
                isFly = true;
                flySound.Play();
            }
        }
    }
    
    

void Update()
    {


        dir = Vector3.zero;
        h = Input.GetAxis("MoveX");
        v = Input.GetAxis("MoveZ");


        dir += (new Vector3(h, 0, v) * 2);


        //int biggestnum = (a > b) ? a : b;



        transform.position += Vector3.ClampMagnitude(((fly +dir) * speed * Time.deltaTime), 1.0f);
        transform.LookAt(transform.position + dir);


        if(transform.position.x >= 100 && transform.position.z >= 100)
        {
            isFly = false;
            fly = Vector3.zero;
            transform.position = new Vector3(3,1,3);
        }

    }

}
