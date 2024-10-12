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
        #region
        /*
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
        
        // 레이캐스트 예시 코드
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, lookDirection, out hit, 10))
            Debug.Log($"RayCast {hit.collider.gameObject.name}");
        

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
        */

        //===============
        // 투영의 개념
        //===============

        // 로컬 <-> 월드 <-> 스크린
        // 로컬 좌표계는 오브젝트 개인, 특정 물체를 기준으로 한다.
        // 월드 좌표계는 모든 오브젝트가 공유하는 하나의 좌표계이다.

        // Debug.Log(Input.mousePosition); // Screen
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport, "비율"

        // 유니티는 절두체 컬링과 오클루전 컬링을 통해 최적화 한다.
        // Camera near(가장 가까운 곳), far(가장 먼 곳) 조절 가능

        // 월드 상에서 뷰포트에 투영을 할 때, 실제 화면보다 살짝 뒤에 있는 시선으로 전부 투영을 시킨다.
        // rasterizer가 vertex에 따라서 그릴 픽셀을 계산해요.

        // 이쯤에서 다시 떠올려보는 렌더링 파이프라인
        // IA VS HS TS DS GS RS PS OM
        // IA - VB IB set
        // VS - 정점 정보세팅
        // HS - 정점 분할 레벨 세팅
        // TS - 테셀레이션(분할 레벨에 따라 분할하기)
        // DS - TS에서 분할한 정점 정보 다시 세팅
        // GS - 정점 분할, 추가, 삭제에 사용
        // RS - 정점 정보를 기반으로 화면에 그려질 픽셀 구하기, 정점 정보 보간
        // PS - 입력된 머터리얼과 보간된 정점 정보, 텍스쳐를 기반으로 픽셀 색상 결정
        // OM - 깊이 버퍼에 기록, 깊이 정보에 따라 해당 픽셀을 그릴 지 말 지 결정

        #endregion

        //===============
        // Raycasting #2
        //===============

        // 인자로 0 -> 왼 쪽 마우스
        if (Input.GetMouseButtonDown(0))
        {
            // 뷰포트 상에서 클릭을 하면 cam pos에서 클릭한 dir로 ray를 발사한다.
            // 이 때 충돌한 오브젝트를 인스펙터에 띄워줘요.


            // 스크린 좌표를 월드 기준 좌표로 변환해요.
            // z로 0을 넣으면 카메라의 좌표를 반환해요.
            // 왜일지 생각해보았다. 방향 벡터를 구할 때 위치가 같으면 vec3(0,0,0)이 나와서 그런 것 같아요.
            // near 값을 넣어서 투영되는 부분의 정확한 월드 기준 좌표를 알 수 있어요.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 CamPos = Camera.main.transform.position;

            // ray 시각화
            Debug.DrawRay(CamPos, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;

            // | -> or 비트연산자. 두 비트중 하나라도 1이면 1
            LayerMask layerMask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            // int Mask = (1 << 6) | (1 << 7); // 위 코드와 같은 내용을 실행

            // 충돌시킬 레이어 비트 기록
            if (Physics.Raycast(ray, out hit, 100.0f, layerMask)) // ray max duration 지정
            {
                Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
            }
        }

    }
}
