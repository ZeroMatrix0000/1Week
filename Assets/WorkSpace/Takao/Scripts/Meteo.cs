using UnityEngine;

// 隕石
public class Meteo : MonoBehaviour
{
    /* 列挙型 */

    enum State
    {
        Idle,
        Kicked,
        Stopped
    }

    /* 定数 */

    private static readonly float ACCELERATION = 2.0f;

    /* インスペクター */

    // 蹴る前に表示するオブジェクト
    [SerializeField] private GameObject m_objectBefore;
    // 蹴ったあとに表示するオブジェクト
    [SerializeField] private GameObject m_objectAfter;

    /* メンバ変数 */

    // 状態
    State m_state;

    // 速度
    float m_velocity;

    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 蹴る前の画像を表示
        m_objectBefore.SetActive(true);
        m_objectAfter.SetActive(false);

        m_state = State.Idle;
        m_velocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 蹴られたあとなら
        if (m_state == State.Kicked)
        {
            // 減速
            m_velocity -= ACCELERATION * Time.deltaTime;
            if (m_velocity < 0f)
            {
                Stop();
            }

            // 位置に速度を足す
            transform.Translate(0f, m_velocity * Time.deltaTime, 0f, Space.World);
        }
    }

    // 蹴られる
    public void Kicked(float velocity)
    {
        // 蹴ったあとの画像を表示
        m_objectBefore.SetActive(false);
        m_objectAfter.SetActive(true);

        m_velocity = velocity;
        m_state = State.Kicked;
    }

    // 止める
    private void Stop()
    {
        // 蹴る前の画像を表示
        m_objectBefore.SetActive(true);
        m_objectAfter.SetActive(false);

        m_state = State.Stopped;
    }
}
