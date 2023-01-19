using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Server_core : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField createInput;
    [SerializeField] InputField joinInput;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() //toConect the photon server
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        PlayerPrefs.SetInt("selectCha", Select_player.Instance.listCount);
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PlayerPrefs.SetInt("selectCha", Select_player.Instance.listCount);
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }

    public void disconnect()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("lobby");
    }

}
