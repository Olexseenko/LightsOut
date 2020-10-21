using System.Collections;
using UnityEngine;

public class ScreemsControll : MonoBehaviour
{
    public AudioClip[] attackClips;
    public AudioSource audioSource;
    private Coroutine currentCoroutine;


    public void StartScreem()
    {
        StopScreem();

        currentCoroutine = StartCoroutine(ScreemCoroutine());
    }

    public void StopScreem()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
    }

    IEnumerator ScreemCoroutine()
    {
        while (true)
        {
            var nextIn = Random.Range(4, 11);
            yield return new WaitForSeconds(nextIn);

            var index = Random.Range(0, attackClips.Length);

            audioSource.PlayOneShot(attackClips[index]);
        }
    }
}
