using UnityEngine;
using TMPro;
using UnityEngine.UI;

class HPOwner : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] TMP_Text textComponnet;
    [SerializeField] Image healthImage;
    [SerializeField] Collider hudCollider;
    [SerializeField] Rigidbody hudBody;
    [SerializeField] LookAt hudLookAt;

    [SerializeField] Color maxHPColor = Color.green, minHPColor = Color.red;
    [SerializeField] GameManager gameManager;

    [SerializeField] Behaviour objectToTurnOffOnDeath;

    void OnValidate()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    int currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateUI();

    }

    public void Damage(int damage)
    {
        if (currentHP == 0)
            return;


        currentHP = Mathf.Max(currentHP - damage, 0);

        if (currentHP == 0)
        {
            gameManager.GameOver();

            if (objectToTurnOffOnDeath != null)
            {
                objectToTurnOffOnDeath.enabled = false;
            }

            if (hudCollider != null)
                hudCollider.enabled = true;

            if (hudBody != null) 
            {
                hudBody.isKinematic = false; 
                Debug.Log("");
            }

            if (hudLookAt != null)
                hudLookAt.enabled = false;

        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (textComponnet != null)
        {
            textComponnet.color = Color.Lerp(minHPColor, maxHPColor, (float)currentHP / maxHP);

            textComponnet.text = "HP: " + currentHP;
        }

        if (healthImage != null)
        {
            healthImage.fillAmount = (float)currentHP / maxHP;


        }
    }

}
