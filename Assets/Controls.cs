using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float mouseRotation_Y = 0f;
    void Update()
    { 
        // Looking up and down
        mouseRotation_Y -= Mathf.Clamp(Input.GetAxis("Mouse Y"), -10f,10f) * 200f * Time.deltaTime;

        // Cant go too far
        if (mouseRotation_Y < -90f)
            mouseRotation_Y = -90f;
        if (mouseRotation_Y > 90f)
            mouseRotation_Y = 90f;
        transform.Find("Main Camera").localRotation = Quaternion.Euler(mouseRotation_Y, 0f, 0f);

        // Looking left and right
        transform.Rotate(new Vector3(0, Mathf.Clamp(Input.GetAxis("Mouse X"), -10f, 10f) * 200f * Time.deltaTime,0));

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward) * 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right) * 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left) * 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back) * 20f * Time.deltaTime;



        // hit
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(hit());
        }

    }
    IEnumerator hit()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.Find("Main Camera").Find("sword").Rotate(new Vector3(1, 0));
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 30; i++)
        {
            transform.Find("Main Camera").Find("sword").Rotate(new Vector3(-1, 0));
            yield return new WaitForSeconds(0.02f);
        }
    }
}
