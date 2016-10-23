using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MatchScript : MonoBehaviour {
    bool Paused;
    public GameObject PauseScreen;
    public List<GameObject> Tags;
    GameObject Clock;
    public List<GameObject> Players;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Tag1;
    public GameObject Tag2;
    public GameObject Tag3;
    public GameObject Tag4;
    GameObject MatchData;
    public float time;
	// Use this for initialization
	void Awake () {

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
            else if (gO.name == "MenuMusic")
            {
                Destroy(gO);
            }
        }
        PauseScreen.SetActive(false);
    }
	
    void Start()
    {
        Players.Add(Player1);
        Players.Add(Player2);
        Players.Add(Player3);
        Players.Add(Player4);
        Tags.Add(Tag1);
        Tags.Add(Tag2);
        Tags.Add(Tag3);
        Tags.Add(Tag4);
        for (int i = 0; i < Players.Count; i++)
        {
            if (i + 1 > MatchData.GetComponent<MatchSettings>().Players)
            {
                Players[i].SetActive(false);
                Tags[i].SetActive(false);
            }
        }

        Debug.Log(Tags.Count);
        time = Time.deltaTime;
    }

	// Update is called once per frame
	void Update () {
        if (!Paused)
        {
            if(Input.GetButtonDown("Start"))
            {
                Pause();
            }
            time += Time.deltaTime;
            int seconds = (int)time;
            if (seconds >= 60)
            {
                int minutes = 0;
                for (int i = 1; seconds >= 60; i++)
                {
                    seconds -= 60;
                    minutes = i;
                }
                Clock.GetComponent<Text>().text = minutes.ToString() + ":";
                if (seconds <= 9)
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
            for (int i = 0; i < MatchData.GetComponent<MatchSettings>().Players; i++)
            {
                Debug.Log(Tags.Count);
                Tags[i].GetComponentInChildren<Text>().text = Players[i].GetComponent<CharacterMovement>().Coins.ToString();
                MatchData.GetComponent<MatchSettings>().PlayerCoins[i] = Players[i].GetComponent<CharacterMovement>().Coins;
                Debug.Log("Works");
            }
            CheckTime();
        }
    }

    void CheckTime()
    {
        if (time >= MatchData.GetComponent<MatchSettings>().Seconds)
        {
            if (MatchData.GetComponent<MatchSettings>().Seconds != 666)
            {
                SceneManager.LoadScene("MatchOver");
            }
        }
    }

    void Pause()
    {
        PauseScreen.SetActive(true);
        Paused = true;
    }

    public void Resume()
    {
        Paused = false;
        PauseScreen.SetActive(false);
    }

    public void QuitMatch()
    {
        SceneManager.LoadScene("MatchOver");
    }

}
