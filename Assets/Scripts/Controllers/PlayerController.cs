using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // �� ����ϸ� private�� �����Ϳ� ǥ�ý�ų �� �ִ�.
    float _speed = 10.0f;

    bool _isMoveToDest = false;
    Vector3 _destPos = Vector3.zero;

    void Start()
    {
        // ���� �� �̺�Ʈ�� ������� �ʵ��� �̹� ��ϵ� �̺�Ʈ�� ���� ��� ���� ó���� ���ִ� ��.
        // �ٵ� ���ʿ� �̷� �ڵ�� �������⸦ �ϴ� �� ���ٴ� �������� ������ ã�Ƽ� �����ϴ� ���� ���� ������?
        Managers.Input.KeyAction -= OnKeyboard; 

        // �Է� �Ŵ��� �̺�Ʈ�� ��������Ʈ�� ��Ͻ�Ŵ.
        Managers.Input.KeyAction += OnKeyboard;


        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    // GameObject (Player)
    // Transform
    // PlayerController (current)
    void Update()
    {
        #region �ּ�
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
        #endregion

        Animator anim = GetComponent<Animator>();

        if (_isMoveToDest)
        {
            anim.Play("RUN");

            Vector3 unnormDir = _destPos - transform.position;

            // float ���� ������ �����ؼ� ���� �ѹ� ���
            if (unnormDir.magnitude < 0.0001f) 
            {
                _isMoveToDest = false;
                return;
            }

            // �� ū ������ �̵����� �ʵ��� clamp
            float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, unnormDir.magnitude);

            transform.position += unnormDir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(unnormDir), 20 * Time.deltaTime);
        }
        else
        {
            anim.Play("WAIT");
        }


    }

    // ���� Ű �Է��� ���� ��쿡�� �ش� �Լ��� ������ �����ϱ� ���ؼ� �Է� �Ŵ��� �̺�Ʈ�� ��������Ʈ�� ��Ͻ�Ŵ.
    void OnKeyboard()
    {
        float deltaSpeed = Time.deltaTime * _speed;

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

        _isMoveToDest = false;
    }

    void OnMouseClicked(Define.MouseEvent e)
    {
        //if (e != Define.MouseEvent.Click)
        //    return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {

            _isMoveToDest = true;
            _destPos = hit.point;



            //Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
