using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDead : MonoBehaviour
{
    private MoveChar _charS;
    // Start is called before the first frame update
    void Start()
    {
        _charS = this.GetComponent<MoveChar>(); //MoveCharスクリプトを取得
        if (_charS != null)
        {
            Debug.LogError("Script:MoveCharが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_charS.g_isAliveFg)
        {
            Vector3 pos = this.gameObject.transform.position;
            for(int i = 0; i < 20; i++)
            {
                new Vector3(pos.x, pos.y, pos.z);
            }
        }
    }
}
