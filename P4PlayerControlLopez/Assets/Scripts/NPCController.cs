using UnityEngine;

public class NPCController : MonoBehaviour
{

    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // We'll move the vehicle forward.
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //why only right?
    }

}
