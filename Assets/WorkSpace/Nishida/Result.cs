using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // スタートか終わるかを選ぶための変数
    static bool ReStart = false;

    // 効果音
    [SerializeField] private AudioClip m_choose;
    [SerializeField] private AudioClip m_decide;

    // 三角形の場所の設定
    [SerializeField] private GameObject m_triangle;
    float MoveTriangl = 2.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_triangle.SetActive(true);
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 pos = transform.position;

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (ReStart)
            {
                ReStart = false;
                pos.x = -MoveTriangl;
                transform.position = pos;
                SoundManager.instance.PlayOneShot(m_choose);
            }
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (!ReStart)
            {
                ReStart = true;
                pos.x = MoveTriangl;
                transform.position = pos;
                SoundManager.instance.PlayOneShot(m_choose);
            }
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            MoveSceneSelect();
        }
    }

    // シーン移動するための関数
    void MoveSceneSelect()
    {
        if (!ReStart)
        {
            ReStart = true;
            SceneManager.LoadScene("SampleScene");
            SoundManager.instance.PlayOneShot(m_decide);
        }
        else
        {
            SceneManager.LoadScene("TitleScene");
            SoundManager.instance.PlayOneShot(m_decide);
        }
    }
}
