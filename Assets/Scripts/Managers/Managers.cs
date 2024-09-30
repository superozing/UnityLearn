using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장된다.
    // 외부에서 객체를 참조하길 원하지 않기 때문에 접근 지정자를 수정했다.
    static Managers Instance { get { Init(); return s_instance; } }

    InputManager _input = new InputManager();
    // 프로퍼티를 사용해서 깔끔하게 불러올 수 있도록.
    // 유일한 객체인 s_instance의 멤버 _input을 반환한다.
    public static InputManager Input { get { return Instance._input; } }

    void Start()
    {
        // 매니저 객체 가져오기
        Init();

    }

    void Update()
    {
        // 매 틱마다 키 매니저의 Update()를 호출시킴.
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject obj = GameObject.Find("@Managers");

            if (!obj)
            {
                obj = new GameObject { name = "@Managers" };
                obj.AddComponent<Managers>();
            }

            // 웬만해서는 삭제되지 않도록 함.
            DontDestroyOnLoad(obj);

            s_instance = obj.GetComponent<Managers>();
        }

    }
}
