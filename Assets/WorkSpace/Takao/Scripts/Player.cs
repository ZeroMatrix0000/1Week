using UnityEngine;

public class Player : MonoBehaviour
{

    /* インスペクター */

    // 蹴る前のスプライト
    [SerializeField] private Sprite m_spriteBefore;
    // 蹴ったあとのスプライト
    [SerializeField] private Sprite m_spriteAfter;


    /* コンポーネント */

    private SpriteRenderer m_spriteRenderer;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 蹴る
    public void Kick()
    {
        m_spriteRenderer.sprite = m_spriteAfter;
        GetComponent<AudioSource>().Play();
    }

}
