using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // 를 사용하면 private도 에디터에 표시시킬 수 있다.
    float _speed = 10.0f;

    float _yAngle = 0.0f;

    void Start()
    {
        
    }

    // GameObject (Player)
    // Transform
    // PlayerController (current)
    void Update()
    {

        float deltaSpeed = Time.deltaTime * _speed;

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

        _yAngle += deltaSpeed * 100;

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
    }
}
