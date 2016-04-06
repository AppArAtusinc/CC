using Entites;
using Entites.Common;
using StudentSimulator.SaveSystem;
using UnityEngine;

[Entity]
public class NPC : Actor {

    [Save]
    public string CurrentAnimation;

    protected NPC() : base()
    {

    }

    protected NPC(GameObject obj) : base(obj)
    {
        
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
