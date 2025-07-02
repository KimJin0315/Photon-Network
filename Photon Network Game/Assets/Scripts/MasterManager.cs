using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;

public class MasterManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject clone;
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
                if (clone == null)
                {
                    clone = PhotonNetwork.InstantiateRoomObject("Unit", direction, Quaternion.identity);
                }
                else
                {
                    yield break;
                }
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
