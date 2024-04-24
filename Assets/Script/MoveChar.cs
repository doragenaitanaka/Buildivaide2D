using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{
    
    public float g_speed = 15.0f; //キャラクターの移動速度
    public float g_jumpPower = 6.5f; //キャラクタのジャンプ力

    private bool _jumpFg = true;//ジャンプできるか
    private bool _airFg = false;//自分の前に地面があるか
    private bool _wallFg = false;//目の前に壁があるか
    private bool _touchFg = true;//地面に触れてるか
    public bool g_isAliveFg = true;

    public bool g_cubeFg = false;

    private Vector2 moveForward; //移動度
    private Vector2 jumpForward; //ジャンプの移動度
    private Rigidbody2D rb;


    private Collider m_Collider;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        
//===========================================================================================================
//地面、崖、壁判定
//===========================================================================================================
        touch();
        WallJump();
        AirJump();
        // Debug.Log("wall " + wallFg);
        // Debug.Log("air " + airFg);
        // Debug.Log("touch " + touchFg);
//===========================================================================================================
//ジャンプ処理
//===========================================================================================================
        if((_wallFg == true || _airFg == true)  && _touchFg == true && _jumpFg == true && g_isAliveFg == true) 
        {
            _wallFg = false;
            _airFg = false;
            _jumpFg = false;
            rb.velocity = new Vector2(rb.velocity.x, 0.0f); //y方向の移動度をリセットする
            jumpForward.y = 1.0f; //上方向へ移動
            rb.AddForce(jumpForward * g_jumpPower, ForceMode2D.Impulse);
            _jumpFg = false;
        }
//===========================================================================================================
//落下判定
//===========================================================================================================
        if(this.transform.position.y < -5.5f)
        {
            g_isAliveFg = false;
        }
        
    }
//===========================================================================================================


//===========================================================================================================
//移動
//===========================================================================================================
    void FixedUpdate () 
    {
        rb = this.transform.GetComponent<Rigidbody2D> ();
        Vector3 force = new Vector3 (30.0f, 0.0f, 0.0f);

        // 速度が10以下かつ生存フラグがtrueなら力を加える
        if (rb.velocity.magnitude < 10.0f && g_isAliveFg == true) 
        {
            rb.AddForce (force); // 力を加える
        }
    }

//===========================================================================================================
//地面判定
//===========================================================================================================
    public void touch()
    {

        Ray touch_ray = new Ray(this.transform.position + new Vector3(0.0f, 0.05f, 0.0f), new Vector3(0.0f, -1.0f, 0.0f));
        RaycastHit2D touch_hit;//当たった結果を代入する変数
        Debug.DrawRay(touch_ray.origin, touch_ray.direction * 3, Color.red, 1.0f); // 長さ3、赤色で1秒間可視化
        touch_hit = Physics2D.BoxCast(touch_ray.origin,new Vector2(3,1f),0.0f, touch_ray.direction, 0.5f);
        if (touch_hit.collider != null)
        {
            Debug.Log("当たったよ");
            Debug.Log(touch_hit.distance);
            if (touch_hit.distance < 1.0f)
            {
                _touchFg = true; //地面に接触している
                if (rb.velocity.y < 0)
                {
                    _jumpFg = true;
                }
                if (touch_hit.collider.CompareTag("Cube"))
                {
                    g_cubeFg = true;
                }
                return;
            }

        }
        Debug.Log(g_cubeFg);
        g_cubeFg = false;
        _touchFg = false;//否

    }

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
            if(wall_hit.distance < 5.0f)
            {
                _wallFg = true; //目の前に壁がある
                return;
            }
            if(wall_hit.collider.CompareTag("wall"))
            {
                g_isAliveFg = false;
            }
            
        }
        _wallFg = false; //目の前に壁がある
    }
    
//===========================================================================================================
//崖判定
//===========================================================================================================
    private void AirJump()
    {
        Ray air_ray = new Ray(this.transform.position + new Vector3(3.0f, 0.05f, 0.0f),new Vector3(0.0f, -1.0f, 0.0f));
        RaycastHit2D air_hit;//当たった結果を代入する変数
        Debug.DrawRay(air_ray.origin, air_ray.direction * 3, Color.blue, 1.0f); // 長さ3、赤色で1秒間可視化
        air_hit = Physics2D.Raycast(air_ray.origin,air_ray.direction, 10.0f);
        if(air_hit.collider != null)
        {
            if(air_hit.distance < 1.0f)
            {
                _airFg = false; //地面に接触して否
                return;
            }
        }
        _airFg = true; //地面に接触して可
    }
}
