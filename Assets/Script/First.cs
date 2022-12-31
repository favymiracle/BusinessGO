using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class First : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnlineButton() {
        SceneManager.LoadScene("Loading");
        Loadding.NextScene = "Online";
    }
    public void OfflineButton() {
        SceneManager.LoadScene("Loading");
        Loadding.NextScene = "Game";
    }
    public void Exit() {
        Application.Quit();
    }

    public void MenuButton() {
        SceneManager.LoadScene("Loading");
        Loadding.NextScene = "Start";
    }
}
