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
    public Material[] Material; // 変更後のマテリアルを設定するための変数

    [Header("rand")]
    [SerializeField] private int geneRand, wallRandPos;
    void Start()
    {
        _player = GameObject.Find("char");
        _startPos = GameObject.Find("StartEmpty");
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = _player.transform.position.x;
        // スタート位置のX座標
        float startPosX = _startPos.transform.position.x;  
        //距離を取得
        float distance = Mathf.Abs(playerX - startPosX);

        if(distance > 40 && _startFg == false)
        {
            _startFg = true;
            g_oldDis  = distance;

        }

        if(_startFg == true)
        {
            if(g_oldDis+10 < distance)
            {
                g_oldDis = distance;
                geneRand = UnityEngine.Random.Range(0, 2);
                if(geneRand == 0)
                {
                    WallGenerate();
                }

            }
        }
    }

    public void WallGenerate()
    {
        wallRandPos = UnityEngine.Random.Range(0, 3);
        Transform pos = _player.transform;
        var spawnPos = pos.position.x + 20.0f;
        switch(wallRandPos)
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
         
        int rand = UnityEngine.Random.Range(0, 8);
        //g_wallobj.GetComponent<Renderer>().material = Material[rand];

    }
}
