using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // ���ϼ��� ����ȴ�.
    // �ܺο��� ��ü�� �����ϱ� ������ �ʱ� ������ ���� �����ڸ� �����ߴ�.
    static Managers Instance { get { Init(); return s_instance; } }

    InputManager _input = new InputManager();
    // ������Ƽ�� ����ؼ� ����ϰ� �ҷ��� �� �ֵ���.
    // ������ ��ü�� s_instance�� ��� _input�� ��ȯ�Ѵ�.
    public static InputManager Input { get { return Instance._input; } }

    void Start()
    {
        // �Ŵ��� ��ü ��������
        Init();

    }

    void Update()
    {
        // �� ƽ���� Ű �Ŵ����� Update()�� ȣ���Ŵ.
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

            // �����ؼ��� �������� �ʵ��� ��.
            DontDestroyOnLoad(obj);

            s_instance = obj.GetComponent<Managers>();
        }

    }
}
