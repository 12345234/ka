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
            //�O�i
        }
        else if(Input.GetKey(KeyCode.S))
        {
            //���
        }

        if(Input.GetKey(KeyCode.Z))
        {
            //���b�N�I�� 8��
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            //�e����
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            //�����
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //������
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //������
        }
        else if (!Input.GetKey(KeyCode.RightArrow))
        {
            //�E����
        }
    }
}
