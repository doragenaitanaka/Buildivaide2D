using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    private GameObject _player,_startPos;
    private bool _startFg = false;
    public float g_oldDis;
    public GameObject g_wallobj, g_moveWallobj,g_upWallobj, g_downWallobj;//生成したプレハブを保存する
    public GameObject g_wall; //プレハブ
    public GameObject g_Bird; //プレハブ

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
                Debug.Log("GenRand" + _geneRand);
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
        int wallrand = UnityEngine.Random.Range(0, 10);
        switch (wallrand)
        {
            case 0://Default Wall
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                //ランダムな高さに穴を出現させる
                _wallRandPos = UnityEngine.Random.Range(0, 3);
                switch (_wallRandPos)
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
                break;
            case 7:
                g_wallobj = Instantiate(g_moveWallobj, new Vector3(spawnPos, 0, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
                break;
            case 8://GateUpWall
                g_wallobj = Instantiate(g_upWallobj, new Vector3(spawnPos, -12, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
                break;
            case 9:
                g_wallobj = Instantiate(g_downWallobj, new Vector3(spawnPos, 15, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
                break;
        }

        if (_wallRandPos != 0)
        {
            int birdGen = UnityEngine.Random.Range(0, 2);
            {
                Instantiate(g_Bird, new Vector3(spawnPos, 6.5f, -1), Quaternion.identity); //vecの位置にprefabObjを出現させる
            }
        }

    }
}
