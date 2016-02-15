using UnityEngine;
using System.Collections;
using System.Linq;
using Entites;

public class DealDamage : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Game.GetInstance().EntityCollection.Actors.ForEach(o =>
        {
            var player = o as Player;
            if (player != null)
            {
                player.Health.Value -= 0.05f;
            }
        });
    }
}
