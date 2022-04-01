using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLePlayer : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 dir = (player.transform.position - transform.position).normalized;

        transform.position += new Vector3(dir.x,0,dir.z) * 5f * Time.deltaTime;
    }
}
