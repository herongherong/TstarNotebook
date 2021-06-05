using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float acceleration;
    float velocity;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        acceleration = 0.005f;
        velocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movingByBlackHole()
    {
        Debug.Log("movingByBlackHole()�۵�");
        GravityShuriken gravityshuriken = GameObject.Find("GravityShuriken(Clone)").GetComponent<GravityShuriken>();
        
        Vector3 pos = gravityshuriken.pos;

        Vector3 dir = (pos - transform.position).normalized;

        

        velocity = (velocity + acceleration * Time.deltaTime);

        distance = Vector3.Distance(pos, transform.position);



        if (distance <= 8.0f && distance >= 4.0f)

        {
            Debug.Log("8m�̳���");
            //���ɷ� ����, �������� �� �� ���ʹ� ��ũ��Ʈ�� �޸� ���ʹ̸� �����.
            transform.position = new Vector3(transform.position.x + (dir.x * velocity),
                transform.position.y + (dir.y * velocity), 
                transform.position.z + (dir.z * velocity) );
            // �ѹ��� ȸ�� ����
                transform.RotateAround(pos, new Vector3(0,1,0), 1000 * Time.deltaTime);
        }
        else if(distance <= 4.0f && distance >= 0.1f)
        {
            Debug.Log("4m�̳���");
            //���ɷ� ����, �������� �� �� ���ʹ� ��ũ��Ʈ�� �޸� ���ʹ̸� �����.
            transform.position = new Vector3(transform.position.x + (dir.x * velocity),
                transform.position.y + (dir.y * velocity),
                transform.position.z + (dir.z * velocity));
            // �ѹ��� ȸ�� ����
            transform.RotateAround(pos, new Vector3(0, 1, 0), 1600 * Time.deltaTime);

            

        }
        else

        {
            Debug.Log("pos ��������");
            velocity = 0.0f;

        }
        
        if (gravityshuriken.warp == true)
        {
            Invoke("destroyEnemy", 3f);
        }

    }


    void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
