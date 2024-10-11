using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : SpartaTownController
{
    private Camera camera;
    

    private void Awake()
    {
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        // �÷��̾� ��ġ�� ī�޶� ��ġ�� ����ȭ
        Vector3 playerPos = transform.position;
        playerPos.z = camera.transform.position.z; // ī�޶��� z���� ����
        camera.transform.position = playerPos;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if( newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }
}
