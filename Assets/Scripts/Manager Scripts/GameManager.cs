using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public static object Instance { get; internal set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public void RestartGame()
    {
        Invoke("RestartAfterTime", 2f);
    }

    void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
