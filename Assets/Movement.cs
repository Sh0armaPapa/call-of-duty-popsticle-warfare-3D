using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(10, 0);
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-10, 0);
    }
}
