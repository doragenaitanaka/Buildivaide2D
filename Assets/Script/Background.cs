using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Background : MonoBehaviour
{
    private float _length, _startpos;
    public GameObject g_cam;
    public float g_parallaxEffect;
    void Start()
    {
        
        _startpos = transform.position.x;   // îwåiâÊëúÇÃxç¿ïW
        _length = GetComponent<SpriteRenderer>().bounds.size.x; // îwåiâÊëúÇÃxé≤ï˚å¸ÇÃïù
    }
    private void FixedUpdate()
    {
        float temp = (g_cam.transform.position.x * (1 - g_parallaxEffect));
        float dist = (g_cam.transform.position.x * g_parallaxEffect);
//===========================================================================================================
// éãç∑å¯â èàóù
//===========================================================================================================
        // îwåiâÊëúÇÃxç¿ïWÇdistÇÃï™à⁄ìÆÇ≥ÇπÇÈ
        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);
        
//===========================================================================================================
// ñ≥å¿ÉXÉNÉçÅ[Éã
//===========================================================================================================
        // âÊñ äOÇ…Ç»Ç¡ÇΩÇÁîwåiâÊëúÇà⁄ìÆÇ≥ÇπÇÈ
        if (temp > _startpos + _length)
        {
            _startpos += _length;
        } 
    }
}