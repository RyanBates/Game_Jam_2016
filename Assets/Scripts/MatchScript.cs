using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MatchScript : MonoBehaviour {
    List<GameObject> Tags;
    GameObject Clock;
    public List<GameObject> Players;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    GameObject MatchData;
    public float time;
	// Use this for initialization
	void Awake () {
        
        //Players.Add(Player1);
        //Players.Add(Player2);
        //Players.Add(Player3);
        //Players.Add(Player4);
        
        //foreach (GameObject gO in FindObjectsOfType<GameObject>())
        //{
        //    if (gO.name == "Clock")
        //    {
        //        Clock = gO;
        //    }
        //    else if (gO.name == "MatchData")
        //    {
        //        MatchData = gO;
        //    }
        //}
	}
	
    void Start()
    {
        //for (int i = 0; i < MatchData.GetComponent<MatchSettings>().Players; i++)
        //{
        //    Instantiate(Players[i]);
        //}
        //Players.Clear();
        //Players = GetPlayers();
        //Tags = GetTags();
        //time = Time.deltaTime;
    }

	// Update is called once per frame
	void Update () {
        //time += Time.deltaTime;
        //int seconds = (int)time;
        //if(seconds >= 60)
        //{
        //    int minutes = 0;
        //    for(int i = 1; seconds >= 60; i++)
        //    {
        //        seconds -= 60;
        //        minutes = i;
        //    }
        //    Clock.GetComponent<Text>().text = minutes.ToString() + ":";
        //    if(seconds <= 9)
        //    {
        //        Clock.GetComponent<Text>().text += "0" + seconds.ToString();
        //    }
        //    else
        //    {
        //        Clock.GetComponent<Text>().text += seconds.ToString();
        //    }

        //}
        //else
        //{
        //    Clock.GetComponent<Text>().text = "0:";
        //    if (seconds <= 9)
        //    {
        //        Clock.GetComponent<Text>().text += "0" + seconds.ToString();
        //    }
        //    else
        //    {
        //        Clock.GetComponent<Text>().text += seconds.ToString();
        //    }
        //}
        //for(int i = 0;i < Players.Count;i++)
        //{
        //    Debug.Log(Tags.Count);
        //    Tags[i].GetComponentInChildren<Text>().text = Players[i].GetComponent<CharacterMovement>().Coins.ToString();
        //Debug.Log("Works");}
        //CheckTime();
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
            if(texts.gameObject.name.Contains("Player"))
            {
                Return.Add(texts.gameObject);
            }
            Debug.Log(texts.gameObject.name);
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
