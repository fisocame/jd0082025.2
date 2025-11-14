using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    // Singleton para evitar Players duplicados
    private static Spawn Instance;

    // Nome do spawn que a próxima cena deve usar (setado pela porta)
    public static string NextSpawnName;

    [Tooltip("Nome do spawn padrão desta cena (caso nenhum seja pedido).")]
    public string defaultSpawnName = "default";

    [Tooltip("Se marcado, mantém o Player entre cenas (e reposiciona no load).")]
    public bool makePersistent = false;

    void Awake()
    {
        // Se já existe um Player "oficial", destruímos este (o recém-carregado)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Este vira o Player oficial
        Instance = this;

        // Mantém entre cenas, se configurado
        if (makePersistent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        // (Opcional) se este for o oficial e for destruído manualmente, libere a instância
        if (Instance == this) Instance = null;
    }

    void Start()
    {
        // Se o Player NÃO for persistente (instanciado por cena), Start já resolve.
        TryApplySpawn();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Se o Player for persistente, reposiciona quando a cena terminar de carregar.
        // E mesmo que não seja, esse evento ajuda a garantir o posicionamento.
        if (Instance == this)
            TryApplySpawn();
    }

    void TryApplySpawn()
    {
        string nameToUse = !string.IsNullOrEmpty(NextSpawnName) ? NextSpawnName : defaultSpawnName;

        GameObject target = GameObject.Find(nameToUse);
        if (target != null)
        {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
            NextSpawnName = null; // limpa para não vazar
        }
        else
        {
            Debug.LogWarning(
                $"[PlayerSpawn2D] Spawn '{nameToUse}' não encontrado na cena '{SceneManager.GetActiveScene().name}'. " +
                $"Crie um Empty com esse NOME ou ajuste 'defaultSpawnName'."
            );

            // oi!
        }
    }
}