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
        foreach (GameObject gO in FindObjectsOfType<GameObject>())
        {
            if (gO.name == "Clock")
            {
                Clock = gO;
            }
            else if (gO.name == "MatchData")
            {
                MatchData = gO;
            }
        }
        Tags = GetTags();
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

    List<GameObject> GetTags()
    {
        List<GameObject> Return = new List<GameObject>();
        foreach(Text texts in FindObjectsOfType<Text>())
        {
            if(texts.gameObject.name.Contains("Players"))
            {
                Return.Add(texts.gameObject);
            }
        }
        return Return;
    }
   
    List<GameObject> GetPlayers()
    {
        List<GameObject> Return = new List<GameObject>();
        foreach(CharacterMovement characters in FindObjectsOfType<CharacterMovement>())
        {
            Return.Add(characters.gameObject);
        }
        return Return;
    }

}
