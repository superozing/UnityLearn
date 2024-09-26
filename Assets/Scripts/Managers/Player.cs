using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 매니저 객체 가져오기
        GameObject obj = GameObject.Find("@Managers");
        Managers mgr = obj.GetComponent<Managers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
