using UnityEngine;
using UnityEngine.InputSystem;

// ゲームプレイシーン
public class GamePlayScene : MonoBehaviour
{

    /* インスペクター */

    // プレイヤー
    [SerializeField] private Player m_player;
    // 隕石
    [SerializeField] private Meteo m_meteo;

    /* メンバ変数 */

    private bool m_isKicked;

    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_isKicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        /* テスト */

        // Spaceでボールを蹴る
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !m_isKicked)
        {
            m_player.Kick();
            m_meteo.Kicked(5.0f);
            m_isKicked = true;
        }
    }

}
