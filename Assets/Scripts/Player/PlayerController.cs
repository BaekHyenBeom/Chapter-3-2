using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public float dashForce;
    public int dashDuration;
    public float stopMove;
    public LayerMask groundLayerMask;

    private Vector3 beforeDirection;
    
    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;
    public Transform cameraTransform;
    public Vector3 thirdPerson;
    public bool cameraChanged;
    
    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (stopMove <= 0) { return; }
        stopMove -= Time.deltaTime;
        if (stopMove <= 0) { stopMove = 0f; }
    }

    private void FixedUpdate()
    {
        
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }

    // 카메라 인칭 변환
    public void OnCameraInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (cameraChanged)
            {
                cameraChanged = false;
                cameraTransform.localPosition = Vector3.zero;
            }
            else
            {
                cameraChanged = true;
                cameraTransform.localPosition = thirdPerson;
            }
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
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

    private void Move()
    {
        if (stopMove > 0) { return; }
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        if (dir != Vector3.zero)
        {
            _rigidbody.AddForce(dir, ForceMode.Acceleration);
            beforeDirection = dir;
        }
        else
        {
            if(dir != beforeDirection)
            {
                _rigidbody.AddForce(dir, ForceMode.Acceleration);
                beforeDirection = dir;
            }
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(5))
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            }
            
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    // 추후에 대쉬 쿨타임도 넣어줄 것
    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            if (curMovementInput == Vector2.zero) { return; }
            Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
            dir.y = _rigidbody.velocity.y;
            if (CharacterManager.Instance.Player.condition.UseStamina(10))
            {
                StartCoroutine(Dash(dir));
            }
        }
    }

    IEnumerator Dash(Vector3 dir)
    {
        stopMove = 0.01f * dashDuration;
        _rigidbody.AddForce(dir * moveSpeed, ForceMode.VelocityChange);
        for (int i = 0; i < dashDuration; i++)
        {
            _rigidbody.AddForce(dir * dashForce, ForceMode.Impulse);
            yield return new WaitForSeconds(0.01f);
        }
        _rigidbody.velocity = Vector3.zero;
    }
}
