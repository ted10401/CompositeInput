using UnityEngine;

public class Demo_CompositeInput : MonoBehaviour
{
    [SerializeField] private CompositeInput m_compositeInput;

    private void Awake()
    {
        m_compositeInput.OnKeyDown(OnKeyDown);
        m_compositeInput.OnKey(OnKey);
        m_compositeInput.OnKeyUp(OnKeyUp);
    }

    private void OnKeyDown()
    {
        Debug.Log("OnKeyDown");
    }

    private void OnKey()
    {
        Debug.Log("OnKey");
    }

    private void OnKeyUp()
    {
        Debug.Log("OnKeyUp");
    }

    private void Update()
    {
        m_compositeInput.Update(Time.deltaTime);
    }
}
