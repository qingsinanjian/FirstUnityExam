using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject sphere;
    public Transform bottomLeft;
    public Transform topRight;
    // Start is called before the first frame update
    void Start()
    {
        //生成随机位置的10个小球
        sphere = Resources.Load<GameObject>("Sphere");
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(bottomLeft.position.x, topRight.position.x);
            float z = Random.Range(bottomLeft.position.z, topRight.position.z);
            GameObject go = Instantiate<GameObject>(sphere, new Vector3(x, 0.5f, z), Quaternion.identity);
            go.transform.SetParent(this.transform);
        }
    }
}
