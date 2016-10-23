using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MatchSettings : MonoBehaviour {
    Slider PlayerAmount;
    Text SText;
    Text CText;
    Text PText;
    public float Players;
    public float Seconds;
    public float Coins;
    public List<float> PlayerCoins;
    float Player1Coins;
    float Player2Coins;
    float Player3Coins;
    float Player4Coins;
    
    // Use this for initialization
    void Start () {
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
            else if(texts.transform.gameObject.name == "PlayerText")
            {
                PText = texts;
            }
        }
        PlayerAmount = FindObjectOfType<Slider>();
        Players = 1;
        PlayerCoins.Add(Player1Coins);
        PlayerCoins.Add(Player2Coins);
        PlayerCoins.Add(Player3Coins);
        PlayerCoins.Add(Player4Coins);
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

    public void TimeLButton()
    {
        if (Seconds == 30)
        {
            Seconds = 666;
            SText.text = "∞" + " Seconds";
        }
        else if (Seconds == 666)
        {
            Seconds = 300;
            SText.text = Seconds.ToString() + " Seconds";
        }
        else
        {
            Seconds -= 15;
            SText.text = Seconds.ToString() + " Seconds";
        }
    }

    public void CoinRButton()
    {
        if (Coins == 50)
        {
            Coins = 666;
            CText.text = "∞" + " Coins";
        }
        else if (Coins == 666)
        {
            Coins = 5;
            CText.text = Coins.ToString() + " Coins";
        }
        else if (Coins == 30 || Coins == 40)
        {
            Coins += 10;
            CText.text = Coins.ToString() + " Coins";
        }
        else
        {
            Coins += 5;
            CText.text = Coins.ToString() + " Coins";
        }
    }

    public void CoinLButton()
    {
        if (Coins == 5)
        {
            Coins = 666;
            CText.text = "∞" + " Coins";
        }
        else if (Coins == 666)
        {
            Coins = 50;
            CText.text = Coins.ToString() + " Coins";
        }
        else if (Coins == 40 || Coins == 50)
        {
            Coins -= 10;
            CText.text = Coins.ToString() + " Coins";
        }
        else
        {
            Coins -= 5;
            CText.text = Coins.ToString() + " Coins";
        }
    }

    public void PlayerChange()
    {
        Players = PlayerAmount.value;
        PText.text = "Players: " + Players.ToString();
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
