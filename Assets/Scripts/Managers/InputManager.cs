using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 매니저 클래스가 객체를 직접 관리하고 함수를 호출할 것이기 때문에, MonoBehaviour를 상속 받지 않음.
public class InputManager
{
    // Action
    // 반환 없는 이벤트(델리게이트)
    public Action KeyAction = null; // Action 에 템플릿을 사용하지 않을 경우, void 인자를 받는다.
    public Action<Define.MouseEvent> MouseAction = null; // Action에 템플릿으로 입력할 인자를 넣어줄 수 있다.

    bool _pressed = false;

    public void OnUpdate()
    {
        // =================
        // Listener pattern
        // =================
        //  구독자(함수)가 이벤트 리스너(Action)에게 자신(delegate)를 등록시키고,
        //  어떤 조건(이벤트 발생)이 일어나면
        //  이벤트 리스너(Action)가 자신에게 등록 된 구독자들(delegate)에게 함수를 호출


        // 키 입력이 있을 경우 미리 담아놓은 delegate를 통해 함수를 호출해줄 것.

        // 키 입력과 액션 객체가 있을 경우, 등록된 델리게이트 실행
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        // 위 두 줄의 코드를 다음과 같이 간략하게 나타낼 수 있다.
        // 중단 잡을 때 살짝 불편한 단점이 있어요.
        //KeyAction?.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
                // 만약 드래그 상태를 추가하고 싶다면 
                // 여기서 Acctime을 받아서 일정 시간 이상일 경우 Drag Invoke를 준다던가.. 하면 되겠죠?
            }
            else
            {
                // 마우스 release 상태일 때 이전 프레임에 마우스를 누르고 있는 상태였다면 -> Click Invoke.
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
             
                _pressed = false;
            }
        }



    }
}
