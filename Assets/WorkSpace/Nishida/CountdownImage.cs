using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownImage : MonoBehaviour
{
    public Image image;
    public CanvasGroup canvasGroup;

    public Sprite[] countdownSprites;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        for (int i = 0; i < countdownSprites.Length; i++)
        {
            // スプライトを設定
            image.sprite = countdownSprites[i];

            // フェードインとフェードアウトを実行
            yield return StartCoroutine(FadeIn());
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(FadeOut());
        }

        // カウントダウンが終了したら、イメージを非表示にする
        image.gameObject.SetActive(false);

        Debug.Log("Game Start!");
    }

    //フェードイン
    IEnumerator FadeIn()
    {
        for (float t = 0; t < 1; t += Time.deltaTime * 2)
        {
            canvasGroup.alpha = t;
            yield return null;
        }

        canvasGroup.alpha = 1;
    }

    //フェードアウト
    IEnumerator FadeOut()
    {
        for (float t = 1; t > 0; t -= Time.deltaTime * 2)
        {
            canvasGroup.alpha = t;
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}