using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fly");

    }

    IEnumerator Fly()
    {
        var posX = this.transform.position.x;
        var posY = this.transform.position.y;
        for (int i = 0; i < 300; i++)
        {
            yield return new WaitForSeconds(0.02f);
            this.transform.position = new Vector3(posX, posY);
            posX -= 0.2f;
        }
        Destroy(gameObject);
    } 
}
