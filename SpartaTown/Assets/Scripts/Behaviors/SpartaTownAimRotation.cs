using UnityEngine;

public class SpartaTownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private SpartaTownController controller;

    private void Awake()
    {
        controller = GetComponent<SpartaTownController>();
    }

    void Start()
    {
        // 마우스의 위치가 들어오는 OnLookEvent에 등록하는 것
        controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        // OnLook
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        // Atan2는 직각삼각형이 있다고 할 때 세로가 y, 가로가 x일 때 그 각도를 라디안 [-Pi,Pi]로 나타내는 함수임
        // 라디안의 -Pi는 -180도, Pi는 180도 이므로 Mathf.Rad2Deg는 약 57.29임 (180 / 3.14)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // [1. 캐릭터 뒤집기]
        // 이때 각도는 오른쪽(1,0 방향)이 0도이므로,
        // -90~90도에서는 오른쪽을 바라보는 게 맞지만, -90도 미만 90도 초과라면 왼쪽을 바라보는 것임.
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}