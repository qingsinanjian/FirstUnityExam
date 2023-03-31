using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float moveSpeed = 1f;//移动速度
    public float turnSpeed = 1f;//转向速度

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
            //当映射输入不为0时，让物体沿正方向移动
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            //获得物体最后的朝向lookRot
            Quaternion lookRot = Quaternion.LookRotation(v3);
            //通过Quaternion.Slerp()取得平滑的旋转差值
            //Mathf.Clamp01()让速度不会太快或太慢
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(turnSpeed * Time.deltaTime));
        }
        Detect();
    }

    /// <summary>
    /// 检测玩家与物体之间的距离
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
