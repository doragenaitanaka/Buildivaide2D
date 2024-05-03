using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWall : MonoBehaviour
{
    // private ObjectID _ID;
    private GameObject gate;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("当たった");
        if (other.gameObject.tag == "Cube")
        {
            Destroy(gate);
        }
    }
    void Start()
    {
        // _ID = this.gameObject.GetComponent<ObjectID>();
        // if (_ID == null) //TextMeshProUGUIが見つからなければエラー
        // {
        //     Debug.LogError("Script:ObjectIDが見つかりません");
        //     return;
        // }

        gate = GameObject.Find("gate");
        if (gate == null) //TextMeshProUGUIが見つからなければエラー
        {
            Debug.LogError("gateが見つかりません");
            return;
        }

    }


}
