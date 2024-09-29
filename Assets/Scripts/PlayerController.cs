using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // 를 사용하면 private도 에디터에 표시시킬 수 있다.
    float _speed = 10.0f;

    void Start()
    {
        
    }

    // GameObject (Player)
        // Transform
        // PlayerController (current)
    void Update()
    {
        float deltaSpeed = Time.deltaTime * _speed;

        // transform - 해당 오브젝트에 있는 트랜스폼 컴포넌트
        // TransformDirection() - transform direction을 local 좌표계에서 world 좌표계로 변환 후 반환
        // InverseTransformDirection() - transform direction을 world 좌표계에서 local 좌표계로 변환 후 반환

        // transform.translate() -  local 좌표계 기준으로 연산해줌.


        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * deltaSpeed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * deltaSpeed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * deltaSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * deltaSpeed);
    }
}
