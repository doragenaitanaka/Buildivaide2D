using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos.z = -10;
        pos.y = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x = player.transform.position.x;
        pos.x += 6f;
        this.transform.position = pos;
    }
}
