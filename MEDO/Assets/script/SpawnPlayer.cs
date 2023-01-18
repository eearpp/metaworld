using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;


public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    [SerializeField] private CinemachineVirtualCamera TPS;

    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);

        TPS.Follow = PlayerSet.Instance.cameratarget.transform;
    }
}
