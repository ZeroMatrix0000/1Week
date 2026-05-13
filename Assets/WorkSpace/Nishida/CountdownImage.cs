using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownImage : MonoBehaviour
{
    public Image image;
    public CanvasGroup canvasGroup;

    public Sprite[] countdownSprites;


    private bool m_isStart;


    void Start()
    {
        m_isStart = false;

        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        for (int i = 0; i < countdownSprites.Length; i++)
        {
            // スプライトを設定
            image.sprite = countdownSprites[i];
            if (i == 3)
            {
                image.rectTransform.sizeDelta = new Vector2(countdownSprites[i].texture.width, countdownSprites[i].texture.height) / 2f;
            }
            else
            {
                image.rectTransform.sizeDelta = new Vector2(countdownSprites[i].texture.width, countdownSprites[i].texture.height) / 3f;
            }

            // フェードインとフェードアウトを実行
            yield return StartCoroutine(FadeIn());
            yield return new WaitForSeconds(0.3f);
            yield return StartCoroutine(FadeOut());
        }

        // カウントダウンが終了したら、イメージを非表示にする
        image.gameObject.SetActive(false);

        Debug.Log("Game Start!");
        m_isStart = true;
    }

    //フェードイン
    IEnumerator FadeIn()
    {
        for (float t = 0; t < 1; t += Time.deltaTime / 0.3f)
        {
            canvasGroup.alpha = t;
            yield return null;
        }

        canvasGroup.alpha = 1;
    }

    //フェードアウト
    IEnumerator FadeOut()
    {
        for (float t = 1; t > 0; t -= Time.deltaTime / 0.3f)
        {
            canvasGroup.alpha = t;
            yield return null;
        }

        canvasGroup.alpha = 0;
    }


    // ゲーム開始したか
    public bool IsStart()
    {
        return m_isStart;
    }
}