using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance() { return _instance; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        // obj -> bool => true, null -> bool => false
        if (_instance == null)// if (!instance)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);

        SceneManager.LoadScene(1);
    }

    public MapController mc;
}
