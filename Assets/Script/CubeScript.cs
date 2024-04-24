using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Material[] Material; // 変更後のマテリアルを設定するための変数
    
    // Start is called before the first frame update
    void Start()
    {
        int rand = UnityEngine.Random.Range(0, 8);
        GetComponent<Renderer>().material = Material[rand];
        StartCoroutine("delet");
    }
    IEnumerator delet() 
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    } 
}
