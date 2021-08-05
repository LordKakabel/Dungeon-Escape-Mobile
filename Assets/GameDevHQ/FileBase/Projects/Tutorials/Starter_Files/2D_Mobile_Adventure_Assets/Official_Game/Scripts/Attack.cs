using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _swingReset = 0.5f;

    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (_canDamage)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(SwingTimerCoroutine());
            }
        }
    }

    private IEnumerator SwingTimerCoroutine()
    {
        yield return new WaitForSeconds(_swingReset);
        _canDamage = true;
    }
}
