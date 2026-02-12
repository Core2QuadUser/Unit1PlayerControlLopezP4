using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // why do you need a "new" declaration?

    private Vector3 offset = new Vector3(0, 5, -7);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the palyer by adding to the player's position
        transform.position = player.transform.position + offset;
    }
}
