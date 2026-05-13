using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudio : MonoBehaviour
{
    [SerializeField]
    // 爆発音オブジェクト
    private GameObject m_explodeAudioObj;

    // オーディオ
    private AudioSource m_audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 進行処理をコルーチンで開始
        StartCoroutine(ProgressCo());

        // オーディオをキャッシュ
        m_audioSource = m_explodeAudioObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int getSubEmitterParticleNum()
    {
        // パーティクルの合計数
        int ptNum = 0;

        // 自身と子オブジェクト全てのParticleSystemを取得
        ParticleSystem[] psArr = GetComponentsInChildren<ParticleSystem>();
       
        // 各ParticleSystemのパーティクル数を合算
        foreach (ParticleSystem ps in psArr)
        {
            ptNum += ps.particleCount;
        }
        return ptNum;
    }

    // 爆発の進行を管理するコルーチン
    IEnumerator ProgressCo()
    {
      
        // 爆発待ち
        while (getSubEmitterParticleNum() == 0)
        {
            yield return null;
        }
        // ピッチをランダムに変化させて毎回異なる音程で再生
        m_audioSource.pitch *= Random.Range(0.8f, 1.2f);
        // 爆発音を再生
        m_audioSource.Play();

        // 再生が終わるまで待機
        while (m_audioSource.isPlaying)
        {
            yield return null;
        }

        // 消滅待ち
        while (getSubEmitterParticleNum() > 0)
        {
            yield return null;
        }
        // 消滅
        Destroy(gameObject);
    }
}
