using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaterial : MonoBehaviour
{
    public Material[] g_Material; // �ύX��̃}�e���A����ݒ肷�邽�߂̕ϐ�
    // Start is called before the first frame update
    void Start()
    {
//===========================================================================================================
//��Q���̕ǂɐF��t����
//===========================================================================================================
        GameObject wallChild1 = transform.GetChild(0).gameObject;
        GameObject wallChild2 = transform.GetChild(1).gameObject;
        //�����_���ɐF��t����
        int rand = UnityEngine.Random.Range(0, 8);
        wallChild1.GetComponent<Renderer>().material = g_Material[rand];
        wallChild2.GetComponent<Renderer>().material = g_Material[rand];
    }
}
