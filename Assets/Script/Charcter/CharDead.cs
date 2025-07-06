using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharDead : MonoBehaviour
{
    private MoveChar _charS;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxcol;
    public float g_jumpPower = 12.0f; //キャラクタのジャンプ力
    private Vector2 _jumpForward; //ジャンプの移動度

    private bool _instantMotion = false;
    // Start is called before the first frame update
    void Start()
    {
        _charS = this.gameObject.GetComponent<MoveChar>(); //MoveCharスクリプトを取得
        if (_charS == null)
        {
            Debug.LogError("Script:MoveCharが見つかりません");
        }

        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2Dが見つかりません");
        }

        _boxcol = this.gameObject.GetComponent<BoxCollider2D>();
        if (_boxcol == null)
        {
            Debug.LogError("BoxCollider2Dが見つかりません");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_charS.g_isAliveFg == false && _instantMotion == false)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0.0f); //y方向の移動度をリセットする
            _jumpForward.y = 1.0f; //上方向へ移動
            _rb.AddForce(_jumpForward * g_jumpPower, ForceMode2D.Impulse);
            _boxcol.enabled = false;
            _instantMotion = true;
            StartCoroutine("Result");
        }
    }

    IEnumerator Result()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Result");
    } 
}
