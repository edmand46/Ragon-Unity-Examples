using Ragon.Client;
using UnityEngine;

namespace Ragon.Examples.Tanks
{
    public class Projectile : RagonBehaviour
    {
        public float destroyAfter = 2;
        public Rigidbody rigidBody;
        public float force = 1000;
        
        void Start()
        {
            rigidBody.AddForce(transform.forward * force);
        }

        void OnTriggerEnter(Collider co)
        {
            
        }
    }
}
