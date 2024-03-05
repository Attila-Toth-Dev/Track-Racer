using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class HumanController : MonoBehaviour
    {
        public List<Rigidbody> rigidBodies;

        private Animator animator;

        public bool RagdollOn
        {
            get => !animator.enabled;
            set
            {
                animator.enabled = !value;
                foreach (Rigidbody r in rigidBodies)
                    r.isKinematic = !value;
            }
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
            foreach (Rigidbody r in rigidBodies)
                r.isKinematic = true;

            gameObject.tag = "Human";
        }
    }
}