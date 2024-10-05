using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    // 에디터에서 넣어주는 프리팹을 프로그램 시작 시 프리팹 객체화
    // GameObject - 유니티 씬에 배치할 수 있는 모든 객체에 대한 추상 클래스에요.
    // 그렇기 때문에 프리팹도 당연히 넣어줄 수 있다.
    public GameObject prefab;

    GameObject tank;


    void Start()
    {
        // 프리팹 인스턴스화 함수. 반환으로 객체화 된 오브젝트를 반환해요.
        tank = Managers.Resource.Instantiate("Tank");

        // 오브젝트 삭제 함수. 두 번째 인자로 n초 뒤에 삭제할 지 정해줄 수 있어요.
        //Managers.Resource.Destroy(tank);
        Destroy(tank, 3.0f);
    }

}
