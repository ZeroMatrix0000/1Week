using UnityEngine;

public class planet : MonoBehaviour
{
    // 回転スピード
    [SerializeField] private float moveSpeed = 0.0f;
    // 太陽のゲームオブジェクト
    GameObject sun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.sun = GameObject.Find("10_Sun_0");
    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(this.sun.transform.position, Vector3.forward, moveSpeed);

       
    }

    
}
