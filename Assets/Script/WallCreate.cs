using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    private GameObject _player,_startPos;
    private bool _startFg = false;
    public float g_oldDis;
    public GameObject g_wallobj;//生成したプレハブを保存する
    public GameObject g_wall; //プレハブ
   

    private int _geneRand, _wallRandPos;
    void Start()
    {
        _player = GameObject.Find("character");
        _startPos = GameObject.Find("StartEmpty");
    }

    // Update is called once per frame
    void Update()
    {
//===========================================================================================================
// プレイヤーの座標を取得する
//===========================================================================================================
        float playerX = _player.transform.position.x;       //プレイヤーのX座標を代入
        float startPosX = _startPos.transform.position.x;   // スタート位置のX座標
        float distance = Mathf.Abs(playerX - startPosX);    //スタート位置から現在の距離を取得

        //最初40mは障害物を出さない
        if(distance > 40 && _startFg == false)
        {
            _startFg = true;        
            g_oldDis  = distance;   //現在の距離をoldDisに代入

        }

        if(_startFg == true)
        {
            //現在の距離がoldDisより10m以上離れていたら
            if(g_oldDis+10 < distance)  
            {
                g_oldDis = distance;//現在の距離をoldDisに代入
                _geneRand = UnityEngine.Random.Range(0, 2); //障害物を生成するか決める
                if(_geneRand == 0)
                {
                    WallGenerate();
                }

            }
        }
    }

//===========================================================================================================
// プレイヤーの前に障害物を出す処理
//===========================================================================================================
    public void WallGenerate()
    {
        
        Transform pos = _player.transform;      //
        var spawnPos = pos.position.x + 20.0f;  //プレイヤーの前方に出現位置を設定
        //ランダムな高さに穴を出現させる
        _wallRandPos = UnityEngine.Random.Range(0, 3);
        switch(_wallRandPos)
        {
            case 0:
            g_wallobj = Instantiate(g_wall, new Vector3(spawnPos, -2, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
                break;
            case 1:
            g_wallobj = Instantiate(g_wall, new Vector3(spawnPos, -3, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
                break;
            case 2:
            g_wallobj = Instantiate(g_wall, new Vector3(spawnPos, -5, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
                break;
             case 3:
            g_wallobj = Instantiate(g_wall, new Vector3(spawnPos, -6, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
                break;
        }

    }
}
