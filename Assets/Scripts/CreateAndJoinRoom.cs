using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMP_InputField _createRoom, _joinRoom;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(_createRoom.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinRoom.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
