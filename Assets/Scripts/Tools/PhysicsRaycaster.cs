using UnityEngine;

public class PhysicsRaycaster : MonoBehaviour
{
    public float force = 100f;
    public int layerMask;

    //public Text output;
    public string layerString = "";

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        string[] layers = { layerString };
        layerMask = LayerMask.GetMask(layers);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                //output.text = hit.transform.gameObject.name;

                Rigidbody body = hit.collider.GetComponent<Rigidbody>();

                if (body)
                    body.AddForce(ray.direction * force);
            }
        }
    }
}
