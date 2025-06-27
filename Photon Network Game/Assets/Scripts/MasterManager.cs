using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Vector3 direction;
    [SerializeField] WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }
    public IEnumerator Create()
    {
        while(true)
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.InstantiateRoomObject("Unit", direction, Quaternion.identity);
            }

            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log(newMasterClient);

        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }
}
