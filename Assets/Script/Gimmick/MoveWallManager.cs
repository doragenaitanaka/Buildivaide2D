using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallManager : MonoBehaviour
{

    private ObjectID _ID;
    private bool colbreakFg = false;
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        colbreakFg = true;
    }

    /// Rendererが任意のカメラから見えると呼び出される
    private void OnBecameVisible()
    {
        //Debug.Log(Camera.current.name);
        _ID = this.gameObject.GetComponent<ObjectID>();
        if (_ID == null) //TextMeshProUGUIが見つからなければエラー
        {
            Debug.LogError("Script:ObjectIDが見つかりません");
            return;
        }

        switch(_ID.objID)
        {
            case 200:
                StartCoroutine("MoveUp");
                break;
            case 201:
                StartCoroutine("MoveDown");
                break;
            case 202:
                StartCoroutine("MoveWall");
            break;
        }
    }

    IEnumerator MoveUp() 
    {
        var posX = this.transform.position.x;
        var posY = this.transform.position.y;
        for (int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.02f);
            this.transform.position = new Vector3(posX,posY);
            posY += 0.2f;
            if (colbreakFg){yield break;}
        }
    } 
    IEnumerator MoveDown() 
    {
        var posX = this.transform.position.x;
        var posY = this.transform.position.y;
        for (int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.04f);
            this.transform.position = new Vector3(posX,posY);
            posY -= 0.2f;
            if (colbreakFg){yield break;}
        }
        
        
    } 

    IEnumerator MoveWall() 
    {
        int moveWallRand = UnityEngine.Random.Range(0, 2);
        if(moveWallRand == 0)
        {
            var posX = this.transform.position.x;
            var posY = this.transform.position.y;
            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(posX,posY);
                posY -= 0.05f;
                if (colbreakFg){yield break;}
            }   
        }
        else
        {
            var posX = this.transform.position.x;
            var posY = this.transform.position.y;
            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(posX,posY);
                posY += 0.05f;
                if (colbreakFg){yield break;}
            }   
        }
    } 
}
