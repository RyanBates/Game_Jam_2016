using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class Music : MonoBehaviour
{
    static Music _play;


    public static Music play
    {
        get
        {
            if (_play == null)
                _play = FindObjectOfType<Music>();
            
            return _play;
        }
    }

    void Awake()
    {
        if (_play == null)
        {
            _play = this;
            DontDestroyOnLoad(this);
        }

        if(_play != null)
            Destroy(this);
    }


    
}
