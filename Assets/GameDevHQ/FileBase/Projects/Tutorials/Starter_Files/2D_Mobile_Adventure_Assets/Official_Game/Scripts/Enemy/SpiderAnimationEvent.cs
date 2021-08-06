using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;

    private void Start()
    {
        _spider = GetComponentInParent<Spider>();
        if (!_spider)
            Debug.Log(name + ": Spdier script not found in parent!");
    }

    public void Fire()
    {
        _spider.Fire();
    }
}
