using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ŵ��� Ŭ������ ��ü�� ���� �����ϰ� �Լ��� ȣ���� ���̱� ������, MonoBehaviour�� ��� ���� ����.
public class InputManager
{
    // Action
    // ��ȯ ���� �̺�Ʈ(��������Ʈ)
    public Action KeyAction = null;

    public void OnUpdate()
    {
        // =================
        // Listener pattern
        // =================
        //  ������(�Լ�)�� �̺�Ʈ ������(Action)���� �ڽ�(delegate)�� ��Ͻ�Ű��,
        //  � ����(�̺�Ʈ �߻�)�� �Ͼ��
        //  �̺�Ʈ ������(Action)�� �ڽſ��� ��� �� �����ڵ�(delegate)���� �Լ��� ȣ��


        // Ű �Է��� ���� ��� �̸� ��Ƴ��� delegate�� ���� �Լ��� ȣ������ ��.

        // ���� Ű �Է��� ���� ���, return
        if (!Input.anyKey)
            return;

        // �׼� ��ü�� ���� ���, ��ϵ� ��������Ʈ ����
        if (KeyAction != null)
            KeyAction.Invoke();



    }
}
