using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, transform.position.y, transform.position.z);
    }
}
