using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class GUIManager : MonoBehaviour
{

    private TextMeshProUGUI _tx;
    private ObjectID _texID;

    private GameObject _player,_startPos;
    // Start is called before the first frame update
    void Start()
    {
        _tx = this.GetComponent<TextMeshProUGUI>();
        _texID = this.gameObject.GetComponent<ObjectID>();
        if (_tx == null) //TextMeshProUGUIが見つからなければエラー
        {
            Debug.LogError("TextMeshProUGUIが見つかりません");
            return;
        }
        if (_texID == null) //TextMeshProUGUIが見つからなければエラー
        {
            Debug.LogError("Script:ObjectIDが見つかりません");
            return;
        }
//===========================================================================================================
// ObjectIDを取得して初期化する
// 100:プレイヤーの飛距離を表示するGUI
//===========================================================================================================
        switch(_texID.objID)
        {
            case 100:
                _player = GameObject.Find("character");
                _startPos = GameObject.Find("StartEmpty");
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
//===========================================================================================================
// ObjectIDを取得して処理を変更する
// 100:プレイヤーの飛距離を表示するGUI
//===========================================================================================================
         switch(_texID.objID)
        {
            case 100:
                // プレイヤーのX座標
                float playerX = _player.transform.position.x;
                // スタート位置のX座標
                float startPosX = _startPos.transform.position.x;  
                //距離を取得
                float distance = Mathf.Abs(playerX - startPosX);
                _tx.text = distance.ToString("0.0") + "m";
                break;
        }
    }
}
