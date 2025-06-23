using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviourPunCallbacks
{
    [SerializeField] List<Transform> transformList;

    void Start()
    {
        int index = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        PhotonNetwork.Instantiate("Character", transformList[index].position, Quaternion.identity);
    }

}
