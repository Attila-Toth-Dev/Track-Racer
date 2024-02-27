using UnityEngine;

public class CarCollisionChecking : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private new GameObject collider;

    private CheckpointManager _cpManager;
    private RaceManager _rManager;

    private void Awake()
    {
        _cpManager = FindObjectOfType<CheckpointManager>();
        _rManager = FindObjectOfType<RaceManager>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Waypoint") && _cpManager != null)
        {
            _cpManager.savedPosition = _other.transform.position;
            _cpManager.savedRotation = _other.transform.localRotation;

            _rManager.currentCheckpoint++;
        }

        if (_other.CompareTag("Reset Zone"))
        {
            Vector3 savedPos = new Vector3(_cpManager.savedPosition.x, _cpManager.savedPosition.y + 1f, _cpManager.savedPosition.z);

            car.transform.position = savedPos;
            collider.transform.position = savedPos;

            car.transform.rotation = _cpManager.savedRotation;
            collider.transform.rotation = _cpManager.savedRotation;
        }

        HumanController hc = _other.gameObject.GetComponent<HumanController>();
        if (hc != null)
        {
            CapsuleCollider cc = hc.gameObject.GetComponent<CapsuleCollider>();

            cc.enabled = false;
            hc.RagdollOn = true;
        }
    }
}
