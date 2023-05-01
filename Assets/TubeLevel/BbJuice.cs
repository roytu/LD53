using UnityEngine;

public class BbJuice : MonoBehaviour
{
    public SpriteRenderer counter;
    public Sprite[] digitSprites;
    private int savedNum = 0;
    public ParticleSystem effect;

    public void SetNum(int num)
    {
        if (num == savedNum)
        {
            return;
        }

        savedNum = num;
        gameObject.SetActive(true);
        if (num >= 1 && num <= 5)
        {
            counter.sprite = digitSprites[num - 1];
            effect.Play();
        }
    }
}
