using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagement : MonoBehaviour {


    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

}
