using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWall : MonoBehaviour
{
    private ObjectID _ID;

    
    void Start()
    {
        _ID = this.gameObject.GetComponent<ObjectID>();
        if (_ID == null) //TextMeshProUGUIが見つからなければエラー
        {
            Debug.LogError("Script:ObjectIDが見つかりません");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
