using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthIncrease = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller && controller.m_health < controller.m_maxHealth)
        {
            controller.ChangeHealth(healthIncrease);
            Destroy(gameObject);
        }
    }
}
