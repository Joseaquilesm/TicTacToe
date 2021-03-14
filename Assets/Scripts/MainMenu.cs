using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //nothing
    }

    // Update is called once per frame
    void Update()
    {
        //nothing
    }

    public void OnlineGame ()
    {
        SceneManager.LoadScene("Online");
    }

    public void OfflineGame ()
    {
        SceneManager.LoadScene("Offline");
    }

    public void QuitGame ()
    {
        Debug.Log("The game has quit.");
        Application.Quit();
    }
}
