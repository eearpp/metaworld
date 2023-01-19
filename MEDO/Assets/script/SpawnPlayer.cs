using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;


public class SpawnPlayer : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera TPS;

    [SerializeField] GameObject spawntarget;

    public List<GameObject> characterHold;

    void Start()
    {
        //int numselect =  PlayerPrefs.GetInt("selectCha");
        PhotonNetwork.Instantiate(characterHold[PlayerPrefs.GetInt("selectCha")].name, spawntarget.transform.position, Quaternion.identity);

        TPS.Follow = PlayerSet.Instance.cameratarget.transform;
    }
}
