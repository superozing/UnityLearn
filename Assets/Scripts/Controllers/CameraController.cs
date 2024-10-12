using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]// [SerializeField]를 붙이면, public 상태가 아니어도 에디터에 해당 멤버를 표시할 수 있다.
    public Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    public Vector3 _delta = new(0, 6, -5); // 플레이어 기준으로 카메라가 얼마나 떨어져 있는가?

    [SerializeField]
    public GameObject _player = null;

    void Start()
    {
        
    }

    void Update()
    {
        // 왜 Update()에 플레이어 위치를 받아와서 카메라의 위치를 세팅하면 덜덜 떨리는 현상이 일어나는가?
        // 왜냐하면 Update() 함수의 호출 순서가 보장되지 않기 때문이다.
    }

    // 모든 Update 함수가 끝난 이후에 호출되는 함수 
    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f; // 벽보다 살짝 앞의 위치를 잡기 위해 0.8 곱함.
                transform.position = _player.transform.position + _delta.normalized;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform); // 시선 벡터를 player pos로 바라보게 해요. 
                // LookAt()의 내부 구현은 엄청 간단할 수 있다. pos 끼리 빼주기만 하면 될 것 같은 느낌이 든다.
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
