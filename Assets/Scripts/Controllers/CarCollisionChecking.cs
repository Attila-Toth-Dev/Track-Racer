using Controllers;

using Managers.Checkpoint_System;

using UnityEngine;

namespace Controllers
{
    public class CarCollisionChecking : MonoBehaviour
    {
        private TrackManager trackManager;

        private void Awake()
        {
            trackManager = FindObjectOfType<TrackManager>();
            if(trackManager == null)
                Debug.LogWarning("CAR COLLISION CHECKING: Track Manager is NULL");
        }

        private void OnTriggerEnter(Collider _other)
        {
            HumanController hc = _other.gameObject.GetComponent<HumanController>();
            if (hc != null)
            {
                CapsuleCollider cc = hc.gameObject.GetComponent<CapsuleCollider>();

                cc.enabled = false;
                hc.RagdollOn = true;
            }
        }
    }
}