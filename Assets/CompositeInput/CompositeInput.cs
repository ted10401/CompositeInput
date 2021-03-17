using System;
using UnityEngine;

[Serializable]
public class CompositeInput
{
    public float validDuration = 0.1f;
    public KeyCode[] keyCodes;

    private Action m_onKeyDown;
    private Action m_onKey;
    private Action m_onKeyUp;

    private float m_keyDownDuration;
    private int m_keyDownCount;
    private bool m_key;
    private float m_keyUpDuration;

    public void OnKeyDown(Action onKeyDown)
    {
        m_onKeyDown = onKeyDown;
    }

    public void OnKey(Action onKey)
    {
        m_onKey = onKey;
    }

    public void OnKeyUp(Action onKeyUp)
    {
        m_onKeyUp = onKeyUp;
    }

    public void Update(float deltaTime)
    {
        m_keyDownDuration -= deltaTime;
        m_keyUpDuration -= deltaTime;

        m_key = true;

        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                if (m_keyDownCount == 0)
                {
                    m_keyDownDuration = validDuration;
                }

                m_keyDownCount++;

                if (m_keyDownCount == keyCodes.Length && m_keyDownDuration > 0)
                {
                    m_onKeyDown?.Invoke();
                }
            }

            if (!Input.GetKey(keyCodes[i]))
            {
                m_key = false;
            }

            if (Input.GetKeyUp(keyCodes[i]))
            {
                if (m_keyDownCount == keyCodes.Length)
                {
                    m_keyUpDuration = validDuration;
                }

                m_keyDownCount--;

                if (m_keyDownCount == 0 && m_keyUpDuration > 0)
                {
                    m_onKeyUp?.Invoke();
                }
            }
        }

        if(m_key)
        {
            m_onKey?.Invoke();
        }
    }
}