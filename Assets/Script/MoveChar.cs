using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{

    public float g_speed = 15.0f; //キャラクターの移動速度
    public float g_jumpPower = 6.5f; //キャラクタのジャンプ力

    private bool _jumpFg = true;//ジャンプできるか
    // private bool _airFg = false;//自分の前に地面があるか
    // private bool _touchFg = true;//地面に触れてるか
    private bool _wallFg = false;//目の前に壁があるか
    public bool g_isAliveFg = true;

    public bool g_cubeFg = false;

    private Vector2 _moveForward; //移動度
    private Vector2 _jumpForward; //ジャンプの移動度
    private Rigidbody2D _rb;


    private Collider _Collider;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {


//===========================================================================================================
//地面、崖、壁判定
//===========================================================================================================
        //touch();
        WallJump();
        ceiling();  //天井判定
        //AirJump();
        // Debug.Log("wall " + wallFg);
        // Debug.Log("air " + airFg);
        // Debug.Log("touch " + touchFg);
//===========================================================================================================
//ジャンプ処理
//===========================================================================================================
        // if((_wallFg == true || _airFg == true)  && _touchFg == true && _jumpFg == true && g_isAliveFg == true)
        // {
        //     _wallFg = false;
        //     _airFg = false;
        //     _rb.velocity = new Vector2(_rb.velocity.x, 0.0f); //y方向の移動度をリセットする
        //     _jumpForward.y = 1.0f; //上方向へ移動
        //     _rb.AddForce(_jumpForward * g_jumpPower, ForceMode2D.Impulse);
        //     _jumpFg = false;
        // }

        if(Input.GetKeyDown(KeyCode.Space) && _jumpFg == true && g_isAliveFg == true) //"スペース押された"かつ"ジャンプできる"かつ"生きてる"
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0.0f); //y方向の移動度をリセットする
            _jumpForward.y = 1.0f; //上方向へ移動
            _rb.AddForce(_jumpForward * g_jumpPower, ForceMode2D.Impulse);
            //_jumpFg = false;
        }

//===========================================================================================================
//落下判定
//===========================================================================================================

        // if (_rb.velocity.y < 0) //プレイヤーが下方向に動いていたら
        // {
        //     _jumpFg = true;     //ジャンプできるようにする
        // }

//===========================================================================================================
//死亡判定
//===========================================================================================================
        if(this.transform.position.y < -5.5f)
        {
            g_isAliveFg = false;
        }
//===========================================================================================================
//停止判定
//===========================================================================================================
        if (_rb.velocity.x < 0.2)
        {
            g_isAliveFg = false;
        }



        //死んだらlog出す
        if(g_isAliveFg == false)
        {
            _rb.velocity = new Vector2(0.0f, _rb.velocity.y); //y方向の移動度をリセットする
        }
    }

//===========================================================================================================


//===========================================================================================================
//移動
//===========================================================================================================
    void FixedUpdate ()
    {
        _rb = this.transform.GetComponent<Rigidbody2D> ();
        Vector3 force = new Vector3 (30.0f, 0.0f, 0.0f);

        // 速度が10以下かつ生存フラグがtrueなら力を加える
        if (_rb.velocity.magnitude < 10.0f && g_isAliveFg == true)
        {
            _rb.AddForce (force); // 力を加える
        }
        //Debug.Log("Player X Speed: " + Mathf.Abs(_rb.velocity.x));    //キャラクターのスピードチェック
    }
//===========================================================================================================
//天井判定
//===========================================================================================================

public void ceiling()
{
    if(_rb.position.y >= 8.5f)
    {
        _jumpFg = false;
    }
    else
    {
        _jumpFg = true;
    }
}

//===========================================================================================================
//地面判定
//===========================================================================================================
    // public void touch()
    // {
    //     //raycast
    //     Ray touch_ray = new Ray(this.transform.position + new Vector3(0.0f, 0.05f, 0.0f), new Vector3(0.0f, -1.0f, 0.0f));
    //     RaycastHit2D touch_hit;     //当たった結果を代入する変数
    //     Debug.DrawRay(touch_ray.origin, touch_ray.direction * 3, Color.red, 1.0f);  // 長さ3、赤色で1秒間可視化
    //     touch_hit = Physics2D.Raycast(touch_ray.origin, touch_ray.direction, 10.0f);
    //     if (touch_hit.collider != null)
    //     {
    //         if (touch_hit.distance < 1.0f)
    //         {
    //             _touchFg = true; //地面に接触している
    //             if (touch_hit.collider.CompareTag("Cube"))  //地面のtagがCubeであれば
    //             {
    //                 g_cubeFg = true; //地面がcubeであればブロックを生成できるようにする。
    //             }
    //             return;
    //         }

    //     }
    //     g_cubeFg = false;
    //     _touchFg = false;

    // }

//===========================================================================================================
//壁判定
//===========================================================================================================
    private void WallJump()
    {
        Ray wall_ray = new Ray(this.transform.position + new Vector3(0.0f, 0.05f, 0.0f),new Vector3(1.0f, 0.0f, 0.0f));
        RaycastHit2D wall_hit;//当たった結果を代入する変数
        Debug.DrawRay(wall_ray.origin, wall_ray.direction * 5, Color.green, 1.0f); // 長さ3、赤色で1秒間可視化
        wall_hit = Physics2D.Raycast(wall_ray.origin,wall_ray.direction, 10.0f);
        if(wall_hit.collider != null)
        {
            if (wall_hit.collider.CompareTag("wall"))   //障害物とぶつかったら
            {
                if (wall_hit.distance < 0.5f)
                {
                    g_isAliveFg = false;
                }
            }

            if (wall_hit.distance < 5.0f)
            {
                _wallFg = true; //目の前に壁がある
                return;
            }


        }
        _wallFg = false; //目の前に壁がある
    }

//===========================================================================================================
//崖判定
//===========================================================================================================
    // private void AirJump()
    // {
    //     Ray air_ray = new Ray(this.transform.position + new Vector3(3.0f, 0.05f, 0.0f),new Vector3(0.0f, -1.0f, 0.0f)); //前にray出す
    //     RaycastHit2D air_hit;   //当たった結果を代入する変数
    //     Debug.DrawRay(air_ray.origin, air_ray.direction * 3, Color.blue, 1.0f); // 長さ3、赤色で1秒間可視化
    //     air_hit = Physics2D.Raycast(air_ray.origin,air_ray.direction, 10.0f);   //当たったオブジェクトのデータを代入
    //     if(air_hit.collider != null)
    //     {
    //         if(air_hit.distance < 1.0f)
    //         {
    //             _airFg = false; //地面に接触してない
    //             return;
    //         }
    //     }
    //     _airFg = true; //地面に接触している
    // }
}
