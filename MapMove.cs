using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public GameObject[] ItemSet;
    public float mapSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        for(int temp=0;temp<ItemSet.Length;temp++)
        {
            ItemSet[temp].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!DataManager.Instance.PlayerDie)
        {
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
    }
}
