using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �Ŵ��� ��ü ��������
        GameObject obj = GameObject.Find("@Managers");
        Managers mgr = obj.GetComponent<Managers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
