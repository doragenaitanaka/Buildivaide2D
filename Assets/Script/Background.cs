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
        
        _startpos = transform.position.x;   // �w�i�摜��x���W
        _length = GetComponent<SpriteRenderer>().bounds.size.x; // �w�i�摜��x�������̕�
    }
    private void FixedUpdate()
    {
        float temp = (g_cam.transform.position.x * (1 - g_parallaxEffect));
        float dist = (g_cam.transform.position.x * g_parallaxEffect);
//===========================================================================================================
// �������ʏ���
//===========================================================================================================
        // �w�i�摜��x���W��dist�̕��ړ�������
        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);
        
//===========================================================================================================
// �����X�N���[��
//===========================================================================================================
        // ��ʊO�ɂȂ�����w�i�摜���ړ�������
        if (temp > _startpos + _length)
        {
            _startpos += _length;
        } 
    }
}