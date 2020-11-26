using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = System.Random;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject availableButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby= this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connecting to Photon server
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        availableButton.SetActive(true);
    }

    public void OnAvailableButton()
    {
        Debug.Log("Available Button was click");
        availableButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no room available.");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create a room");
        Random hazar = new Random();
        int randomRoomName = hazar.Next(0, 1000);
        RoomOptions roomOptions = new RoomOptions(){IsVisible = true, IsOpen = true, MaxPlayers = (byte) MultiplayerSetting.multiplayerSetting.maxPlayers } ;
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("We are now in a room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed. There must already be a room with the same name.");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        Debug.Log("Cancel button was click");
        cancelButton.SetActive(false);
        availableButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
