using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        //(2)
        // Initialize seed counts
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;

        // Update UI with the initial counts
        if (_plantCountUI != null)
        {
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }
    }

    private void Update()
    {
        //(1)
        float horizontal = Input.GetAxisRaw("Horizontal"); // Left and Right movement (A/D or Left/Right Arrow)
        float vertical = Input.GetAxisRaw("Vertical");     // Up and Down movement (W/S or Up/Down Arrow)

        // Calculate the movement direction in 2D space (X and Y)
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        // Move the player in 2D
        transform.Translate(direction * _speed * Time.deltaTime);

        
        // Plant a seed when SPACE is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }
    }

    public void PlantSeed ()
    {
        //(3)
        // Check if the player has seeds left
        if (_numSeedsLeft <= 0)
        {
            // Optional: Provide feedback if no seeds are left
            Debug.Log("No seeds left to plant!");
            return; // Exit the method
        }

        // Perform actions 4-6 (from part 4)
        Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity); // Action 4
        _numSeedsLeft--; // Action 5
        _numSeedsPlanted++; // Action 6

        // Update the UI
        if (_plantCountUI != null)
        {
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }
    }
}
