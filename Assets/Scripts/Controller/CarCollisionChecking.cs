using UnityEngine;

public class CarCollisionChecking : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private new GameObject collider;

    private TrackManager _cpManager;

    private void Awake()
    {
        
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
