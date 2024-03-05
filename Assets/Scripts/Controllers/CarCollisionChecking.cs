using Managers.Checkpoint_System;

using UnityEngine;

namespace Controllers
{
    public class CarCollisionChecking : MonoBehaviour
    {
        private CheckpointManager checkpointManager;

        private void Awake()
        {
            checkpointManager = FindObjectOfType<CheckpointManager>();
            if(checkpointManager == null)
                Debug.LogWarning("CAR COLLISION CHECKING: Track Manager is NULL");
        }

        private void OnTriggerEnter(Collider _other)
        {
            HumanController hc = _other.gameObject.GetComponent<HumanController>();
            if (hc != null && hc.isHittable)
            {
                CapsuleCollider cc = hc.gameObject.GetComponent<CapsuleCollider>();

                cc.enabled = false;
                hc.RagdollOn = true;
            }
        }
    }
}