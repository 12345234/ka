using UnityEngine;
using System.Threading.Tasks;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float sp;

    private float radius = 0.0f;

    private Vector3 movevector = Vector3.zero;

    public float radius_ { get { return radius; } }

    public async void Fire(Vector3 forward)
    {
        movevector = forward.normalized * sp;
        await Move(); 
        if(gameObject)
        {
            Object.Destroy(gameObject);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius = transform.localScale.x * 0.5f;
    }

    private async Task Move()
    {
        var moveTime = 0.0f;

        // 5 •bŠÔˆÚ“®‚·‚é
        while (moveTime < 5.0f && !Application.exitCancellationToken.IsCancellationRequested)
        {
            transform.position += movevector;
            if (GameController.instance.CheckHit(this))
            {
                break;
            }

            moveTime += Time.deltaTime;
            await Task.Yield();
        }
    }
}
