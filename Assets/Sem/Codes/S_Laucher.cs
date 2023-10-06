using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Realtime;
using Photon.Pun;


public class S_Laucher : MonoBehaviourPunCallbacks
{
    [SerializeField] private byte maxPlayers = 4;
    [SerializeField] private GameObject controlPanel;


    private bool isConnecting;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        controlPanel.SetActive(true);
        Debug.Log("Esenlikler");
    }

    public void Connect()
    {
        isConnecting = true;
        controlPanel.SetActive(false);


        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = "1.0";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {

        controlPanel.SetActive(true);
        Debug.Log("baglnati kesildi");
        isConnecting = false;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = maxPlayers });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
        Debug.Log("Room name: " + PhotonNetwork.CurrentRoom.Name + "baglandi");
        PhotonNetwork.LoadLevel("PunBasics-Room for 1");
    }
}