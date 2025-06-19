using Photon.Pun;
using UnityEngine;

public class Character : MonoBehaviourPun
{
    [SerializeField] Vector3 direction;

    [SerializeField] Camera virtualCamera;
    [SerializeField] CharacterController characterController;
    [SerializeField] float speed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Control();

            Move();
        }

    }

    public void Control()
    {
         direction.x = Input.GetAxisRaw("Horizontal");
         direction.z = Input.GetAxisRaw("Vertical");

         direction.Normalize();
    }

    public void Move()
    {
        // 방향 * 속도 * 시간
        characterController.Move(direction * speed * Time.deltaTime);
    }

    public void DisableCamera()
    {
        // 현재 플레이어가 나 자신이라면
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            virtualCamera.gameObject.SetActive(false);
        }
    }
}
