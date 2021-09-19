using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint = null;

    private void Start()
    {
        if (!_respawnPoint)
            Debug.LogError(name + ": Respawn Point Transform not assigned!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = _respawnPoint.position;
        }
    }
}
