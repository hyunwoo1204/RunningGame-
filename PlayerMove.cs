using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float jump = 10f;
    public float jump2 = 12f;
    public Animator _ani;



    int jumpCount = 0;

    public void PlayerAni_Run()
    {
        _ani.SetInteger("State", 0);
    }

    public void PlayerAni_Jump()
    {
        
        _ani.SetInteger("State", 1);
    }

    public void PlayerAni_Die()
    {

        _ani.SetInteger("State", 3);
    }


    public void PlayerAni_Hit()
    {
        _ani.SetInteger("State", 2);
    }

    

    public void Button()
    {
        if (!DataManager.Instance.PlayerDie)
        {
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount += 1;
                PlayerAni_Jump();
            }
            else if (jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                jumpCount += 1;
  
            }
        }
    }
    
      private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag.CompareTo("Block") != 0)
        {
            if (collision.gameObject.tag.CompareTo("Land") == 0)
            {
                jumpCount = 0;
                PlayerAni_Run();
            }
        }

             if (collision.gameObject.tag.CompareTo("Block") == 0)
             {
                SoundManager.Instance.PlaySound("Hit");
                 DataManager.Instance.playTimeCurrent -= 1f;
                  collision.gameObject.SetActive(false);
                   //PlayerAni_Run();
                  PlayerAni_Hit();
             }

        if(DataManager.Instance.playTimeCurrent<0)
            PlayerAni_Die();



    }

    }
    

