using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Create : MonoBehaviour
{
    public GameObject g_cube;
    public GameObject g_obj;
    private MoveChar _charS;
    private Mouse _mouse;

    public bool g_createFg = true;
    // Start is called before the first frame update
    void Start()
    {
        _charS = this.GetComponent<MoveChar>();
        if (_charS == null)
        {
            Debug.LogError("Script:MoveCharが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _mouse = Mouse.current;//マウスの位置を取得
        if (_mouse.leftButton.wasPressedThisFrame)//左クリックされたら
            {
                // マウスカーソルの位置を取得
                Vector2 mousePos = _mouse.position.ReadValue();
                // スクリーン座標のZ値を5に変更  
                var screenPos = new Vector3(mousePos.x, mousePos.y, 5f);  
                // ワールド座標に変換  
                var worldPos = Camera.main.ScreenToWorldPoint(screenPos);  
                g_obj = Instantiate(g_cube, worldPos, Quaternion.identity); //vecの位置にprefabObjを出現させる
                g_createFg = false;
                StartCoroutine("CreateFun");
            }
        
        if(_charS.g_cubeFg == true)
        {
            g_createFg = true;
        }
    }

    IEnumerator CreateFun() 
    {
        yield return new WaitForSeconds(0.5f);
        g_createFg = true;
    } 
}
