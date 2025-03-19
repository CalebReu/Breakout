using System.Collections;
using UnityEngine;

public class BrickParticles : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
