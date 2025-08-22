using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const int enemynum = 8;

    [SerializeField] private Enemy[]enemies = new Enemy[enemynum];

    [SerializeField] private Player player = null;

    public int targeltindex { get; set; } = 0;

    private Enemy[] targets = new Enemy[enemynum]; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
