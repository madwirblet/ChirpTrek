using UnityEngine;
using System.Collections;

public class BirdFlyAway : MonoBehaviour
{
    public float flyHeight = 5f;
    public float flySpeed = 3f;

    private bool hasFlown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFlown)
        {
            hasFlown = true;
            StartCoroutine(FlyAway());
        }
    }

    IEnumerator FlyAway()
    {
        Vector3 target = transform.position + new Vector3(0, flyHeight, 0);

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                flySpeed * Time.deltaTime
            );

            yield return null;
        }

        Destroy(gameObject);
    }
}