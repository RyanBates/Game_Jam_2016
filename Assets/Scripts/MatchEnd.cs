using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchEnd : MonoBehaviour {

    public List<GameObject> PlayerCoins;
    public GameObject MatchData;

	// Use this for initialization
	void Start () {
        foreach(GameObject gO in FindObjectsOfType<GameObject>())
        {
            if(gO.name == "MatchData")
            {
                MatchData = gO;
            }
        }
        for(int i = 0; i < MatchData.GetComponent<MatchSettings>().Players; i++)
        {
            if(i + 1 > MatchData.GetComponent<MatchSettings>().Players)
            {
                PlayerCoins[i].SetActive(false);
            }
            else
            {
                PlayerCoins[i].GetComponentInChildren<Text>().text = MatchData.GetComponent<MatchSettings>().PlayerCoins[i].ToString();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKey)
        {
            BackToMain();
        }
	}

    public void BackToMain()
    {
        Destroy(MatchData);
        SceneManager.LoadScene("Menu");
    }
}
