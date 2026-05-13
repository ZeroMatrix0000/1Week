using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    // スタートか終わるかを選ぶための変数
    static bool EndGame = false;

    // 効果音
    [SerializeField] private AudioClip m_choose;
    [SerializeField] private AudioClip m_decide;
    [SerializeField] private AudioSource m_audioSource;

    // 三角形の場所の設定
    float MoveTriangl = 2.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (EndGame)
            {
                EndGame = false;
                pos.x = -MoveTriangl;
                transform.position = pos;
                m_audioSource.PlayOneShot(m_choose);
            }
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (!EndGame)
            {
                EndGame = true;
                pos.x = MoveTriangl;
                transform.position = pos;
                m_audioSource.PlayOneShot(m_choose);
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
        if (EndGame)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif         
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
            m_audioSource.PlayOneShot(m_decide);
        }
    }




}
