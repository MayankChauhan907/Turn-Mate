using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject Player_Prefab;
    [SerializeField]
    Transform _player1Pos, _player2Pos;
    [SerializeField]
    List<Transform> PositionsToSpawn;
    [SerializeField]
    Vector3 _offSet;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            PhotonNetwork.Instantiate(Player_Prefab.name, _player1Pos.position + _offSet, Quaternion.identity);
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            PhotonNetwork.Instantiate(Player_Prefab.name, _player2Pos.position + _offSet, Quaternion.identity);
        }
    }
}
