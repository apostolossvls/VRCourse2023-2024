using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterEventTag : MonoBehaviour
{
    public List<string> tags = new List<string> { "Player" };
    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            onTrigger.Invoke();
        }
    }
}
