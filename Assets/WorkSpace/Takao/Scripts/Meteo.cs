using UnityEngine;

// 隕石
public class Meteo : MonoBehaviour
{

    /* 列挙型 */

    private enum State
    {
        Idle,
        Kicked,
        Stopped
    }


    /* 定数 */

    private static readonly float ACCELERATION = 2.0f;


    /* インスペクター */

    // 蹴る前に表示するオブジェクト
    [SerializeField] private Sprite m_spriteBefore;
    // 蹴ったあとに表示するオブジェクト
    [SerializeField] private Sprite m_spriteAfter;

    // 爆発エフェクトのプレファブ
    [SerializeField] private GameObject m_explosionPrefab;

    // 子オブジェクトのスプライトレンダラー
    [SerializeField] private SpriteRenderer m_spriteRenderer;

    // 子オブジェクトのスプライトレンダラー
    [SerializeField] private GamePlayScene m_gamePlayScene;


    /* メンバ変数 */

    // 状態
    State m_state;

    // 速度
    float m_velocity;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        // 蹴ったあとの画像に変更
        m_spriteRenderer.sprite = m_spriteAfter;

        m_velocity = velocity;
        m_state = State.Kicked;
    }

    // 止める
    private void Stop()
    {
        // 蹴る前の画像に変更
        m_spriteRenderer.sprite = m_spriteBefore;

        m_state = State.Stopped;
    }

    // 隕石が止まったか
    public bool IsStopped() { return m_state == State.Stopped; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.position.y > 5.5f)
        {
            return;
        }

        if (m_state == State.Kicked && collision.CompareTag("Planet"))
        {
            Debug.Log("Destroy");
            Instantiate(m_explosionPrefab, collision.transform.position, Quaternion.identity);
            m_gamePlayScene.AddScore(collision.gameObject.GetComponent<planet>().GetScore());
            Destroy(collision.gameObject);
        }
        if (m_state == State.Kicked && collision.CompareTag("Sun"))
        {
            Debug.Log("Destroy");
            Instantiate(m_explosionPrefab, collision.transform.position, Quaternion.identity);
            m_gamePlayScene.AddScore(40);
            Destroy(collision.gameObject);
        }
    }
}
