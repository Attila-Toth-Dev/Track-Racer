using UnityEngine;

public class CarCollisionChecking : MonoBehaviour
{
    private CarController car;

    private CheckpointManager cpManager;
    private RaceManager rManager;

    private void Awake()
    {
        car = FindObjectOfType<CarController>();

        cpManager = FindObjectOfType<CheckpointManager>();
        rManager = FindObjectOfType<RaceManager>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Waypoint") && cpManager != null)
        {
            Debug.Log("HIT");

            cpManager.savedPlayerTransform.savedPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
            cpManager.savedPlayerTransform.savedRotation = transform.localRotation;
        }

        if (_other.CompareTag("Reset Zone"))
        {
            Debug.Log("Hit");

            car.transform.position = new Vector3(cpManager.savedPlayerTransform.savedPosition.x, cpManager.savedPlayerTransform.savedPosition.y + 5f, cpManager.savedPlayerTransform.savedPosition.z);
            car.transform.localRotation = cpManager.savedPlayerTransform.savedRotation;
        }

        HumanController hc = _other.gameObject.GetComponent<HumanController>();
        if(hc != null)
        {
            CapsuleCollider cc = hc.gameObject.GetComponent<CapsuleCollider>();

            cc.enabled = false;
            hc.RagdollOn = true;
        }
    }
}
