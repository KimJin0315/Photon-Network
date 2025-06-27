using System.ComponentModel;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] double time;
    [SerializeField] double intializeTime;

    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int milliSecond;

    [SerializeField] Text timeText;

    void Start()
    {
        intializeTime = PhotonNetwork.Time;
    }

    void Update()
    {
   
        time = PhotonNetwork.Time - intializeTime;

        minute = (int)time / 60;
        second = (int)time % 60;
        milliSecond = (int)(time * 100) % 100;

        timeText.text = $"{minute:D2} : {second:D2} : {milliSecond:D2}";
    }
}
