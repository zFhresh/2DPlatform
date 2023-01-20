using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Stats")] 
    [SerializeField]int Heal;
    [SerializeField] float AttackDamage;
    [SerializeField]float Speed,JumpForce;
    Rigidbody2D  rb;
    Animator anim;
    [SerializeField]BoxCollider2D SlideCollider , NormalCollider;
    [SerializeField] VoiceManager VoiceManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    bool isCanJump = true,isSlide=false;
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        SetAnimations(h,v);
        Raycast();
        transform.position += (new Vector3(h * Speed * Time.deltaTime ,0,0));
        Controls(h,v);
    }



    void Controls(float h , float v) {
        if(v > 0 && isCanJump) {
            rb.AddForce(Vector2.up * JumpForce);
            raycastBlock = true;
            anim.SetBool("jump",true);
            Invoke("RaycastUnBlock",0.2f);
            isCanJump = false;
        }
        if((h > 0 || h < 0)&& Input.GetKey(KeyCode.LeftControl)) {
            SlideCollider.enabled = true;
            NormalCollider.enabled = false;
            anim.SetBool("Slide",true);
            isSlide = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl)) {
            SlideCollider.enabled = false;
            NormalCollider.enabled = true;
            anim.SetBool("Slide",false);
            isSlide = false;
        }
    }

    void SetAnimations(float h , float v) {
        anim.SetFloat("Speed",h);
        if(h > 0 || h < 0) {
            Debug.Log("Ses Çalıştı");
            VoiceManager.PlayASoundLoop(0);
        }
        else {
            VoiceManager.StopSound();
        }
        if(h < 0) {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else if(h > 0 ) {
            transform.rotation = Quaternion.identity;
        }
    }
    bool raycastBlock = false;
    void RaycastHitSomething(RaycastHit2D hit) {
        if(!raycastBlock) {
             isCanJump = true;
             anim.SetBool("jump",false);
        }
    }
    public void RaycastUnBlock() {
        raycastBlock = false;
    }
   [SerializeField] LayerMask Mask;
    public void Raycast() {
         RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,1f,Mask);
        if (hit.collider != null)
        {
            RaycastHitSomething(hit);
        }
        Debug.DrawLine(transform.position,-Vector2.up * 10,Color.blue);
    }
}
