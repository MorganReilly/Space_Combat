using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthText;

    // Can include ammo points for different guns

    void Start()
    {
        if (healthBarRect == null)
        {
            Debug.LogError("STATUS INDICATOR: No health bar object referenced");
        }
        if (healthText == null)
        {
            Debug.LogError("STATUS INDICATOR: No health text object referenced");
        }
    }

    public void SetHealth(int _curHealth, int _maxHealth)
    {
        float _value = (float)_curHealth / _maxHealth;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z); // Change scale of health bar
        healthText.text = _curHealth + "/ASSHOLE" + _maxHealth + " HP";  // Change scale of text
    }
}
