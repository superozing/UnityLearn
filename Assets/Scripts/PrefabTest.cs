using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    // �����Ϳ��� �־��ִ� �������� ���α׷� ���� �� ������ ��üȭ
    // GameObject - ����Ƽ ���� ��ġ�� �� �ִ� ��� ��ü�� ���� �߻� Ŭ��������.
    // �׷��� ������ �����յ� �翬�� �־��� �� �ִ�.
    public GameObject prefab;

    GameObject tank;


    void Start()
    {
        // ������ �ν��Ͻ�ȭ �Լ�. ��ȯ���� ��üȭ �� ������Ʈ�� ��ȯ�ؿ�.
        tank = Managers.Resource.Instantiate("Tank");

        // ������Ʈ ���� �Լ�. �� ��° ���ڷ� n�� �ڿ� ������ �� ������ �� �־��.
        //Managers.Resource.Destroy(tank);
        Destroy(tank, 3.0f);
    }

}
