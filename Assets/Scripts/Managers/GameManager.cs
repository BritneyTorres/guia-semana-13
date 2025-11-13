/// <summary>
/// Clase de lógica pura que gestiona el estado de los objetivos
/// No hereda de MonoBehaviour, por lo que puede ser testeada fácilmente
/// </summary>
public class GameManager: MonoBehaviour
{
    // Singleton Pattern
    public static GameManager Instance { get; private set; }

    public enum GameState { Playing, Victory, Loss }

    private GameState _currentState;

    [Header("Gameplay Settings")]

    [SerializeField] private int _objectivesToWin = 3;

    public GameLogic Logic { get; private set; } // Propiedad pública para acceder a la lógica

    private void Awake()
    {
        // Configuración del Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // opcional:
        // DontDestroyOnLoad(gameObject);
        // si necesitas que persista entre escenas
        Logic = new GameLogic(_objectivesToWin); // Instanciamos nuestra lógica

        private void HandleObjectiveActivated()
        {
            if (_currentState != GameState.Playing) return;

            Logic.CompleteObjective();
            Debug.Log($"Objetivo completado. Progreso: {Logic.ObjetivesCompleted}/{Logic.ObjectivesTowin}");

            if (Logic.IsVictoryConditionMet)
            {
                ChangeState(GameState.Victory);
            }
        }
}
}