using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;



public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] string ip;
    [SerializeField] string gameVersion = "1";
    [SerializeField] byte maxPlayers = 16;

    public void JoinRoom () 
    {

        if (PhotonNetwork.CountOfRooms == 0)
            PhotonNetwork.CreateRoom("game", new RoomOptions { MaxPlayers = maxPlayers });
        else
        {
            PhotonNetwork.JoinRoom("game");

        }
    
    } 

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect(ip, 5055 , "");
        //PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AuthValues = new AuthenticationValues();
        PhotonNetwork.AuthValues.UserId = System.DateTime.Now.ToString();
        print(PhotonNetwork.AuthValues.UserId);




    }
    public override void OnJoinedRoom()
    {

        PhotonNetwork.LoadLevel(1);
    
    }

    void Connect(string ip, int port, string appID)
    {

        PhotonNetwork.ConnectToMaster(ip, port, appID);
        PhotonNetwork.GameVersion = gameVersion;

    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            JoinRoom();
        print(PhotonNetwork.NetworkClientState);

     }


}
