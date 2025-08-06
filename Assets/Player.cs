using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float sp;
    [SerializeField] private GameObject baret;
    [SerializeField] private GameObject target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //前進
        }
        else if(Input.GetKey(KeyCode.S))
        {
            //後退
        }

        if(Input.GetKey(KeyCode.Z))
        {
            //ロックオン 8体
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            //弾発射
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            //上旋回
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //下旋回
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左旋回
        }
        else if (!Input.GetKey(KeyCode.RightArrow))
        {
            //右旋回
        }
    }
}
