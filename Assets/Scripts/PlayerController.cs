using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float m_movementSpeed = 3.0f;
    private InputActions m_inputActions;
    private Vector2 m_move;
    
    public int m_maxHealth = 5;
    public int m_health { get { return m_currentHealth; } }
    private int m_currentHealth;

    public float m_timeInvincible = 1f;
    bool m_isInvincible;
    float m_damageCooldown;

    private void Awake()
    {
        m_inputActions = new InputActions();
    }

    void OnEnable()
    {
        m_inputActions.Enable();
    }

    void OnDisable()
    {
        m_inputActions.Disable();
    }
    
    void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    void Update()
    {
        m_move = m_inputActions.PlayerMove.Move.ReadValue<Vector2>();

        if (m_isInvincible)
        {
            m_damageCooldown -= Time.deltaTime;
            if (m_damageCooldown <= 0){
                m_isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)transform.position + m_move * m_movementSpeed * Time.deltaTime;
        transform.position = position;
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if (m_isInvincible) return;
            m_isInvincible = true;
            m_damageCooldown = m_timeInvincible;
        }
        m_currentHealth = Mathf.Clamp(m_currentHealth + amount, 0, m_maxHealth);
        UIHandler.instance.SetHealthBar(m_currentHealth / (float)m_maxHealth);
    }
}
