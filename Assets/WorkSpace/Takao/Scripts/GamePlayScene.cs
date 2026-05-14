using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// ゲームプレイシーン
public class GamePlayScene : MonoBehaviour
{

    /* 列挙型 */

    private enum State
    {
        CountDown,
        Charge,
        Kick,
        Kicked,
        Result
    }


    /* インスペクター */

    // プレイヤー
    [SerializeField] private Player m_player;
    // 隕石
    [SerializeField] private Meteo m_meteo;
    // 惑星
    [SerializeField] private planet[] m_planets;
    // タイマー
    [SerializeField] private ShowTimer m_showTimer;
    // パワーゲージ
    [SerializeField] private PowerGauge m_powerGauge;
    // カウントダウン
    [SerializeField] private CountdownImage m_countDown;
    //-----追加変数(リザルト)西田-----//
    // リザルト
    [SerializeField] private Result m_result;
    /* メンバ変数 */

    // 状態
    private State m_state;

    // 得点
    int m_score;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_state = State.CountDown;
    }

    // Update is called once per frame
    void Update()
    {
        // 状態ごとに更新
        switch (m_state)
        {
            case State.CountDown:
                UpdateCountDown();
                break;
            case State.Charge:
                UpdateCharge();
                break;
            case State.Kick:
                UpdateKick();
                break;
            case State.Kicked:
                UpdateKicked();
                break;
            case State.Result:
                UpdateResult();
                break;
        }

        /* テスト */

    }

    // 得点を追加
    public void AddScore(int score)
    {
        m_score += score;
    }

    // 得点を取得
    public int GetScore()
    {
        return m_score;
    }

    // カウントダウン中の処理
    private void UpdateCountDown()
    {
        // タイマーが0になったら蹴るフェーズに遷移
        if (m_countDown.IsStart())
        {
            m_state = State.Charge;
            m_showTimer.Activate();
        }
    }

    // チャージするときの更新処理
    private void UpdateCharge()
    {
        // タイマーが0になったら蹴るフェーズに遷移
        if (!m_showTimer.IsActive())
        {
            m_state = State.Kick;
        }
    }

    // キックするときの更新処理
    private void UpdateKick()
    {
        // Spaceでボールを蹴る
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            m_player.Kick();
            m_meteo.Kicked(m_powerGauge.GetPower() / 8.0f);
            foreach (var planet in m_planets)
            {
                planet.Stop();
            }
            m_state = State.Kicked;
        }
    }

    // キックしたあとの更新処理
    private void UpdateKicked()
    {
        // Spaceでボールを蹴る
        if (m_meteo.IsStopped())
        {
            m_state = State.Result;

            m_result.gameObject.SetActive(true);
        
            // スコア渡す
            m_result.SetScore(m_score);
        }
    }

    // 成績表示時の更新処理
    private void UpdateResult()
    {
        //Debug.Log(m_score);
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("TitleScene");
        }
        //ここにリザルトのアップデートを呼ぶ
            //m_result.Update();
    }
}
