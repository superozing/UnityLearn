using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Collision(�浹) ó���� �ʿ��� ����
    //  1. IsKinematic�� false�� "Rigidbody" component�� �־�� �Ѵ�.
    //  2. IsTrigger�� false�� "Collider" component�� �־�� �Ѵ�.

    //  3. �浹�� ��� ������Ʈ���Ե� 1���� 2���� ����Ǿ�� �Ѵ�.

    private void OnCollisionEnter(Collision collision)
    {
        // �浹 �߻� �� �α� ���
        // �浹�� �߻��ϸ� �� �Լ��� �����µ�... ���� ������ ������ �ɱ��?
        Debug.Log("On Collision");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���� �߻� �� �α� ���
        // Ʈ���Ű� �߻��ϸ� �� �Լ��� �����µ�... ���� ������ ������ �ɱ��?
        Debug.Log("On Trigger");

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
