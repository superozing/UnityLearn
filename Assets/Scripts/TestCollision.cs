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
        #region
        /*
        // Raycast Ȱ��: spring arm ���� �ִ�.

        // Owner Transform forward Vector ���ϱ�
        // 1. �׳� ���� �����ϰ� transform.forward�� ����ϸ� �ȴ�.
        // 2. ���ǿ��� ���� �Լ��� TransformDirection()�� ����ؼ�
        //  ���� ��ǥ�� ���� ������ Vector3.forward�� Vector3.right��
        //  �÷��̾��� transform�� ������ world ���� ���ͷ� �ٲ��ش�.

        // �� �Լ��� �̿��ؼ� ���� ���Ϳ� transform�� �����ؼ� ����� �̵������־��.
        // var�� ����ϸ� auto�� ���� R-value�� Ÿ���� �����ͼ� Ÿ���� �ڵ����� �߷������.
        // ���� ������� �ʴ� ���� ��õ�Ѵٰ� �ؿ�.
        var lookDirection = transform.TransformDirection(Vector3.forward);

        // ���̸� �׸��� �Լ�
        Debug.DrawRay(transform.position + Vector3.up, lookDirection * 10, Color.red);

        // Raycast - ���̸� ��� �Լ�.
        // ��ȯ���� Ray�� hit ���� ���θ� bool�� ��ȯ�Ѵ�.
        // RaycastHit ����ü�� ���ؼ� �ڼ��� �浹 ������ ������ �� �ִ�.
        
        // ����ĳ��Ʈ ���� �ڵ�
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, lookDirection, out hit, 10))
            Debug.Log($"RayCast {hit.collider.gameObject.name}");
        

        // RaycastAll - ���̸� ���, ���̿� �浹�� ������������� ��ü�� RaycastHit �迭�� ��ȯ�ϴ� �Լ�.
        // �̰� out�� �ƴϰ� return���� �޾ƿ��°ų׿�. ���� ���ϼ� ���� ���̳׿�.
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, lookDirection, 10);

        // RaycastAll ����� foreach������ ����� �� �־��.
        // C#������ �迭�� �ڷᱸ�� �� �ϳ��ϱ� �ڷᱸ�� ��ȸ�� �� �� �־��.
        foreach (RaycastHit hitItem in hits)
        {
            Debug.Log($"RayCast {hitItem.collider.gameObject.name}");
        }
        */

        //===============
        // ������ ����
        //===============

        // ���� <-> ���� <-> ��ũ��
        // ���� ��ǥ��� ������Ʈ ����, Ư�� ��ü�� �������� �Ѵ�.
        // ���� ��ǥ��� ��� ������Ʈ�� �����ϴ� �ϳ��� ��ǥ���̴�.

        // Debug.Log(Input.mousePosition); // Screen
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport, "����"

        // ����Ƽ�� ����ü �ø��� ��Ŭ���� �ø��� ���� ����ȭ �Ѵ�.
        // Camera near(���� ����� ��), far(���� �� ��) ���� ����

        // ���� �󿡼� ����Ʈ�� ������ �� ��, ���� ȭ�麸�� ��¦ �ڿ� �ִ� �ü����� ���� ������ ��Ų��.
        // rasterizer�� vertex�� ���� �׸� �ȼ��� ����ؿ�.

        // ���뿡�� �ٽ� ���÷����� ������ ����������
        // IA VS HS TS DS GS RS PS OM
        // IA - VB IB set
        // VS - ���� ��������
        // HS - ���� ���� ���� ����
        // TS - �׼����̼�(���� ������ ���� �����ϱ�)
        // DS - TS���� ������ ���� ���� �ٽ� ����
        // GS - ���� ����, �߰�, ������ ���
        // RS - ���� ������ ������� ȭ�鿡 �׷��� �ȼ� ���ϱ�, ���� ���� ����
        // PS - �Էµ� ���͸���� ������ ���� ����, �ؽ��ĸ� ������� �ȼ� ���� ����
        // OM - ���� ���ۿ� ���, ���� ������ ���� �ش� �ȼ��� �׸� �� �� �� ����

        #endregion

        //===============
        // Raycasting #2
        //===============

        // ���ڷ� 0 -> �� �� ���콺
        if (Input.GetMouseButtonDown(0))
        {
            // ����Ʈ �󿡼� Ŭ���� �ϸ� cam pos���� Ŭ���� dir�� ray�� �߻��Ѵ�.
            // �� �� �浹�� ������Ʈ�� �ν����Ϳ� ������.


            // ��ũ�� ��ǥ�� ���� ���� ��ǥ�� ��ȯ�ؿ�.
            // z�� 0�� ������ ī�޶��� ��ǥ�� ��ȯ�ؿ�.
            // ������ �����غ��Ҵ�. ���� ���͸� ���� �� ��ġ�� ������ vec3(0,0,0)�� ���ͼ� �׷� �� ���ƿ�.
            // near ���� �־ �����Ǵ� �κ��� ��Ȯ�� ���� ���� ��ǥ�� �� �� �־��.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 CamPos = Camera.main.transform.position;

            // ray �ð�ȭ
            Debug.DrawRay(CamPos, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;

            // | -> or ��Ʈ������. �� ��Ʈ�� �ϳ��� 1�̸� 1
            LayerMask layerMask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            // int Mask = (1 << 6) | (1 << 7); // �� �ڵ�� ���� ������ ����

            // �浹��ų ���̾� ��Ʈ ���
            if (Physics.Raycast(ray, out hit, 100.0f, layerMask)) // ray max duration ����
            {
                Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
            }
        }

    }
}
