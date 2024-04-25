using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaterial : MonoBehaviour
{
    public Material[] Material; // 変更後のマテリアルを設定するための変数
    // Start is called before the first frame update
    void Start()
    {
        GameObject wallChild1 = transform.GetChild(0).gameObject;
        GameObject wallChild2 = transform.GetChild(1).gameObject;
        int rand = UnityEngine.Random.Range(0, 8);
        wallChild1.GetComponent<Renderer>().material = Material[rand];
        wallChild2.GetComponent<Renderer>().material = Material[rand];
    }
}
