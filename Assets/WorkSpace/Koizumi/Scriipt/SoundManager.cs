using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    // 破壊しない判定
    public bool m_dontDestroyEnabled = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (m_dontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
