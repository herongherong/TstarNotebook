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
        Debug.Log("movingByBlackHole()�۵�");
        GravityBullet gravitybullet = GameObject.Find("GravityBullet").GetComponent<GravityBullet>();
        Vector3 pos = gravitybullet.pos;

        Vector3 dir = (pos - transform.position).normalized;

        acceleration = 0.01f;

        velocity = (velocity + acceleration * Time.deltaTime);

        distance = Vector3.Distance(pos, transform.position);



        if (distance <= 7.0f && distance >= 3.0f)

        {
            Debug.Log("7m�̳���");
            //���ɷ� ����, �������� �� �� ���ʹ� ��ũ��Ʈ�� �޸� ���ʹ̸� �����.
            transform.position = new Vector3(transform.position.x + (dir.x * velocity),
                transform.position.y + (dir.y * velocity), 
                transform.position.z + (dir.z * velocity) );
            // �ѹ��� ȸ�� ����
                transform.RotateAround(pos, new Vector3(0,1,0), 500 * Time.deltaTime);
        }
        else if(distance <= 3.0f && distance >= 0.1f)
        {
            Debug.Log("3m�̳���");
            //���ɷ� ����, �������� �� �� ���ʹ� ��ũ��Ʈ�� �޸� ���ʹ̸� �����.
            transform.position = new Vector3(transform.position.x + (dir.x * velocity),
                transform.position.y + (dir.y * velocity),
                transform.position.z + (dir.z * velocity));
            // �ѹ��� ȸ�� ����
            transform.RotateAround(pos, new Vector3(0, 1, 0), 800 * Time.deltaTime);
        }
        else

        {
            Debug.Log("pos ��������");
            velocity = 0.0f;

        }

    }
}
