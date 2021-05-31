using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callGravityBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.tag == "Enemy" || other.tag == "Wall")
        {
            Debug.Log("폭발수리검 어딘가에 충돌");

            GravityBullet gravitybullet  = GameObject.Find("GravityBullet(Clone)").GetComponent<Bullet>();
            float xRotationTemp = playercamera.xRotation;
            float yRotationTemp = playercamera.yRotation;
            Quaternion pRotation = Quaternion.Euler(xRotationTemp, yRotationTemp, 0);

            GameObject Bullet = Instantiate(, BulletPos.position);
        }*/

    }
}
