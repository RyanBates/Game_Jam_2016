using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MatchScript : MonoBehaviour {
    List<GameObject> Tags;
    GameObject Clock;
    GameObject Gladiator;
    List<GameObject> Players;
    GameObject MatchData;
    public float time;
	// Use this for initialization
	void Start () {
        foreach(GameObject gO in FindObjectsOfType<GameObject>())
        {
            if(gO.name.Contains("Player"))
            {
                //Tags.Add(gO);
            }
            else if(gO.name == "Clock")
            {
                Clock = gO;
            }
            else if(gO.name == "MatchData")
            {
                MatchData = gO;
            }
        }
        //for(int i = 0; i < MatchData.GetComponent<MatchSettings>().Players; i++)
        //{
        //    GameObject player = Instantiate(Gladiator, new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
        //    Players.Add(player);
        //}
        time = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        int seconds = (int)time;
        Debug.Log(seconds);
        if(seconds >= 60)
        {
            int minutes = 0;
            for(int i = 1; seconds >= 60; i++)
            {
                seconds -= 60;
                minutes = i;
            }
            Clock.GetComponent<Text>().text = minutes.ToString() + ":";
            if(seconds <= 9)
            {
                Clock.GetComponent<Text>().text += "0" + seconds.ToString();
            }
            else
            {
                Clock.GetComponent<Text>().text += seconds.ToString();
            }

        }
        else
        {
            Clock.GetComponent<Text>().text = "0:";
            if (seconds <= 9)
            {
                Clock.GetComponent<Text>().text += "0" + seconds.ToString();
            }
            else
            {
                Clock.GetComponent<Text>().text += seconds.ToString();
            }
        }
        CheckTime();
	}

    void CheckTime()
    {
        if(time >= MatchData.GetComponent<MatchSettings>().Seconds)
        {
            Destroy(MatchData);
            SceneManager.LoadScene("Menu");
        }
    }

}
