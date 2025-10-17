using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float currentHealth = 0.5f;
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement healthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        healthBar.style.width = Length.Percent(currentHealth * 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
