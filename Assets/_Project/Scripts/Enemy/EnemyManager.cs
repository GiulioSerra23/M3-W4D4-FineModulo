using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    public static EnemyManager Instance { get; private set; }   // Ho fatto l'instanza perchè è più comodo richiamare le funzioni di EnemyManager da altre classi, 
                                                                // e così non ho bisogno di fare FindObjectOfType e appesantire il codice
    public List<Enemy> Enemies => _enemies;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy); 
    }

    public void RemoveEnemy(Enemy enemy) 
    {
        _enemies.Remove(enemy);
    }
}
