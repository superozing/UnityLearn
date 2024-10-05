using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ������ �ε带 ����� �뵵�� �� ������ �� ���� Ȯ���ϱ� ���ؼ�
// ���� ���ҽ� ���� �ڵ带 ����
public class ResourceManager
{
    // ���ø� �Լ�.
    // where ����: ���ø��� ����� �� �ݵ�� Ư�� Ŭ���� �Ǵ� Ư�� Ŭ������ ��ӹ��� Ŭ������ ���ø��� ����� �� �ִ�.
    public T Load<T>(string path) where T : Object
    {
        // ���ҽ��� �ҷ����� ���� �ݵ�� Asset�� Resources ���� �ȿ� �־�� �ҷ��� �� �ִ�.
        // �� �ȿ� �ִ� ���� �������� ��� ��θ� ���ڷ� �Է¹޴´�.
        // ���� Load()�� ȣ���ϴ� ��ſ� �Ŵ����� ����Ѵٸ�
        // �� ���� �ߴ��� �ɸ� ��� load�� ȣ��� �� ���� �� ���� �ɸ��� �ǰ���?
        return Resources.Load<T>(path);
    }

    // �⺻ ���� ����
    // Instatiate �Լ��� �⺻������ ������ �ּҸ� �Է� �ް�, parent�� �Է¹޾� �θ� ������ �� �ִ�.
    public GameObject Instantiate(string path, Transform parent = null)
    {
        // ������ �ε�
        GameObject pref = Load<GameObject>($"Prefabs/{path}");

        if (!pref)
        {
            // ������ �ε忡 �����ߴٰ� ����� �α� ���
            Debug.Log($"Failed to load prefab: {path}");

            // null ��ȯ
            return pref;
        }

        // �� ��° ���ڰ� null�̾ ���������� �۵��Ѵٰ� �ϳ׿�.
        // �� ��ũ��Ʈ �ٱ������� Obeject�� �Լ���� ���� ������� �ʾƵ� ����Ǿ�����,
        // �� Ŭ���� �ȿ����� instantiate()�� �����ϸ� ResourcesManager�� �Լ��� �ν��ϱ� ������
        // Object�� �Լ���� ���� ������־�� �Ѵ�.
        return Object.Instantiate(pref, parent);
    }

    public void Destroy(GameObject go)
    {
        if (!go)
            return;

        // ���ӿ�����Ʈ�� ����
        GameObject.Destroy(go);
    }

}
