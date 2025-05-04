using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI controlModeText;
    [SerializeField] private TextMeshProUGUI eggCountText;
    [SerializeField] private TextMeshProUGUI enemyCountText;
    [SerializeField] private TextMeshProUGUI enemiesDestroyedText;
    [SerializeField] private TextMeshProUGUI touchedEnemyText;

    private string controlMode = "Mouse";
    private int touchedEnemies = 0;
    private int eggCount = 0;
    private int enemyCount = 0;
    private int enemiesDestroyed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        controlModeText.text = "HERO: drive(" + controlMode + ")";
        touchedEnemyText.text = "Touched Enemy(" + touchedEnemies + ")";
        eggCountText.text = "EGGS On Screen(" + eggCount + ")";
        enemyCountText.text = "ENEMY: Count(" + enemyCount + ")";
        enemiesDestroyedText.text = "Destroyed(" + enemiesDestroyed + ")";
    }
    public void SetControlMode(bool useMouse)
    {
        controlMode = useMouse ? "Mouse" : "Keyboard";
        UpdateUI();
    }
    public void AddTouchedEnemy()   
    {
        touchedEnemies++;
        UpdateUI();
    }
    public void AddEggCount()
    {
        eggCount++;
        UpdateUI();
    }
    public void RemoveEggCount()
    {
        eggCount = Mathf.Max(0, eggCount - 1);
        UpdateUI();
    }
    public void SetEnemyCount(int count)
    {
        enemyCount = count;
        UpdateUI();
    }
    public void AddEnemiesDestroyed()
    {
        enemiesDestroyed++;
        UpdateUI();
    }
}
