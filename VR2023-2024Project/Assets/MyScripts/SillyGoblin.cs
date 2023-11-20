using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SillyGoblin : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 eyes1;
    [SerializeField] private Transform eyes2;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null) GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool eyeContact = false;

        RaycastHit hit;
        Vector3 difference = (target.position - eyes2.position);
        Vector3 direction = difference.normalized;
        direction.Normalize();
        Debug.DrawLine(transform.position, transform.position + direction);
        if (Physics.Raycast(
            eyes2.position,
            direction,
            out hit,
            Mathf.Infinity)
            )
        {
            if (hit.collider.transform == target)
            {
                eyeContact = true;
            }
        }

        animator.SetBool("Dancing", !eyeContact);
    }
}
