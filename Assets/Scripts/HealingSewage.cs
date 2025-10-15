using UnityEngine;

public class HealingSewage : MonoBehaviour
{
    private PlayerController controller;

    public int healingAmount = 1;
    private float healingCooldownTimer = 2.0f;
    private bool wasHealedRecently;
    private float healingCooldown = 0f;

    void Update()
    {
        if (wasHealedRecently)
        {
            healingCooldown -= Time.deltaTime;
            if(healingCooldown <= 0)
            {
                wasHealedRecently = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (controller && !wasHealedRecently)
        {
            controller.ChangeHealth(healingAmount);
            wasHealedRecently = true;
            healingCooldown = healingCooldownTimer;
        }
    }
}
