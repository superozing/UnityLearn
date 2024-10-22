using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // �� ����ϸ� private�� �����Ϳ� ǥ�ý�ų �� �ִ�.
    float _speed = 10.0f;

    Vector3 _destPos = Vector3.zero;
    PlayerState _state = PlayerState.Idle;

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }


    void Start()
    {
        // �Է� �Ŵ��� �̺�Ʈ�� ��������Ʈ�� ��Ͻ�Ŵ.
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

#region States
    void UpdateDie()
    {
    }

    void UpdateMoving()
    {
        Vector3 unnormDir = _destPos - transform.position;

        // float ���� ������ �����ؼ� ���� �ѹ� ���
        // ���� destPos�� �������� ���, Idle state�� ����
        if (unnormDir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle; 
        }
        else
        {
            // �� ū ������ �̵����� �ʵ��� clamp
            float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, unnormDir.magnitude);
            transform.position += unnormDir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(unnormDir), 20 * Time.deltaTime);
        }

        // anim set

        Animator anim = GetComponent<Animator>();
    }

    void UpdateIdle()
    {
        // anim set

        Animator anim = GetComponent<Animator>();
    }

#endregion


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

        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

    }

    void OnMouseClicked(Define.MouseEvent e)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;  // state�� moving���� ����
        }
    }
}
