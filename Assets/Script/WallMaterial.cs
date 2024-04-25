using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaterial : MonoBehaviour
{
    public Material[] g_Material; // 変更後のマテリアルを設定するための変数
    // Start is called before the first frame update
    void Start()
    {
//===========================================================================================================
//障害物の壁に色を付ける
//===========================================================================================================
        GameObject wallChild1 = transform.GetChild(0).gameObject;
        GameObject wallChild2 = transform.GetChild(1).gameObject;
        //ランダムに色を付ける
        int rand = UnityEngine.Random.Range(0, 8);
        wallChild1.GetComponent<Renderer>().material = g_Material[rand];
        wallChild2.GetComponent<Renderer>().material = g_Material[rand];
    }
}
