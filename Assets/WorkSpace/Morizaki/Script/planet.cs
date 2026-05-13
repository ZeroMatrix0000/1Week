using UnityEngine;

public class planet : MonoBehaviour
{
    // 回転スピード
    [SerializeField] private float moveSpeed = 0.0f;
    // 太陽のゲームオブジェクト
    GameObject sun;


    // 惑星が止まっているか
    bool m_isStoped;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.sun = GameObject.Find("10_Sun_0");

        m_isStoped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isStoped) return;

        transform.RotateAround(this.sun.transform.position, Vector3.forward, moveSpeed);


    }


    // 惑星が止まっているかどうかを取得
    public void Stop()
    {
        m_isStoped = true;
    }
}
