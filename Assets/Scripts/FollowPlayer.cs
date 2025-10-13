using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offsetZ = new Vector3(0,0,-10);

    void LateUpdate()
    {
        
        transform.position = player.transform.position + offsetZ;
    }
}
