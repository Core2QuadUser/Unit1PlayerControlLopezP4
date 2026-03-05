using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputID;

    //Private Variables
    public float speed = 20.0f;

    private float turnSpeed = 45.0f;

    public float horizontalInput;

    private float forwardInput;

    //Cam switching variables
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;


    //For other aspect
    //Rigidbody body;
    //AudioSource hit_effect;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //collider = GetComponent<BoxCollider>();
        //body = GetComponent<Rigidbody>();
        //hit_effect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Input Config
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // This Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // This Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if(Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }

        
    }

	void OnCollisionEnter(Collision col)
	{
		//Debug.Log ("Collision!");
        float direc;

        //if (col.gameObject.name == "Kris")
       // {
       //hit_effect.Play();  


       // }

        /// this determines the direction to fling kris in
        Rigidbody colbody = col.gameObject.GetComponent<Rigidbody>();
        if ((horizontalInput > 0) | (horizontalInput < 0))
        {
            direc = horizontalInput;
        }

            /// this chooses a random direction if the car is only moving STRAIGHT forward
        else
        {
            int choice = Random.Range(-1,1);
            direc = choice;
            if (choice == 0)
            {
                choice = 1;
                direc = choice;
            }
        }

        /// this flings kris
        colbody.AddForce (700 * direc, 700, 700);
        col.gameObject.transform.Rotate(360f, 360f, 360f, Space.Self);


    }
}
