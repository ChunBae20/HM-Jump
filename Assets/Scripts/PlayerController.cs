using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //레이의 시각화
    [Header("레이 길이")]
    [Tooltip("이거수정하면 레이길이달라짐")]
    public float RayLength = 5f;

    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity; //마우스 민감도
    private Vector2 mouseDelta;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        Move();
        IsGrounded();


    }

    //물리연산을 하는것은 FixedUpdate에서 하는게 좋다.
    private void FixedUpdate()
    {

    }
    private void LateUpdate()
    {
        CameraLook();

    }

    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {

        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
        //transform.EulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }


    public void Onmove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            Debug.Log("점프");
        }
    }
    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position+(transform.forward*0.2f)+(transform.up*0.01f),Vector3.down),
            new Ray(transform.position+(-transform.forward*0.2f)+(transform.up*0.01f),Vector3.down),
            new Ray(transform.position+(transform.right*0.2f)+(transform.up*0.01f),Vector3.down),
            new Ray(transform.position+(-transform.right*0.2f)+(transform.up*0.01f),Vector3.down)

        };

        for (int i = 0; i < rays.Length; i++)
        {
            //Debug.DrawRay사용법
            //DrawRay(설정해둔 레이배열.출발점 , 어디를향해쏠건지,보이는 색)

            //레이 배열의 출발점 : 배열.origin하면 됨 origin은 유니티 제공임
            //어디를 향해 쏠건지: 배열에 vector를 그대로 복붙하면됨
            //보이는 색 :  색도 커스텀 가능임

            Debug.DrawRay(rays[i].origin, Vector3.down * RayLength, Color.red);


            if (Physics.Raycast(rays[i], RayLength, groundLayerMask))
            {
                return true;
            }
        }
        return false;

    }



}

#region 레이 실시간으로 보는법
/*

void Update()
    {
        DrawGroundRays(); //  항상 Ray가 보이도록 Update에서 호출
    }

    void DrawGroundRays() //  Ray 시각화 전용 메서드
    {
        Ray[] rays = new Ray[4]
        {
        new Ray(transform.position+(transform.forward*0.2f)+(transform.up*0.01f), Vector3.down),
        new Ray(transform.position+(-transform.forward*0.2f)+(transform.up*0.01f), Vector3.down),
        new Ray(transform.position+(transform.right*0.2f)+(transform.up*0.01f), Vector3.down),
        new Ray(transform.position+(-transform.right*0.2f)+(transform.up*0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            Debug.DrawRay(rays[i].origin, rays[i].direction * 0.7f, Color.red);
        }
    }

*/
#endregion