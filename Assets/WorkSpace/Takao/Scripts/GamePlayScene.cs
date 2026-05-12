using UnityEngine;
using UnityEngine.InputSystem;

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

    /* メンバ変数 */

    // 状態
    private State m_state;

    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_state = State.Kick;
    }

    // Update is called once per frame
    void Update()
    {
        // 状態ごとに更新
        switch (m_state)
        {
            case State.CountDown:
                break;
            case State.Charge:
                break;
            case State.Kick:
                UpdateKick();
                break;
            case State.Kicked:
                UpdateKicked();
                break;
            case State.Result:
                break;
        }

        /* テスト */

    }

    // キックするときの更新処理
    private void UpdateKick()
    {
        // Spaceでボールを蹴る
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            m_player.Kick();
            m_meteo.Kicked(5.0f);
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
        }
    }
}
