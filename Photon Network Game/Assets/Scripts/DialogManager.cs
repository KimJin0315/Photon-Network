using Photon.Pun;
using PlayFab.DataModels;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransform;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if(inputField.text.Length <= 0 )
            {
                return;
            }

            string talk = PhotonNetwork.LocalPlayer.NickName + " : " + inputField.text; 

            // RPC Target.All : 현재 룸에 있는 모든 클라이언트에게 Talk() 함수를
            //                  실행하라고 명령을 전달합니다.

            photonView.RPC("Talk", RpcTarget.All, talk);

            inputField.text = "";

            inputField.ActivateInputField();
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        // prefab을 하나 생성한 다음 text에 값을 설정합니다.
        GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"));

        // prefab 오브젝트의 Text 컴포넌트로 접근해서 text의 값을 설정합니다.
        talk.GetComponent<Text>().text = message;

        // 스크롤 뷰 . content 오브젝트의 자식으로 등록합니다.
        talk.transform.SetParent(parentTransform);

        // Canvas를 수동으로 동기화시킵니다.
        Canvas.ForceUpdateCanvases();

        // 스크롤의 위치를 초기화합니다.
        scrollRect.verticalNormalizedPosition = 0.0f;

    }
}
