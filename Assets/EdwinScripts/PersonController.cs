using System.Collections;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public Sprite[] hitAnimationSprites;
    public float animationFrameDuration = 0.2f;
    public AudioClip hitSound;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitAnimationAndSound()
    {
        StartCoroutine(PlayHitAnimationCoroutine());
        PlayHitSound();
    }

    private IEnumerator PlayHitAnimationCoroutine()
    {
        foreach (Sprite sprite in hitAnimationSprites)
        {
            spriteRenderer.sprite = sprite;
            yield return new WaitForSeconds(animationFrameDuration);
        }
    }

    private void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}
