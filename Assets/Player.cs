using UnityEngine;
using System.Threading.Tasks;
public class Player : MonoBehaviour
{
    [SerializeField] private Transform axis;

    private float rotationangle = 0.5f;

    //  弾
    [SerializeField] private GameObject bulletprefab;

    //カタパルトオブジェクト
    private GameObject catapult;

    //弾オブジェクト
    private Bullet bullet;

    private void FindCatapult()
    {
        catapult = transform.Find("Catapult")?.gameObject;
    }
    private void InstantiateBullet()
    {
        if (bulletprefab != null && catapult != null)
        {
            bullet = Instantiate(bulletprefab, catapult.transform)?.GetComponent<Bullet>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindCatapult();
        InstantiateBullet();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Z))
        {
            //ロックオン 8体
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            if (bullet != null)
            {
                Vector3 correctedForward = Quaternion.Euler(0, -90, 0) * transform.forward;

                bullet.Fire(correctedForward);

                bullet = null;

                LoadBullet();
            }
        }
    }

    private void LateUpdate()
    {
        if (!bullet)
        {
            return;
        }

        GameController.instance.CanHit(bullet);
    }

    private async void LoadBullet()
    {
        await Awaitable.WaitForSecondsAsync(1f);

        InstantiateBullet();
    }

   

    private void FixedUpdate()
    {
        PlayerMove();

        PlayerRotate();
    }

    private void PlayerMove()
    {
        const float scalar = 0.1f;
        var pos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            pos.z += scalar;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pos.z -= scalar;
        }

        transform.position = pos;
    }

    private void PlayerRotate()
    {
        var q = Quaternion.identity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //上旋回
            q = Quaternion.AngleAxis(-rotationangle, axis.forward);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //下旋回
            q = Quaternion.AngleAxis(rotationangle, axis.forward);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左旋回
            q = Quaternion.AngleAxis(-rotationangle, axis.up);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //右旋回
            q = Quaternion.AngleAxis(rotationangle, axis.up);
        }

        transform.rotation = q * transform.rotation;
    }

   
}
