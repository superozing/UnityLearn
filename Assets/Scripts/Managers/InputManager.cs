using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ŵ��� Ŭ������ ��ü�� ���� �����ϰ� �Լ��� ȣ���� ���̱� ������, MonoBehaviour�� ��� ���� ����.
public class InputManager
{
    // Action
    // ��ȯ ���� �̺�Ʈ(��������Ʈ)
    public Action KeyAction = null; // Action �� ���ø��� ������� ���� ���, void ���ڸ� �޴´�.
    public Action<Define.MouseEvent> MouseAction = null; // Action�� ���ø����� �Է��� ���ڸ� �־��� �� �ִ�.

    bool _pressed = false;

    public void OnUpdate()
    {
        // =================
        // Listener pattern
        // =================
        //  ������(�Լ�)�� �̺�Ʈ ������(Action)���� �ڽ�(delegate)�� ��Ͻ�Ű��,
        //  � ����(�̺�Ʈ �߻�)�� �Ͼ��
        //  �̺�Ʈ ������(Action)�� �ڽſ��� ��� �� �����ڵ�(delegate)���� �Լ��� ȣ��


        // Ű �Է��� ���� ��� �̸� ��Ƴ��� delegate�� ���� �Լ��� ȣ������ ��.

        // Ű �Է°� �׼� ��ü�� ���� ���, ��ϵ� ��������Ʈ ����
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        // �� �� ���� �ڵ带 ������ ���� �����ϰ� ��Ÿ�� �� �ִ�.
        // �ߴ� ���� �� ��¦ ������ ������ �־��.
        //KeyAction?.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
                // ���� �巡�� ���¸� �߰��ϰ� �ʹٸ� 
                // ���⼭ Acctime�� �޾Ƽ� ���� �ð� �̻��� ��� Drag Invoke�� �شٴ���.. �ϸ� �ǰ���?
            }
            else
            {
                // ���콺 release ������ �� ���� �����ӿ� ���콺�� ������ �ִ� ���¿��ٸ� -> Click Invoke.
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
             
                _pressed = false;
            }
        }



    }
}
