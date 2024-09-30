using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 매니저 클래스가 객체를 직접 관리하고 함수를 호출할 것이기 때문에, MonoBehaviour를 상속 받지 않음.
public class InputManager
{
    // Action
    // 반환 없는 이벤트(델리게이트)
    public Action KeyAction = null;

    public void OnUpdate()
    {
        // =================
        // Listener pattern
        // =================
        //  구독자(함수)가 이벤트 리스너(Action)에게 자신(delegate)를 등록시키고,
        //  어떤 조건(이벤트 발생)이 일어나면
        //  이벤트 리스너(Action)가 자신에게 등록 된 구독자들(delegate)에게 함수를 호출


        // 키 입력이 있을 경우 미리 담아놓은 delegate를 통해 함수를 호출해줄 것.

        // 만약 키 입력이 없을 경우, return
        if (!Input.anyKey)
            return;

        // 액션 객체가 있을 경우, 등록된 델리게이트 실행
        if (KeyAction != null)
            KeyAction.Invoke();



    }
}
