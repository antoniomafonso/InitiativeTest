using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int _numberEnemies = 4;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private UIDocument _uiDoc;

    private Button m_RestartButton;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        m_RestartButton = _uiDoc.rootVisualElement.Q<Button>("RestartButton");
        m_RestartButton.clickable.clicked += () =>
        {
            StartNewGame();
        };
        StartNewGame();
    }

    void StartNewGame()
    {
        _turnManager.ClearLevel();
        _turnManager.Init(_numberEnemies);
    }
}
