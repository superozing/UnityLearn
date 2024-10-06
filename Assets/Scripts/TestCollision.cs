using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Collision(충돌) 처리에 필요한 조건
    //  1. IsKinematic이 false인 "Rigidbody" component가 있어야 한다.
    //  2. IsTrigger이 false인 "Collider" component가 있어야 한다.

    //  3. 충돌한 상대 오브젝트에게도 1번과 2번이 적용되어야 한다.

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌 발생 시 로그 출력
        // 충돌이 발생하면 이 함수로 들어오는데... 무슨 원리로 들어오는 걸까요?
        Debug.Log("On Collision");
    }

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
