using UnityEngine;
using System.Collections;

// This script should be attached to an empty project.
public class Coin_Dropper : MonoBehaviour {

    public bool Dropping, Dropped;
    float currentTime, previousTime = 0, deltaTime = 0, timer = 5;
    public GameObject Coin, Stage;
    public float minZ, maxZ;

	// Use this for initialization
	void Start () {
        Dropping = false;
        Dropped = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Dropping)
        {
            currentTime = Time.time;
            deltaTime = currentTime - previousTime;

            if (deltaTime >= timer)
            {
                Instantiate(Coin, transform);
                Dropped = true;
                previousTime = currentTime;
                deltaTime = 0;
            }
        }
	}
}
