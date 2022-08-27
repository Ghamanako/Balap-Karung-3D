using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform finish;
    public float speed;
    public bool _isObstacle=false;
    private bool bergerak;
    private Vector3 jalan;
    public int decision;
    public float chance;
    private float LaneDistance = 2.5f;
    [SerializeField] LayerMask layer;
    private int range;
    public GameObject target;
    private RaycastHit hit;
    private Animator animator;
    
    // Boost QTE
 

    [SerializeField] private float cooldown = 5f;
    private float time;

   
   

    void Start()
    {
       
        range = 3;
        animator = GetComponent<Animator>();
        StartCoroutine(randomAngka());
    }

    void Update()
    {
        decision = Random.Range(1, 3);
       

        leha();
      

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        Ray CenterRay = new Ray(transform.position, transform.forward);
        Ray LeftRay = new Ray(transform.position -(transform.right * 3), transform.forward);
        Ray RightRay = new Ray(transform.position + (transform.right * 3), transform.forward);

        
    
        if (Physics.Raycast(CenterRay, out hit, range, layer))
        {
            
            Debug.Log(hit.point.x);
            _isObstacle = true;
            
            
            if (hit.point.x >= 2.0f  )
            {
                transform.position += Vector3.left * LaneDistance;
                Debug.Log("kiri");
            }
            else if (hit.point.x <= -2.0f  )
            {
                transform.position += Vector3.right * LaneDistance;
               
                Debug.Log("kanan");
            }

            else if (hit.point.x >= -1f && decision == 1)
            {
                transform.position += Vector3.left * LaneDistance;

                Debug.Log("tengah/kiri");
            }
            else if (hit.point.x >= -1f && decision == 2)
            {
                transform.position += Vector3.right * LaneDistance;

                Debug.Log("tengah/kanan");
            }

           

        }

        else if(Physics.Raycast(CenterRay, out hit, range))
        {
            if (hit.point.x >= 1f && hit.transform.tag == "Pisang" && chance >=9)
            {
                transform.position += Vector3.left * LaneDistance;
                Debug.Log("kiri!!!");
                Debug.Log(chance);
            }
            else if (hit.point.x >= -1f && hit.transform.tag == "Pisang" && chance >= 9)
            {
                transform.position += Vector3.left * LaneDistance;
                Debug.Log("kanan!!!");
                Debug.Log(chance);
            }

            if (hit.point.x >= 1f && hit.transform.tag == "air" && chance >= 9)
            {
                transform.position += Vector3.left * LaneDistance;
                Debug.Log("kiri!!!");
                Debug.Log(chance);
            }
            else if (hit.point.x >= -1f && hit.transform.tag == "air" && chance >= 9)
            {
                transform.position += Vector3.left * LaneDistance;
                Debug.Log("kanan!!!");
                Debug.Log(chance);
            }
        }

        Debug.DrawRay(transform.position, transform.forward * range, Color.red);
        Debug.DrawRay(transform.position - (transform.right * 3), transform.forward * range, Color.white);
        Debug.DrawRay(transform.position + (transform.right * 3), transform.forward * range, Color.white);


    }

    public void jatuh()
    {
        animator.SetTrigger("Jatuh");
    }

    public void move()
    {
       

        transform.position = Vector3.MoveTowards(transform.position, finish.position,speed * Time.deltaTime);
       
    }

   public void leha()
    {
        time -= Time.deltaTime;
        if (time > 0) return;

        time = cooldown;
        move();
        SFX.PlaySound("Lompat");
        animator.SetTrigger("Jalan");
    }

    IEnumerator randomAngka()
    {
       while(true)
        {
            chance = Random.Range(1, 11);
            yield return new WaitForSeconds(2);
           
        }
    }
      
   
}

