using UnityEngine;
using System.Collections;

// This script should be attached to an empty project.
public class Coin_Dropper : MonoBehaviour {

    public bool Dropping = false, Dropped = false;
    float currentTime, previousTime = 0, deltaTime = 0, timer = 10;
    public GameObject Coin;
    public float minX, maxX;
    bool right = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Dropping)
        {
            currentTime = Time.time;
            deltaTime = currentTime - previousTime;

            if (deltaTime >= timer)
            {
                Instantiate(Coin, transform.position, Quaternion.identity);
                Dropped = true;
                previousTime = currentTime;
                deltaTime = 0;
            }
        }
        else
        {
            currentTime = Time.time;
            previousTime = currentTime;
        }
        if(right)
        {
            if(transform.position.x <= -10)
            {
                right = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }
        else if(!right)
        {
            if(transform.position.x >= 10)
            {
                right = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }
	}
}
