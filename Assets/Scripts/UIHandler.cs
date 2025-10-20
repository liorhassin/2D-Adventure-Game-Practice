using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private VisualElement m_healthBar;
    public static UIHandler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_healthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthBar(1.0f);
    }

    public void SetHealthBar(float percentage)
    {
        m_healthBar.style.width = Length.Percent(percentage * 100);
    }
}
