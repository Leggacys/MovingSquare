using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillonDelay : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
