using UnityEngine;
using TMPro;

// TextMeshProUGUIコンポーネントが必須であることを指定
[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowTimer : MonoBehaviour
{
    // タイマーの開始時間（秒）
    public float m_fStartTime;
    // テキストの表示フォーマット（例: "{0:F2}" で小数点2桁表示）
    public string m_strFormat;
    // 経過時間を管理するGameTimerスクリプトの参照
    public GameTimer m_gameTimer;
    
    // テキスト表示用のTextMeshProUGUIコンポーネント
    private TextMeshProUGUI m_txt;

    // 0になったかの判定
    bool m_isZero = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 同じGameObjectのTextMeshProUGUIコンポーネントを取得
        m_txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // 残り時間を計算（0以下にならないようClampで制限）
        float fShowTime = Mathf.Clamp(m_fStartTime - m_gameTimer.CurrentTime, 0f, m_fStartTime);
        // フォーマットに従って残り時間をテキストに反映
        m_txt.text = string.Format(m_strFormat, fShowTime);

        if(fShowTime <= 0f )
        {
            m_isZero = true;
        }
    }

    public bool GetZeroCount() { return m_isZero; }
}
