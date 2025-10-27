using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float m_movementSpeed = 3.0f;
    private Rigidbody2D m_rigidbody2D;
    private Animator animator;

    public float m_patrolTime = 4.0f;
    private float m_patrolRemainingTimer;
    public bool m_patrolVertical;
    
    int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_patrolRemainingTimer = m_patrolTime;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        m_patrolRemainingTimer -= Time.deltaTime;
        if(m_patrolRemainingTimer <= 0)
        {
            direction = -direction;
            m_patrolRemainingTimer = m_patrolTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = m_rigidbody2D.position;
        if (m_patrolVertical)
        {
            position.y = position.y + m_movementSpeed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + m_movementSpeed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        m_rigidbody2D.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            player.ChangeHealth(-1);
        }
    }
}
