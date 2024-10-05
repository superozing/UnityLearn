using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 프리팹 로드를 디버깅 용도로 이 곳에서 한 번에 확인하기 위해서
// 기존 리소스 관련 코드를 래핑
public class ResourceManager
{
    // 템플릿 함수.
    // where 문법: 템플릿을 사용할 때 반드시 특정 클래스 또는 특정 클래스를 상속받은 클래스만 템플릿을 사용할 수 있다.
    public T Load<T>(string path) where T : Object
    {
        // 리소스를 불러오는 것은 반드시 Asset의 Resources 폴더 안에 있어야 불러올 수 있다.
        // 그 안에 있는 것을 기준으로 상대 경로를 인자로 입력받는다.
        // 기존 Load()를 호출하는 대신에 매니저를 사용한다면
        // 이 곳에 중단을 걸면 모든 load가 호출될 때 마다 이 곳에 걸리게 되겠죠?
        return Resources.Load<T>(path);
    }

    // 기본 인자 문법
    // Instatiate 함수는 기본적으로 프리팹 주소를 입력 받고, parent를 입력받아 부모를 설정할 수 있다.
    public GameObject Instantiate(string path, Transform parent = null)
    {
        // 프리팹 로드
        GameObject pref = Load<GameObject>($"Prefabs/{path}");

        if (!pref)
        {
            // 프리팹 로드에 실패했다고 디버그 로그 출력
            Debug.Log($"Failed to load prefab: {path}");

            // null 반환
            return pref;
        }

        // 두 번째 인자가 null이어도 정상적으로 작동한다고 하네요.
        // 이 스크립트 바깥에서는 Obeject의 함수라는 것을 명시하지 않아도 실행되었지만,
        // 이 클래스 안에서는 instantiate()를 실행하면 ResourcesManager의 함수로 인식하기 때문에
        // Object의 함수라는 것을 명시해주어야 한다.
        return Object.Instantiate(pref, parent);
    }

    public void Destroy(GameObject go)
    {
        if (!go)
            return;

        // 게임오브젝트를 삭제
        GameObject.Destroy(go);
    }

}
