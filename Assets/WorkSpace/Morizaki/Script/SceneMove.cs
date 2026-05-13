using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    // スタートか終わるかを選ぶための変数
    static bool EndGame = false;

    // 三角形の場所の設定
    float MoveTriangl = 3.7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (EndGame)
            {
                EndGame = false;
                pos.x = -MoveTriangl;
                transform.position = pos;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!EndGame)
            {
                EndGame = true;
                pos.x = MoveTriangl;
                transform.position = pos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveSceneSelect();
        }
    }

    // シーン移動するための関数
    void MoveSceneSelect()
    {
        if(EndGame)
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
        }
    }




}
