using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateAround : MonoBehaviour
{
    [SerializeField] private float torque = 2;
    private float test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0,0, torque * Time.deltaTime);
    }
}
