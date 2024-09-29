using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장된다.
    public static Managers Instance { get { Init(); return s_instance; } }


    // Start is called before the first frame update
    void Start()
    {
        // 매니저 객체 가져오기
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        
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
