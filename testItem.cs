using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testItem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.PlayerDie == false)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                
                DataManager.Instance.godmodTimeCurrent = DataManager.Instance.godmodTimeMax;
                gameObject.SetActive(false);
            }
        }
    }
}
