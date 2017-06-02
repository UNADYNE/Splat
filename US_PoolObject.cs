using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_PoolObject : MonoBehaviour
{
    public float despawnDelay;

    private void OnEnable()
    {
        StartCoroutine(Despawn(despawnDelay));
    }

    public IEnumerator Despawn(float despawnTimer)
    {
        yield return new WaitForSeconds(despawnTimer);
        gameObject.SetActive(false);
    }
}
