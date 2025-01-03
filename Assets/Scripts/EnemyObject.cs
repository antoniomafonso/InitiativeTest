using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _baseDmg = 2;
    [SerializeField] private int _challengeLevel = 2;
    [SerializeField] private int _speed = 2;

    public int initiative;

    public void Init()
    {
        initiative = _challengeLevel * _speed;
    }

}

