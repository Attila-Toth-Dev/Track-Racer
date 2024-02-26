using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public List<Rigidbody> rigidBodies = new List<Rigidbody>();

    private Animator _animator = null;

    public bool RagdollOn
    {
        get { return !_animator.enabled; }
        set
        {
            _animator.enabled = !value;
            foreach (Rigidbody r in rigidBodies)
                r.isKinematic = !value;
        }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        foreach (Rigidbody r in rigidBodies)
            r.isKinematic = true;

        gameObject.tag = "Human";
    }
}
