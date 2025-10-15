using UnityEngine;

public class DamageZoneStatic : MonoBehaviour
{

    public int damage = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller)
        {
            controller.ChangeHealth(-damage);
        }
    }
}
