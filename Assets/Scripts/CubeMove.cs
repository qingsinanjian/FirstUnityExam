using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float moveSpeed = 1f;//�ƶ��ٶ�
    public float turnSpeed = 1f;//ת���ٶ�

    private Vector3 bigScale = new Vector3(2, 2, 2);
    private Vector3 smallScale = Vector3.one;

    public float radius;
    public Transform cube1;
    public Transform cube2;

    void Update()
    {
        float ad = Input.GetAxis("Horizontal");
        float ws = Input.GetAxis("Vertical");
        Vector3 v3 = new Vector3(ad, 0, ws);
        if (v3 != Vector3.zero)
        {
            //��ӳ�����벻Ϊ0ʱ�����������������ƶ�
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            //����������ĳ���lookRot
            Quaternion lookRot = Quaternion.LookRotation(v3);
            //ͨ��Quaternion.Slerp()ȡ��ƽ������ת��ֵ
            //Mathf.Clamp01()���ٶȲ���̫���̫��
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(turnSpeed * Time.deltaTime));
        }
        Detect();
    }

    /// <summary>
    /// ������������֮��ľ���
    /// </summary>
    private void Detect()
    {
        if(Vector3.Distance(transform.position, cube1.position) < radius || Vector3.Distance(transform.position, cube2.position) < radius) 
        {
            ModifyScale(false);
        }else if(Vector3.Distance(transform.position, cube1.position) >= radius && Vector3.Distance(transform.position, cube2.position) >= radius)
        {
            ModifyScale(true);
        }
    }

    public void ModifyScale(bool isNormal = true)
    {
        if (isNormal)
        {
            Big();
        }
        else
        {
            Small();
        }
    }


    public void Big()
    {
        if(this.transform.localScale != bigScale)
        {
            this.transform.localScale = bigScale;
        }
    }
    public void Small()
    {
        if (this.transform.localScale != smallScale)
        {
            this.transform.localScale = smallScale;
        }
    }
}
