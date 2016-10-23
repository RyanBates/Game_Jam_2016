using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchSettings : MonoBehaviour {
    Text SText;
    Text CText;
    public float Seconds;
    public float Coins;
	// Use this for initialization
	void Start () {
        Seconds = 30;
        Coins = 5;
        foreach(Text texts in FindObjectsOfType<Text>())
        {
            if(texts.transform.gameObject.name == "SecondsText")
            {
                SText = texts;
            }
            else if(texts.transform.gameObject.name == "CoinText")
            {
                CText = texts;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TimeRButton()
    {
        if (Seconds == 300)
        {
            Seconds = 666;
            SText.text = "∞" + " Seconds";
        }
        else if(Seconds == 666)
        {
            Seconds = 30;
            SText.text = Seconds.ToString() + " Seconds";
        }
        else
        {
            Seconds += 15;
            SText.text = Seconds.ToString() + " Seconds";
        }
    }

}
