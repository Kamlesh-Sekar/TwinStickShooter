using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float destroyDuration;

    private Coroutine destroyDelayCoroutine;

    void Start()
    {
        destroyDelayCoroutine = StartCoroutine(DestroyDelay());
    }

    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyDuration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
        {
            StopCoroutine(destroyDelayCoroutine);
            Destroy(gameObject);
        }
    }
}
