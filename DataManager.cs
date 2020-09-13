using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;
    public bool PlayerDie = false;
    public float playTimeCurrent = 10f;
    public float playTimeMax = 10f;
    public float margnetTimeCurrent = 0f;
    public float margnetTimeMax = 3f;

    public float godmodTimeCurrent = 0f;
    public float godmodTimeMax = 5f; 

    public float itemMoveSpeed = 15f;
    public int stage = 0;
    public int stageView = 0;
    public bool godmod = false;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {

        if(instance==null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Start is called before the first frame update
    public int score = 0;
}
