using Photon.Pun;
using UnityEngine;

public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    void Update()
    {
        if (photonView.IsMine == false) return;

        RotateX();
    }

    public void RotateX()
    {
        // mouseX에 마우스로 입력한 값을 저장합니다.

        mouseX += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        // mouseX의 값을 -65 ~65 사이의 값으로 제한합니다.

        mouseX = Mathf.Clamp(mouseX, -65f, 65f);

        transform.localEulerAngles = new Vector3(-mouseX, 0, 0);
    }
}
