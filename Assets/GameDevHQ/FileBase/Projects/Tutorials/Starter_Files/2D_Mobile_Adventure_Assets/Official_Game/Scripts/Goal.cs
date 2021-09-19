using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (UIManager.Instance.HasKey())
            {
                UIManager.Instance.Win();
            }
            else
            {
                UIManager.Instance.DisplayObjective();
            }
        }
    }
}
