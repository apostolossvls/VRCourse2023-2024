using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillyGoblin : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null) GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool eyeContact = false;
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        if (Physics.Raycast(transform.position + Vector3.up, direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.transform == target)
            {
                eyeContact = true;
            }
        }

        animator.SetBool("Dancing", !eyeContact);
    }
}
