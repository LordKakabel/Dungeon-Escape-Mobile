using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _duration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IDamageable hit = collision.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(gameObject);
            }
        }
    }
}
