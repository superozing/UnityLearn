using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // 를 사용하면 private도 에디터에 표시시킬 수 있다.
    float _speed = 10.0f;

    Vector3 _destPos = Vector3.zero;
    PlayerState _state = PlayerState.Idle;

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }


    void Start()
    {
        // 입력 매니저 이벤트에 델리게이트를 등록시킴.
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

#region States
    void UpdateDie()
    {
    }

    void UpdateMoving()
    {
        Vector3 unnormDir = _destPos - transform.position;

        // float 오차 범위를 생각해서 매직 넘버 사용
        // 만약 destPos에 도착했을 경우, Idle state로 변경
        if (unnormDir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle; 
        }
        else
        {
            // 더 큰 범위를 이동하지 않도록 clamp
            float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, unnormDir.magnitude);
            transform.position += unnormDir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(unnormDir), 20 * Time.deltaTime);
        }

        // anim set

        Animator anim = GetComponent<Animator>();
    }

    void UpdateIdle()
    {
        // anim set

        Animator anim = GetComponent<Animator>();
    }

#endregion


    // GameObject (Player)
    // Transform
    // PlayerController (current)
    void Update()
    {
        #region 주석
        // =======================
        //  Transform, translate
        // =======================
        // transform - 해당 오브젝트에 있는 트랜스폼 컴포넌트
        // TransformDirection() - transform direction을 local 좌표계에서 world 좌표계로 변환 후 반환
        // InverseTransformDirection() - transform direction을 world 좌표계에서 local 좌표계로 변환 후 반환
        // transform.translate() -  local 좌표계 기준으로 연산해줌.

        // =======================
        //  Vector3
        // =======================
        // Vector3 vec3 = new Vector3();
        // float len = vec3.magnitude; // 벡터의 크기를 반환
        // Vector3 dir = vec3.normalized; // 정규화된 벡터를 반환


        // ======================== 
        //  Rotation
        // ======================== 
        // transform.rotation; 쿼터니언을 사용한 로테이션(통상적)
        // transform.eulerAngles; // 오일러 각도를 사용한 회전


        // 오일러 앵글은 매번 값을 세팅해주어야 한다고 유니티 공식 문서에 적혀있다.
        // eulerAngles의 값을 직접 수정하면 안된다. 360도를 넘어설 경우 오류가 생긴다고 해요.

        // 절대값 지정으로 회전 세팅
        // transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // Rotate() - 원본 값을 인자로 들어온 값 만큼 더해준다.
        // transform.Rotate(new Vector3(0.0f, deltaSpeed, 0.0f));


        // 오일러 앵글 대신 쿼터니언(사원수)를 사용하는 이유: 짐벌록
        // 회전하는 두 축이 겹칠 경우 축의 제어권을 잃어버리는 현상.

        // 쿼터니언을 사용해서 정확한 회전을 구현할 수 있고, 짐벌락 해결 가능.
        // var quat = transform.rotation;

        // euler angle -> quaternion으로 변환하는 함수
        // transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));
        #endregion

        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

    }

    void OnMouseClicked(Define.MouseEvent e)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;  // state를 moving으로 변경
        }
    }
}
