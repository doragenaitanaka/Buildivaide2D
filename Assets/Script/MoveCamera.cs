using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject g_player;
    private Vector3 _pos;

    // Start is called before the first frame update
    void Start()
    {
        _pos.z = -10;   //
        _pos.y = 1.5f;  //カメラの座標を初期化する
    }

    // Update is called once per frame
    void Update()
    {
        _pos.x = g_player.transform.position.x; //posにキャラクターの座標を代入
        _pos.x += 6f;                           //
        this.transform.position = _pos;         //カメラの座標を設定
    }
}
