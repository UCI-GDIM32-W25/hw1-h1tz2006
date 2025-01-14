using UnityEngine;
using TMPro;

public class PlantCountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _plantedText;
    [SerializeField] private TMP_Text _remainingText;

    public void UpdateSeeds (int seedsLeft, int seedsPlanted)
    {
        // Update the UI text elements with the current seed counts
        _remainingText.text = "seeds left: " + seedsLeft;
        _plantedText.text = "seeds planted: " + seedsPlanted;
    }
}