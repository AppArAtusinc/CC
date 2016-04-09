using UnityEngine;
using System.Collections;

public class WalkAnimationController : MonoBehaviour {


    public float Speed;

    Animator animator;
    private NavMeshAgent navAgent;

    // Use this for initialization
    void Start () {
        this.animator = this.GetComponent<Animator>();
        this.navAgent = this.GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        float velosity = navAgent.velocity.magnitude;
        animator.SetFloat("Speed", velosity);
        Speed = velosity;
    }
}
