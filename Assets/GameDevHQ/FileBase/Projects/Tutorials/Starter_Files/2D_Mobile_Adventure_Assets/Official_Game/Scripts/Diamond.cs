using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] int _value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.AddDiamonds(_value);
                Destroy(gameObject);
            }
        }
    }

    public void AssignValue(int value)
    {
        _value = value;
    }
}
