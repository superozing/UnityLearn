using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // �� ����ϸ� private�� �����Ϳ� ǥ�ý�ų �� �ִ�.
    float _speed = 10.0f;

    float _yAngle = 0.0f;

    void Start()
    {
        
    }

    // GameObject (Player)
    // Transform
    // PlayerController (current)
    void Update()
    {

        float deltaSpeed = Time.deltaTime * _speed;

        // =======================
        //  Transform, translate
        // =======================
        // transform - �ش� ������Ʈ�� �ִ� Ʈ������ ������Ʈ
        // TransformDirection() - transform direction�� local ��ǥ�迡�� world ��ǥ��� ��ȯ �� ��ȯ
        // InverseTransformDirection() - transform direction�� world ��ǥ�迡�� local ��ǥ��� ��ȯ �� ��ȯ
        // transform.translate() -  local ��ǥ�� �������� ��������.

        // =======================
        //  Vector3
        // =======================
        // Vector3 vec3 = new Vector3();
        // float len = vec3.magnitude; // ������ ũ�⸦ ��ȯ
        // Vector3 dir = vec3.normalized; // ����ȭ�� ���͸� ��ȯ


        // ======================== 
        //  Rotation
        // ======================== 
        // transform.rotation; ���ʹϾ��� ����� �����̼�(�����)
        // transform.eulerAngles; // ���Ϸ� ������ ����� ȸ��

        _yAngle += deltaSpeed * 100;

        // ���Ϸ� �ޱ��� �Ź� ���� �������־�� �Ѵٰ� ����Ƽ ���� ������ �����ִ�.
        // eulerAngles�� ���� ���� �����ϸ� �ȵȴ�. 360���� �Ѿ ��� ������ ����ٰ� �ؿ�.

        // ���밪 �������� ȸ�� ����
        // transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // Rotate() - ���� ���� ���ڷ� ���� �� ��ŭ �����ش�.
        // transform.Rotate(new Vector3(0.0f, deltaSpeed, 0.0f));


        // ���Ϸ� �ޱ� ��� ���ʹϾ�(�����)�� ����ϴ� ����: ������
        // ȸ���ϴ� �� ���� ��ĥ ��� ���� ������� �Ҿ������ ����.

        // ���ʹϾ��� ����ؼ� ��Ȯ�� ȸ���� ������ �� �ְ�, ������ �ذ� ����.
        // var quat = transform.rotation;

        // euler angle -> quaternion���� ��ȯ�ϴ� �Լ�
        // transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));


        if (Input.GetKey(KeyCode.W))
        {
            // LookRotation() - �ٶ󺸴� ����(�Ƹ� ���� ������ ���� ����) �����ϴ� �Լ�
            // transform.rotation = Quaternion.LookRotation(Vector3.forward); // Vector3.forward�� ���� ���� ��ǥ�̴�.
            // ������ ���� ���� �Լ��� ������ �ʹ� ���� ���߾� �����̴� ������ ����.
            // ���� ���� �Լ��� ����ؼ� �ε巯�� ������ ���� �� �ִ�.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);

            // �÷��̾� ���� ���Ͱ� ���������� �޶����� �ֱ� ������ ���� ���Ϳ� �����ִ� ���� ȸ������ �� �������θ� ���� ���� �ƴ�, �ٸ� �������� �̵��ϰ� �ȴ�.
            // transform.Translate(Vector3.forward * deltaSpeed);

            // translate�� ����ؼ� �����̴� ���� �ƴ�, forward���Ϳ� speed�����ϰ� position += ������ ���ִ� ���� �ڿ�������.
            transform.position += Vector3.forward * deltaSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            // transform.Translate(Vector3.forward * deltaSpeed);
            transform.position += Vector3.back * deltaSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            // transform.Translate(Vector3.forward * deltaSpeed);
            transform.position += Vector3.left * deltaSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            //transform.Translate(Vector3.forward * deltaSpeed);
            transform.position += Vector3.right * deltaSpeed;
        }
    }
}
