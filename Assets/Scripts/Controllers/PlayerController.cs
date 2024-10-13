using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // 를 사용하면 private도 에디터에 표시시킬 수 있다.
    float _speed = 10.0f;

    bool _isMoveToDest = false;
    Vector3 _destPos = Vector3.zero;

    void Start()
    {
        // 여러 번 이벤트를 등록하지 않도록 이미 등록된 이벤트가 있을 경우 빼는 처리를 해주는 것.
        // 근데 애초에 이런 코드로 돌려막기를 하는 것 보다는 직접적인 원인을 찾아서 제거하는 것이 맞지 않을까?
        Managers.Input.KeyAction -= OnKeyboard; 

        // 입력 매니저 이벤트에 델리게이트를 등록시킴.
        Managers.Input.KeyAction += OnKeyboard;


        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

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

        Animator anim = GetComponent<Animator>();

        if (_isMoveToDest)
        {
            anim.Play("RUN");

            Vector3 unnormDir = _destPos - transform.position;

            // float 오차 범위를 생각해서 매직 넘버 사용
            if (unnormDir.magnitude < 0.0001f) 
            {
                _isMoveToDest = false;
                return;
            }

            // 더 큰 범위를 이동하지 않도록 clamp
            float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, unnormDir.magnitude);

            transform.position += unnormDir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(unnormDir), 20 * Time.deltaTime);
        }
        else
        {
            anim.Play("WAIT");
        }


    }

    // 만약 키 입력이 있을 경우에만 해당 함수의 내용을 실행하기 위해서 입력 매니저 이벤트에 델리게이트를 등록시킴.
    void OnKeyboard()
    {
        float deltaSpeed = Time.deltaTime * _speed;

        if (Input.GetKey(KeyCode.W))
        {
            // LookRotation() - 바라보는 방향(아마 로컬 기준의 전방 벡터) 설정하는 함수
            // transform.rotation = Quaternion.LookRotation(Vector3.forward); // Vector3.forward는 월드 기준 좌표이다.
            // 하지만 위와 같은 함수의 동작은 너무 딱딱 맞추어 움직이는 느낌이 난다.
            // 선형 보간 함수를 사용해서 부드러운 동작을 만들 수 있다.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);

            // 플레이어 전방 벡터가 선형적으로 달라지고 있기 때문에 전방 벡터에 더해주는 것은 회전중일 때 전방으로만 가는 것이 아닌, 다른 방향으로 이동하게 된다.
            // transform.Translate(Vector3.forward * deltaSpeed);

            // translate를 사용해서 움직이는 것이 아닌, forward벡터에 speed를곱하고 position += 연산을 해주는 것이 자연스럽다.
            transform.position += Vector3.forward * deltaSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            // transform.Translate(Vector3.forward * deltaSpeed);
            transform.position += Vector3.back * deltaSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            // transform.Translate(Vector3.forward * deltaSpeed);
            transform.position += Vector3.left * deltaSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            //transform.Translate(Vector3.forward * deltaSpeed);
            transform.position += Vector3.right * deltaSpeed;
        }

        _isMoveToDest = false;
    }

    void OnMouseClicked(Define.MouseEvent e)
    {
        //if (e != Define.MouseEvent.Click)
        //    return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {

            _isMoveToDest = true;
            _destPos = hit.point;



            //Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
