using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // �� ����ϸ� private�� �����Ϳ� ǥ�ý�ų �� �ִ�.
    float _speed = 10.0f;

    void Start()
    {
        
    }

    // GameObject (Player)
        // Transform
        // PlayerController (current)
    void Update()
    {
        float deltaSpeed = Time.deltaTime * _speed;

        // transform - �ش� ������Ʈ�� �ִ� Ʈ������ ������Ʈ
        // TransformDirection() - transform direction�� local ��ǥ�迡�� world ��ǥ��� ��ȯ �� ��ȯ
        // InverseTransformDirection() - transform direction�� world ��ǥ�迡�� local ��ǥ��� ��ȯ �� ��ȯ

        // transform.translate() -  local ��ǥ�� �������� ��������.


        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * deltaSpeed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * deltaSpeed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * deltaSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * deltaSpeed);
    }
}
