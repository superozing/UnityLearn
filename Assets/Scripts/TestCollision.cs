using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Collision(�浹) ó���� �ʿ��� ����
    //  1. �� Ȥ�� ��뿡�� IsKinematic�� false�� "Rigidbody" component�� �־�� �Ѵ�.
    //  2. ���� ��뿡�� IsTrigger�� false�� "Collider" component�� �־�� �Ѵ�.

    // �浹 ��, physics material�� ����ؼ� �������� ������ ������ �� �ִ�. (����, ź�� ��)
    private void OnCollisionEnter(Collision collision)
    {
        // �浹 �߻� �� �α� ���
        // �浹�� �߻��ϸ� �� �Լ��� �����µ�... ���� ������ ������ �ɱ��?
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    // Trigger�� Collision�� ������
    // �浹 ó������ �ſ� ū ���� ����� ����.
    // Ʈ���Ŵ� �ڽ��� �浹ü �ȿ� ��ü�� �ִ��� Ȯ�θ� �ϱ⿡ ������ ����.

    // Trigger ó���� �ʿ��� ����
    // �� ������Ʈ ��� collider�� ������ �ؿ�.
    // �� ������Ʈ �� �ϳ� �̻��� ������Ʈ�� Rigidbody component�� �����ϰ�, IsTrigger�� true���� �ؿ�.

    // ��� ��) ��ų ���� ����, ���� ���� ��輱 ��
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
