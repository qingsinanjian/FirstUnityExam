using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphere : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //С������
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }

}
