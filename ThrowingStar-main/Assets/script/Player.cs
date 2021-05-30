using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Plai 유튜브 https://www.youtube.com/watch?v=LqnPeqoJRFY 참조
public class Player : MonoBehaviour
{

    public GameObject Bullets;
    public Transform BulletPos;
    public Vector3 jumpVector;
   


    //캐릭터높이 정해줌 밑에 있는 isGround에서 사용
    float playerHeight = 2f;

    [SerializeField] Transform orientation;
    [Header("Movement")] //이동변수 헤더

    public float moveSpeed = 6f;
    public float movementMultiplier = 10f;//이동속도 추가

    [SerializeField] float airMultiplier = 0.3f;//이동속도 추가

    [Header("Keybinds")]//점프키 만들어주는 헤더라 함
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sliding = KeyCode.C;

    [Header("Jumping")]
    public float jumpForce = 12.0f;


    
    [Header("Drag")] // 대충 공기저항 느낌. 드래그값에 따라서 최대가속도 정해짐.
    float groundDrag = 6f;
    float airDrag = 1.2f;

    //수직방향 두개 필요
    float horizontalMovement;
    float verticalMovement;

    


    bool isGrounded;
    bool isDoubleJump;
    bool isSlide = false;
    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //리지드바디 컴포넌트 가져오기
        rb.freezeRotation = true;

        
        

    }

    private void Update()
    {
        //땅과의 충돌을 확인, 캐릭터 높이 2f에서 반 나누고 땅과 높이측정함. 
        //닿지 않을떄도 있으니 확실하게 하려고 0.1f로 보완
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);
        if(isGrounded == true)
        {
            isDoubleJump = false;
        }


        MyInput();
        ControlDrag();

        //총알 생성. xRotation을 카메라에서 받아야하는데..
        if (Input.GetMouseButtonDown(0))
        {//카메라에 x로테이션이 달려있어서 불릿 생성시 x회전이 전혀 들어가지 않음... 해결중
            //playerCamera 에서 둘다 받아와서 추가했음.
            playerCamera playercamera = GameObject.Find("PlayerFps").GetComponent<playerCamera>();
            float xRotationTemp = playercamera.xRotation;
            float yRotationTemp = playercamera.yRotation;
            Quaternion pRotation = Quaternion.Euler(xRotationTemp, yRotationTemp, 0);

            GameObject Bullet = Instantiate(Bullets, BulletPos.position, pRotation);
            //GameObject Bullet = Instantiate(Bullets, BulletPos.position, transform.localRotation);
        }

        //점프와 더블점프(벽점프)
        if(Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(jumpKey) && !isGrounded && isDoubleJump)
        {
            doubleJump(); isDoubleJump = false; 
        }


        //슬라이딩구현
        if(Input.GetKey(sliding) && isGrounded)
        {
            if (!isSlide)
            {
                //추가속도(1.3배로 0.8초 유지)
                moveSpeed = moveSpeed *1.5f;
                Invoke("moveSpeedReset", 2.8f);
                //카메라y축 절반 내려감(0.8초 유지)
                isSlide = true;

            }


        }


    }

    void MyInput() //입력처리용이라 함.
    {
        //수직, 수평이동을 얻은 후 적용
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        //우리가 사용하는 수평이동, 플레이어가 바라보는 방향으로 이동.
        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    void Jump()
    {
        //점프시 위쪽방향으로 힘추가하는 식으로 점프한다함
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); 
    }

    void doubleJump()
    {
        
        //점프시 위쪽방향으로 힘추가하는 식으로 점프한다함
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        rb.AddRelativeForce(orientation.forward* -1 * 1.5f* jumpForce, ForceMode.Impulse);
    }

    void ControlDrag()
    {//캐릭터가 공중에서 풍선마냥 뜨는느낌 지우려고 만드는 듯 함.
        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }



    //움직임 매끄럽게 하기 위한 추가라 함.
    private void FixedUpdate()
    {
        MovePlayer();
    }

    //이동
    void MovePlayer()
    {//이동방향으로 힘을 가함, 노멀라이즈드 곱한 이유는 대각선 루트2때문에.

        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);

        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
            rb.AddForce(transform.up *-1* jumpForce, ForceMode.Acceleration);
            
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            isDoubleJump = true;
        }
    }



    //슬라이딩 끝나고 초기화 하는용. isSlide 처리때문에..
    void moveSpeedReset()
    {
        moveSpeed = 6f;
        isSlide = false;
        Debug.Log("moveSpeedResetCall");
    }




        

}

