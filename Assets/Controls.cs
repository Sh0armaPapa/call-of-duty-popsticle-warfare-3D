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
        mouseRotation_Y -= Mathf.Clamp(Input.GetAxis("Mouse Y"), -2.5f,2.5f) * 100f * Time.deltaTime;

        // Cant go too far
        if (mouseRotation_Y < -45f)
            mouseRotation_Y = -45f;
        if (mouseRotation_Y > 45f)
            mouseRotation_Y = 45f;
        transform.Find("Main Camera").localRotation = Quaternion.Euler(mouseRotation_Y, 0f, 0f);

        // Looking left and right
        transform.Rotate(new Vector3(0, Mathf.Clamp(Input.GetAxis("Mouse X"), -2.5f, 2.5f) * 150f * Time.deltaTime,0));

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward) * 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right) * 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left) * 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back) * 20f * Time.deltaTime;


        GameObject goon = GameObject.Find("stick.goon");
        // hit
        if (Input.GetMouseButtonDown(0) && transform.Find("Main Camera").Find("sword").gameObject.activeInHierarchy)
        {
            

            StartCoroutine(hit());
            if (Vector3.Distance(goon.transform.position, transform.position) < 5f)
                Destroy(goon);
        }


        if (Vector3.Distance(goon.transform.position, transform.position) < 2.5f)
        {
            Destroy(gameObject);
            Debug.Log("You have died LOL");
        }
    }

    bool ishitting = false;
    IEnumerator hit()
    {
        if (ishitting)
            yield break;
        ishitting = true;

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
        ishitting = false;
    }
}
