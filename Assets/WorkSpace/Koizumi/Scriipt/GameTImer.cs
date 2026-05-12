using UnityEngine;

public class GameTimer : MonoBehaviour
{
    // 経過時間（秒）
    private float m_fTimer;
    // 経過時間を外部から取得するためのプロパティ（読み取り専用）
    public float CurrentTime { get { return m_fTimer; } }
    // タイマーが動作中かどうかのフラグ
    public bool m_bActive = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        // タイマーが有効なときのみ経過時間を加算
        if (m_bActive)
        {
            // 前フレームからの経過時間を加算
            m_fTimer += Time.deltaTime;
        }
    }

    // タイマーを開始する
    public void OnStart()
    {
        m_bActive = true;
    }
    // タイマーを停止する
    public void OnStop()
    {
        m_bActive = false;
    }
    // タイマーをリセットして停止する
    public void OnReset()
    {
        m_fTimer = 0f;
        OnStop();
    }
}
