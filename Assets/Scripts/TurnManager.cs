using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private EnemyObject[] _enemyPrefabs;

    private float m_StartPosX = -1.5f;
    private float m_IncrementPosX = 1f;
    private float m_OffsetPosX;

    private EnemyObject[] m_EnemiesToSpawn;
    private EnemyObject[] m_EnemyData;

    public void Init(int charNumber)
    {
        m_OffsetPosX = m_StartPosX;
        m_EnemiesToSpawn = new EnemyObject[charNumber];
        m_EnemyData = new EnemyObject[charNumber];
        SelectCharactersToSpawn(charNumber);
        SpawnByInititative();
    }

    public void SelectCharactersToSpawn(int charNumber)
    {
        for (int i = 0; i < charNumber; i++)
        {
            EnemyObject character;

            character = _enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Length)];

            character.Init();

            m_EnemiesToSpawn[i] = character;
        }
    }

    public void SpawnByInititative()
    {
        Array.Sort(m_EnemiesToSpawn, (a, b) => { return a.initiative.CompareTo(b.initiative); });

        int index = 0;

        foreach (EnemyObject enemy in m_EnemiesToSpawn)
        {
            EnemyObject newEnemy = Instantiate(enemy, new Vector3(m_OffsetPosX, 0, 0), Quaternion.identity);
            m_EnemyData[index] = newEnemy;
            index++;
            m_OffsetPosX += m_IncrementPosX;
        }
    }

    public void ClearLevel()
    {
        if (m_EnemyData == null) return;

        foreach (EnemyObject enemy in m_EnemyData)
        {
            Destroy(enemy.gameObject);
        }
    }


}
