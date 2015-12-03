using UnityEngine;
using System.Collections;
using Quest.Common;

public class QuestCollider : MonoBehaviour
{

    SphereCollider sphereCollider;

    public float Radius
    {
        get
        {
            return sphereCollider.radius;
        }
        set
        {
            if(sphereCollider == null)
                sphereCollider = GetComponent<SphereCollider>();

            sphereCollider.radius = value;
        }
    }

    public delegate void ActiveDelegate(GameObject sender, GameObject activator);
    public event ActiveDelegate OnActive;

    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        OnActive(this.gameObject, other.gameObject);
    }
}
