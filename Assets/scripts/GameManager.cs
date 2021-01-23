using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

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
            DontDestroyOnLoad(HUD);
        }
        else Destroy(this);

        //SceneManager.LoadScene(1);
    }
    [SerializeField] GameObject playerPrefab;
    public PlayerController localPlayer;
    public MapController mc;
    public Canvas HUD;

    public UnityEngine.UI.Text hintText;

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
            PhotonNetwork.Instantiate(playerPrefab.name,Vector3.zero+ Vector3.up* 2,Quaternion.identity);
    }


}
