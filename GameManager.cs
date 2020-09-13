using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject[] NumberImage;
    public Sprite[] Number;
    public Image TimeBar;
    public GameObject EndPanel;
    public GameObject PausePanel;
    public GameObject[] StageMap;
    public GameObject LoadMap;
    public GameObject godmoditem;
    public GameObject margnetitem;
    public Text StageText;
    public GameObject BG_1;
    public GameObject BG_2;
    public AudioSource BGM;

    bool BG_flag = false;
    bool IsPause = false;

    public Animator _ani;


    public void Load_Map()
    {
        LoadMap.transform.position = new Vector3(15f, LoadMap.transform.position.y, LoadMap.transform.position.z);
        LoadMap.SetActive(true);
    }

    public void Next_Stage()
    {
        DataManager.Instance.stage += 1;
        DataManager.Instance.stageView += 1;
        if(!BG_flag)
        {
            BG_1.SetActive(true);
            BG_2.SetActive(false);
            BG_flag = true;
        }
        else
        {
            BG_1.SetActive(false);
            BG_2.SetActive(true);
            BG_flag = false;
        }
        if(DataManager.Instance.stage>StageMap.Length)
        {
            DataManager.Instance.stage = DataManager.Instance.stage % StageMap.Length;
            if(DataManager.Instance.stage==0)
            {
                DataManager.Instance.stage = StageMap.Length;
            }
        }
        StageStart();
    }
    
    public void StageStart()
    {
        for (int temp = 1; temp <= StageMap.Length; temp++)
        {
            if(temp==DataManager.Instance.stage)
            {
                StageMap[temp - 1].transform.position = new Vector3(15f, StageMap[temp - 1].transform.position.y, StageMap[temp - 1].transform.position.z);
                StageMap[temp - 1].SetActive(true);
            }
            else
            {
                StageMap[temp - 1].SetActive(false);
            }
        }
   
    }

  /*  public void PlayerAni_Die()
    {
        _ani.SetInteger("State", 2);
    }*/


    public void Restart_Btn()
    {
         SoundManager.Instance.PlaySound("BG");
        DataManager.Instance.stage = 0;
        DataManager.Instance.stageView = 0;
        DataManager.Instance.score = 0;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
        DataManager.Instance.margnetTimeCurrent = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void Pause_Btn()
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;
            IsPause = true;
            //SoundManager.Instance.StopAllSound();
            BGM.Pause();
            PausePanel.SetActive(true);
            return;
        }
        if (IsPause == true)
        {
            Time.timeScale = 1;
            IsPause = false;
            // SoundManager.Instance.PlaySound("BG");
            BGM.Play();
            PausePanel.SetActive(false);
            return;
        }
    }

    public void MainMenuButton_Btn()
    {
        DataManager.Instance.stage = 0;
        DataManager.Instance.stageView = 0;
        DataManager.Instance.score = 0;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
        DataManager.Instance.margnetTimeCurrent = 0;
        SceneManager.LoadScene("MainMenu");
    }
    private void Update()
    {
        if (DataManager.Instance.stageView == 0)
        {
            StageText.text = "START";
        }
        else
            StageText.text = "Stage" + DataManager.Instance.stageView.ToString();


        if(!DataManager.Instance.PlayerDie)
        {
            if(DataManager.Instance.playTimeCurrent<0)
            {
              
                DataManager.Instance.PlayerDie = true;
               
            }
        }

        if (DataManager.Instance.godmodTimeCurrent > 0)
        {
            DataManager.Instance.godmod = true;
        }

        if(DataManager.Instance.godmod == true)
        {
            godmoditem.SetActive(true);
        }

        if (DataManager.Instance.godmod == false)
        {
            godmoditem.SetActive(false);
        }

        if (DataManager.Instance.godmodTimeCurrent < 0)
        {
            DataManager.Instance.godmod = false;
        }

        if (DataManager.Instance.PlayerDie==true)
        {
            SoundManager.Instance.StopSound("BG");
        }


        int temp = DataManager.Instance.score / 100;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp];
        int temp2 = DataManager.Instance.score % 100;
        temp2 = temp2 / 10;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp2];
        int temp3 = DataManager.Instance.score % 10;
        NumberImage[2].GetComponent < Image>().sprite = Number[temp3];

        if(!DataManager.Instance.PlayerDie)
        {
            if(DataManager.Instance.godmod==false)
            DataManager.Instance.playTimeCurrent -= 0.5f * Time.deltaTime;

            

            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;
            if(DataManager.Instance.playTimeCurrent<0)
            {
                DataManager.Instance.PlayerDie = true;
            }
        }

        if(DataManager.Instance.playTimeCurrent<0)
        {
            DataManager.Instance.PlayerDie = true;
        }

        if(DataManager.Instance.margnetTimeCurrent>0)
        {
            DataManager.Instance.margnetTimeCurrent -= 1 * Time.deltaTime;
        }
        if(DataManager.Instance.margnetTimeCurrent > 0)
        {
            margnetitem.SetActive(true);
        }

        if (DataManager.Instance.margnetTimeCurrent < 0)
        {
            margnetitem.SetActive(false);
        }

        if (DataManager.Instance.godmodTimeCurrent > 0)
        {
            DataManager.Instance.godmodTimeCurrent -= 1 * Time.deltaTime;
        }



        if (DataManager.Instance.PlayerDie==true)
        {

           // PlayerAni_Die();
            EndPanel.SetActive(true);
            
        }
    }

}
