using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSword : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player model");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I) && Vector3.Distance(transform.position, player.transform.position) < 7.5f)
        {
            player.transform.Find("Main Camera").Find("sword").gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
