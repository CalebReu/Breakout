using System;
using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject particleSpawner;
    private Coroutine destroyRoutine = null;

    private void OnCollisionEnter(Collision other)
    {
        if (destroyRoutine != null) return;
        if (!other.gameObject.CompareTag("Ball")) return;
        // add sfx here instead of in GameManager so there's no delay (want instant feedback)
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.blockBreakClip);
        }
        destroyRoutine = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // two physics frames to ensure proper collision
        Instantiate(particleSpawner, transform.position, transform.rotation);
        GameManager.Instance.OnBrickDestroyed(transform.position);
        Destroy(gameObject);
    }
}
