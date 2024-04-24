using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class GUIManager : MonoBehaviour
{

    TextMeshProUGUI tx;
    ObjectID texID;

    private GameObject player,startPos;
    // Start is called before the first frame update
    void Start()
    {
        tx = this.GetComponent<TextMeshProUGUI>();
        texID = this.gameObject.GetComponent<ObjectID>();
        if (tx == null) //TextMeshProUGUIが見つからなければエラー
        {
            Debug.LogError("TextMeshProUGUIが見つかりません");
            return;
        }
        if (texID == null) //TextMeshProUGUIが見つからなければエラー
        {
            Debug.LogError("Script:ObjectIDが見つかりません");
            return;
        }

        switch(texID.objID)
        {
            case 100:
                player = GameObject.Find("char");
                startPos = GameObject.Find("StartEmpty");
                break;
            case 101:
                break;
            case 102:
                break;
            case 103:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
         switch(texID.objID)
        {
            case 100:
                // プレイヤーのX座標
                float playerX = player.transform.position.x;
                // スタート位置のX座標
                float startPosX = startPos.transform.position.x;  
                //距離を取得
                float distance = Mathf.Abs(playerX - startPosX);
                tx.text = distance.ToString("0.0") + "m";
                break;
            case 101:
                break;
            case 102:
                break;
            case 103:
                break;
        }
    }
}
