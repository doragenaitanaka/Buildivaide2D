using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Background : MonoBehaviour
{
    private float _length, _startpos;
    public GameObject g_cam;
    public float g_parallaxEffect;
    void Start()
    {
        
        _startpos = transform.position.x;   // 背景画像のx座標
        _length = GetComponent<SpriteRenderer>().bounds.size.x; // 背景画像のx軸方向の幅
    }
    private void FixedUpdate()
    {
        float temp = (g_cam.transform.position.x * (1 - g_parallaxEffect));
        float dist = (g_cam.transform.position.x * g_parallaxEffect);
//===========================================================================================================
// 視差効果処理
//===========================================================================================================
        // 背景画像のx座標をdistの分移動させる
        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);
        
//===========================================================================================================
// 無限スクロール
//===========================================================================================================
        // 画面外になったら背景画像を移動させる
        if (temp > _startpos + _length)
        {
            _startpos += _length;
        } 
    }
}