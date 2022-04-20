using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Combat : MonoBehaviour
{
    GameObject goon
    {
        get
        {
            if (_goon == null)
                _goon = GameObject.Find("stick.goon");
            return _goon;
        }
    }
    GameObject _goon;

    void Update()
    {
        if (goon != null)
        {
            // Hit the goon, 8 unit range
            if (Input.GetMouseButtonDown(0) && transform.Find("Main Camera").Find("sword").gameObject.activeInHierarchy)
            {
                StartCoroutine(Hit());
                
                // If close enough, destroy
                if (Vector3.Distance(goon.transform.position, transform.position) < 8f)
                    Destroy(goon);
            }

            // Goon hits us, 3.5 unit range
            if (Vector3.Distance(goon.transform.position, transform.position) < 3.5f)
            {
                StartCoroutine(Appear());
                
                // activate "ur dead" text and make skybox black
                GameObject.Find("Canvas").transform.Find("udead").gameObject.SetActive(true);
                Camera.main.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;

                GetComponent<CharacterController>().enabled = false;
                gameObject.transform.position = new Vector3(0, -9999, 0);
            }
        }
    }

    /// <summary>
    /// Makes the "ur dead" text slowly appear
    /// </summary>
    IEnumerator Appear()
    {
        TMP_Text bruh = GameObject.Find("Canvas").transform.Find("udead").GetComponent<TMP_Text>();

        bruh.color = new Color(1, 0, 0, 0);
        // Increase opacity value until fully visible
        while (bruh.color.a < 1)
        {
            yield return new WaitForSeconds(0.025f);
            bruh.color = new Color(bruh.color.r, bruh.color.g, bruh.color.b, bruh.color.a + 1f / 255f);
        }
    }
    
    /// <summary>
    /// Sword "animation"
    /// </summary>
    IEnumerator Hit()
    {
        // prevent from being called twice
        if (ishitting)
            yield break;
        ishitting = true;

        // rotate down at a fast pace
        for (int i = 0; i < 30; i++)
        {
            transform.Find("Main Camera").Find("sword").Rotate(new Vector3(1, 0));
            yield return new WaitForSeconds(0.01f);
        }
        // rotate back at a slower pace
        for (int i = 0; i < 30; i++)
        {
            transform.Find("Main Camera").Find("sword").Rotate(new Vector3(-1, 0));
            yield return new WaitForSeconds(0.02f);
        }

        ishitting = false;
    }
    bool ishitting = false;
}
