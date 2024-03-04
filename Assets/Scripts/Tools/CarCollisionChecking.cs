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
        if (_cpManager != null)
            Debug.Log(_cpManager.name);
        else
            Debug.LogWarning("CAR COLLISION: CP Manager was NULL");

        _rManager = FindObjectOfType<RaceManager>();
        if (_rManager != null)
            Debug.Log(_rManager.name);
        else
            Debug.LogWarning("CAR COLLISION: RACE Manager was NULL");
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Waypoint") && _cpManager != null)
        {
            _cpManager.savedPosition = _other.transform.position;
            _cpManager.savedRotation = _other.transform.localRotation;

            _other.gameObject.SetActive(false);
            _rManager.currentCheckpoint++;

            if(_rManager.currentCheckpoint > _rManager.checkpointAmount - 1)
            {
                for (int i = 0; i < _cpManager.waypointGameObject.Count; i++)
                    _cpManager.waypointGameObject[i].SetActive(true);
            }
        }

        if (_other.CompareTag("Reset Zone"))
        {
            Vector3 savedPos = new Vector3(_cpManager.savedPosition.x + 1f, _cpManager.savedPosition.y + 1f, _cpManager.savedPosition.z);

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
