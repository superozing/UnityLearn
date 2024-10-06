using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Collision(충돌) 처리에 필요한 조건
    //  1. 나 혹은 상대에게 IsKinematic이 false인 "Rigidbody" component가 있어야 한다.
    //  2. 나와 상대에게 IsTrigger이 false인 "Collider" component가 있어야 한다.

    // 충돌 시, physics material을 사용해서 물리적인 성질을 설정할 수 있다. (마찰, 탄성 등)
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌 발생 시 로그 출력
        // 충돌이 발생하면 이 함수로 들어오는데... 무슨 원리로 들어오는 걸까요?
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    // Trigger와 Collision의 차이점
    // 충돌 처리에는 매우 큰 물리 계산이 들어간다.
    // 트리거는 자신의 충돌체 안에 물체가 있는지 확인만 하기에 연산이 적다.

    // Trigger 처리에 필요한 조건
    // 두 오브젝트 모두 collider를 가져야 해요.
    // 두 오브젝트 중 하나 이상의 오브젝트의 Rigidbody component를 소유하고, IsTrigger가 true여야 해요.

    // 사용 예) 스킬 범위 판정, 던전 입장 경계선 등
    private void OnTriggerEnter(Collider other)
    {
        // 트리거 발생 시 로그 출력
        // 트리거가 발생하면 이 함수로 들어오는데... 무슨 원리로 들어오는 걸까요?
        Debug.Log("On Trigger");

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
