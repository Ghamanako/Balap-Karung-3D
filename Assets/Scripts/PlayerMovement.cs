using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InGameEvent inGame;
    //Basic Movement Paramater

    private Animator animator;
    private Vector3 targetPos;
    public float forwardSpeed;
    private int desiredLane = 1;
    public float LaneDistance = 4;
    public Transform player;
    private SwipeManager swipeManager;

    private bool swipeUpSpam = false;
    private bool swipeRightSpam = false;
    private bool swipeLeftSpam = false;
    private RaycastHit hit;
    private float range = 2f;
    [SerializeField]LayerMask layer;
    //buat QTE

    public float BoostSpeed;
    public float BoostTime;

    [SerializeField]private float ToSwipe=0.5f;
    [SerializeField] private float ToSwipeHorizontal = 1f;
    float interval = 10f;
    float time;

    //power Bar
    [SerializeField] GameObject Bar;
   [SerializeField]Image PowerBankMask;
    public float BarChangeSpeed = 1;
    public float MaxPowerValue = 100;
    public float CurrentPowerBarValue;
    bool PowerIsIncreasing;
    bool PowerBankOn;
   

    void Start()
    {
        time = 0;
        inGame = GameObject.Find("In Game Events").GetComponent<InGameEvent>();
        Bar = GameObject.Find("QTE");
        PowerBankMask = GameObject.Find("Mask").GetComponent<Image>();
        animator = GetComponent<Animator>();
        swipeManager = GetComponent<SwipeManager>();
        targetPos = transform.position;
        Bar.SetActive(false);
     
    }

    void Update()
    {
        Ray RightRay = new Ray(transform.position - (transform.forward*0 ), transform.right );
        Ray LeftRay = new Ray(transform.position + (transform.forward * 0), -transform.right);

        if (!swipeUpSpam)
        {
            if (SwipeManager.SwipeUp)
            {
                
                targetPos += Vector3.forward * forwardSpeed;
                SFX.PlaySound("Lompat");
                animator.SetTrigger("Jalan");
                StartCoroutine(SpamUpInput());
                Debug.Log("swipe atas");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                targetPos += Vector3.forward * forwardSpeed;
                SFX.PlaySound("Lompat");
                animator.SetTrigger("Jalan");
                StartCoroutine(SpamUpInput());
                Debug.Log("swipe atas");
            }
        }
        

        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, forwardSpeed * Time.deltaTime);
        if (!swipeRightSpam)
        {
            if (Physics.Raycast(RightRay,out hit, range, layer))
            {

            }
            else
            {
                if (SwipeManager.SwipeRight)
                {
                    desiredLane++;
                    if (desiredLane == 3)
                        desiredLane = 2;
                    animator.SetTrigger("Jalan");
                    StartCoroutine(SpamRightInput());
                    Debug.Log("swipe kanan");
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    desiredLane++;
                    if (desiredLane == 3)
                        desiredLane = 2;
                    animator.SetTrigger("Jalan");
                    StartCoroutine(SpamRightInput());
                    Debug.Log("swipe kanan");
                }
            }

        }
        if (!swipeLeftSpam)
        {
            if(Physics.Raycast(LeftRay, out hit, range, layer))
            {

            }

            else
            {

                if (SwipeManager.swipeLeft)
                {
                    desiredLane--;
                    if (desiredLane == -1)
                        desiredLane = 0;
                    animator.SetTrigger("Jalan");
                    StartCoroutine(SpamLeftInput());
                    Debug.Log("swipe kiri");
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    desiredLane--;
                    if (desiredLane == -1)
                        desiredLane = 0;
                    animator.SetTrigger("Jalan");
                    StartCoroutine(SpamLeftInput());
                    Debug.Log("swipe kiri");
                }

            }


        }
        


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LaneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LaneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);


        time += Time.deltaTime;
        while (time >= interval)
        {
            PowerBoostOn();
            time -= interval;
        }
        Debug.DrawRay(transform.position - (transform.forward*0 ), transform.right*range, Color.yellow);
        Debug.DrawRay(transform.position - (transform.forward * 0), -transform.right * range, Color.yellow);
    }
    public void JalanCepat()
    {
        StartCoroutine(BoostQte());
    }

    public void AnimatorJatuh()
    {
        animator.SetTrigger("Jatuh");
    }



    public void PowerBoostOn()
    {
        
        Bar.SetActive(true);
        CurrentPowerBarValue = 0;
        PowerIsIncreasing = true;
        PowerBankOn = true;
        StartCoroutine(UpdatePowerBan());
    }

    public IEnumerator BoostQte()
    {
        float startTime = Time.time;
        while (Time.time < startTime + BoostTime)
        {
            if (CurrentPowerBarValue>=0 && CurrentPowerBarValue<=29)
            {
                BoostSpeed = 0f;
              
           
                targetPos += Vector3.forward * BoostSpeed * forwardSpeed * Time.deltaTime;
                Debug.Log("Merah1");
                AnimatorJatuh();
            }
            else if (CurrentPowerBarValue >=20&& CurrentPowerBarValue<=40)
            {
                BoostSpeed = 2f;
                targetPos += Vector3.forward * BoostSpeed * forwardSpeed * Time.deltaTime;
                Debug.Log("Kuning");
            }

            else if (CurrentPowerBarValue>=40&&CurrentPowerBarValue<= 66)
            {
                BoostSpeed = 7.5f;
                targetPos += Vector3.forward * BoostSpeed * forwardSpeed * Time.deltaTime;
                Debug.Log("Hijau");
            }
            else if (CurrentPowerBarValue>=66&&CurrentPowerBarValue <=71)
            {
                BoostSpeed = 2f;
                targetPos += Vector3.forward * BoostSpeed * forwardSpeed * Time.deltaTime;
                Debug.Log("Kuning2");
            }

            else if (CurrentPowerBarValue>=71&& CurrentPowerBarValue<= 100)
            {
                BoostSpeed = 0f;
             
                
                targetPos += Vector3.forward * BoostSpeed * forwardSpeed * Time.deltaTime;
                Debug.Log("Merah2");
                AnimatorJatuh();
            }
            yield return null;
        }
    }

    IEnumerator SpamUpInput()
    {
        swipeUpSpam = true;
        yield return new WaitForSeconds(ToSwipe);
        swipeUpSpam = false;
    }

    IEnumerator SpamLeftInput()
    {
        swipeLeftSpam = true;
        yield return new WaitForSeconds(ToSwipeHorizontal);
        swipeLeftSpam = false;
    }

    IEnumerator SpamRightInput()
    {
        swipeRightSpam = true;
        yield return new WaitForSeconds(ToSwipeHorizontal);
        swipeRightSpam = false;
    }

    IEnumerator UpdatePowerBan()
    {
        while (PowerBankOn)
        {
            if (!PowerIsIncreasing)
            {
                CurrentPowerBarValue -= BarChangeSpeed;
                if (CurrentPowerBarValue <= 0)
                {
                    PowerIsIncreasing = true;
                }
            }
            if (PowerIsIncreasing)
            {
                CurrentPowerBarValue += BarChangeSpeed;
                if (CurrentPowerBarValue >= MaxPowerValue)
                {
                    PowerIsIncreasing = false;
                }
            }


            float Fill = CurrentPowerBarValue / MaxPowerValue;
            PowerBankMask.fillAmount = Fill;
            yield return new WaitForSeconds(0.02f);


            if (IsDoubleTap())
            {
               
                PowerBankOn = false;
                Pejet();
                StartCoroutine(TurnOffPowerBar());
                Debug.Log("Touch");
            }
            

            if (Input.GetKeyDown(KeyCode.X))
            {
                PowerBankOn = false;
                Pejet();
                StartCoroutine(TurnOffPowerBar());
                Debug.Log("Touch");
            }
        }
        yield return null;
    }

   

    IEnumerator TurnOffPowerBar()
    {
        yield return new WaitForSeconds(1f);
        Bar.SetActive(false);
    }
    
    public void Pejet()
    {
        JalanCepat();
        Debug.Log("boomn");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="garis finish")
        {
            inGame.Menang();
        }
    }

    public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }
}