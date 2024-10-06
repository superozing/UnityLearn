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
        // Raycast 활용: spring arm 등이 있다.

        // Owner Transform forward Vector 구하기
        // 1. 그냥 아주 간단하게 transform.forward를 사용하면 된다.
        // 2. 강의에서 나온 함수인 TransformDirection()을 사용해서
        //  로컬 좌표계 기준 벡터인 Vector3.forward나 Vector3.right를
        //  플레이어의 transform을 적용한 world 기준 벡터로 바꿔준다.

        // 그 함수를 이용해서 전방 벡터에 transform을 적용해서 월드로 이동시켜주어요.
        // var을 사용하면 auto와 같이 R-value의 타입을 가져와서 타입을 자동으로 추론해줘요.
        // 자주 사용하지 않는 것을 추천한다고 해요.
        var lookDirection = transform.TransformDirection(Vector3.forward);

        // 레이를 그리는 함수
        Debug.DrawRay(transform.position + Vector3.up, lookDirection * 10, Color.red);

        // Raycast - 레이를 쏘는 함수.
        // 반환으로 Ray의 hit 성공 여부를 bool로 반환한다.
        // RaycastHit 구조체를 통해서 자세한 충돌 정보를 가져올 수 있다.
        
        /* // 레이캐스트 예시 코드
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, lookDirection, out hit, 10))
            Debug.Log($"RayCast {hit.collider.gameObject.name}");
        */

        // RaycastAll - 레이를 쏘고, 레이에 충돌한 모오오오오오든 물체를 RaycastHit 배열로 반환하는 함수.
        // 이건 out이 아니고 return으로 받아오는거네요. 뭔가 통일성 없어 보이네요.
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, lookDirection, 10);

        // RaycastAll 결과를 foreach문으로 출력할 수 있어요.
        // C#에서는 배열도 자료구조 중 하나니까 자료구조 순회를 할 수 있어요.
        foreach (RaycastHit hitItem in hits)
        {
            Debug.Log($"RayCast {hitItem.collider.gameObject.name}");
        }

    }
}
