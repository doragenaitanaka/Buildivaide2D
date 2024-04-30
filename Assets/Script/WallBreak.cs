using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
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
        yield return new WaitForSeconds(8.0f);
        Destroy(gameObject);
    } 
}
