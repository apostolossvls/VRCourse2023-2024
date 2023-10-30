using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxis : MonoBehaviour
{
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //print("Hello World! on start");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        //Debug.Log("Hello World! on update");
    }
}
