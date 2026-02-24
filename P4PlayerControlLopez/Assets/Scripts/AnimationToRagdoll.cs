using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToRagdoll : MonoBehaviour
{

    private Animator anim;

    [SerializeField] Collider myCollider;
    Rigidbody[] rigidbodies;
    bool bIsRagdoll = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        ToggleRagdoll(true);
    }

    void Start()
    {
    }

    private void ToggleRagdoll(bool bisAnimating)
    {
       bIsRagdoll = !bisAnimating;
        
        myCollider.enabled = bisAnimating;
        foreach (Rigidbody ragdollBone in rigidbodies)
        {
            ragdollBone.isKinematic = bisAnimating;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        anim.enabled = false;
        if (!bIsRagdoll && collision.gameObject.name == "Vehicle")
        {
            ToggleRagdoll(false);         

        }            
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
