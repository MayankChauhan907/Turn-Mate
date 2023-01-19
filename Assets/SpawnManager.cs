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
    Vector3 _offSet;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(Player_Prefab.name, _player1Pos.position + _offSet, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
