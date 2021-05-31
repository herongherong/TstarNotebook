using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float acceleration;
    float velocity = 0;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movingByBlackHole()
    {
        Debug.Log("movingByBlackHole()작동");
        GravityBullet gravitybullet = GameObject.Find("GravityBullet").GetComponent<GravityBullet>();
        Vector3 pos = gravitybullet.pos;

        Vector3 dir = (pos - transform.position).normalized;

        acceleration = 0.01f;

        velocity = (velocity + acceleration * Time.deltaTime);

        distance = Vector3.Distance(pos, transform.position);



        if (distance <= 7.0f && distance >= 3.0f)

        {
            Debug.Log("7m이내임");
            //구심력 구현, 끌려오는 즉 이 에너미 스크립트가 달린 에너미를 끌어옴.
            transform.position = new Vector3(transform.position.x + (dir.x * velocity),
                transform.position.y + (dir.y * velocity), 
                transform.position.z + (dir.z * velocity) );
            // 한방향 회전 구현
                transform.RotateAround(pos, new Vector3(0,1,0), 500 * Time.deltaTime);
        }
        else if(distance <= 3.0f && distance >= 0.1f)
        {
            Debug.Log("3m이내임");
            //구심력 구현, 끌려오는 즉 이 에너미 스크립트가 달린 에너미를 끌어옴.
            transform.position = new Vector3(transform.position.x + (dir.x * velocity),
                transform.position.y + (dir.y * velocity),
                transform.position.z + (dir.z * velocity));
            // 한방향 회전 구현
            transform.RotateAround(pos, new Vector3(0, 1, 0), 800 * Time.deltaTime);
        }
        else

        {
            Debug.Log("pos 같아졌음");
            velocity = 0.0f;

        }

    }
}
