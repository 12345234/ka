using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance_;
    private GameObject enemy;

    public static GameController instance
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = FindFirstObjectByType<GameController>();

                if (instance_ == null)
                {
                    var obj = new GameObject("GameController");
                    instance_ = obj.AddComponent<GameController>();
                }
            }
            return instance_;
        }
    }

    private void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this;
        }
        else if (instance_ != this)
        {
            Destroy(gameObject);
        }

        CreateEnemy();
    }

    public void CanHit(Bullet bullet)
    {
        if (!enemy) return;

        var playerToEnemy = enemy.transform.position - bullet.transform.position;
        var dot = Vector3.Dot(bullet.transform.forward, playerToEnemy);
        var nearPos = bullet.transform.position + bullet.transform.forward * dot;

        var size = bullet.radius_ + (enemy.transform.localScale.x * 0.5f);

        if (Vector3.Distance(enemy.transform.position, nearPos) < size)
        {
            enemy.GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
        else
        {
            enemy.GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
    }

    public bool CheckHit(Bullet bullet)
    {
        if (!enemy) return false;

        var size = bullet.radius_ + (enemy.transform.localScale.x * 0.5f);

        if (Vector3.Distance(enemy.transform.position, bullet.transform.position) < size)
        {
            ResetEnemy();
            return true;
        }

        return false;
    }

    public async void ResetEnemy()
    {
        if (enemy)
        {
            Destroy(enemy);
            enemy = null;
        }

        await Awaitable.WaitForSecondsAsync(1f);

        CreateEnemy();
    }

    public void CreateEnemy()
    {
        if (enemy == null)
        {
            enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            enemy.transform.position = new Vector3(0, 0, 12);
            enemy.transform.localScale = Vector3.one;
        }
    }
}
