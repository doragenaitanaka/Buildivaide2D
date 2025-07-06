using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    //public Material[] g_Material; // 変更後のマテリアルを設定するための変数
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("delet");
    }

//===========================================================================================================
//CubeDelet
//生成したCubeを5秒後に削除する関数
//===========================================================================================================
    IEnumerator delet() 
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    } 
}
