using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]// [SerializeField]�� ���̸�, public ���°� �ƴϾ �����Ϳ� �ش� ����� ǥ���� �� �ִ�.
    public Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    public Vector3 _delta = new(0, 6, -5); // �÷��̾� �������� ī�޶� �󸶳� ������ �ִ°�?

    [SerializeField]
    public GameObject _player = null;

    void Start()
    {
        
    }

    void Update()
    {
        // �� Update()�� �÷��̾� ��ġ�� �޾ƿͼ� ī�޶��� ��ġ�� �����ϸ� ���� ������ ������ �Ͼ�°�?
        // �ֳ��ϸ� Update() �Լ��� ȣ�� ������ ������� �ʱ� �����̴�.
    }

    // ��� Update �Լ��� ���� ���Ŀ� ȣ��Ǵ� �Լ� 
    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f; // ������ ��¦ ���� ��ġ�� ��� ���� 0.8 ����.
                transform.position = _player.transform.position + _delta.normalized;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform); // �ü� ���͸� player pos�� �ٶ󺸰� �ؿ�. 
                // LookAt()�� ���� ������ ��û ������ �� �ִ�. pos ���� ���ֱ⸸ �ϸ� �� �� ���� ������ ���.
            }

        }
    }


    //=======================

    public void SetQuaterView(Vector3 delta)
    {
        _delta = delta;
        _mode = Define.CameraMode.QuaterView;
    }
}
