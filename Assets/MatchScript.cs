using UnityEngine;
using System.Collections.Generic;

public class MatchScript : MonoBehaviour {
    List<GameObject> Tags;
    GameObject Clock;
	// Use this for initialization
	void Start () {
        foreach(GameObject gO in FindObjectsOfType<GameObject>())
        {
            string ShortenedName = "";
            for(int i = 0; i < 5; i++)
            {
                ShortenedName += gO.name[i];
            }
            if(ShortenedName == "Player")
            {
                Tags.Add(gO);
            }
            if(ShortenedName == "Clock")
            {
                Clock = gO;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
