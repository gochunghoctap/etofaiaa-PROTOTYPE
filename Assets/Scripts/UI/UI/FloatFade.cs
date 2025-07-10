using UnityEngine;

public class FloatFade : MonoBehaviour
{
    public float interval = 2f; // 表示の間隔
    public float fadeSpeed = 1f; // フェードの速さ
    private SpriteRenderer spriteRenderer;
    private bool fadingIn = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
    }

    void Update()
    {
        Color color = spriteRenderer.color;

        if (fadingIn)
        {
            color.a += Time.deltaTime * fadeSpeed;
            if (color.a >= 1f)
            {
                color.a = 1f;
                fadingIn = false;
                Invoke(nameof(StartFadeOut), interval);
            }
        }

        spriteRenderer.color = color;
    }

    void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    System.Collections.IEnumerator FadeOut()
    {
        while (spriteRenderer.color.a > 0)
        {
            Color color = spriteRenderer.color;
            color.a -= Time.deltaTime * fadeSpeed;
            spriteRenderer.color = color;
            yield return null;
        }

        // 少し待ってからまたフェードインを開始
        yield return new WaitForSeconds(interval);
        fadingIn = true;
    }
}