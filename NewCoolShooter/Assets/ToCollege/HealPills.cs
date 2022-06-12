using UnityEngine.UI;
using UnityEngine;

public class HealPills : MonoBehaviour
{
    private bool _isRaised;
    [SerializeField] private GameObject _pillsUI;

    private void Update()
    {
        if (_isRaised) 
        {
            _pillsUI.SetActive(false);
        }
    }

    public void PillsPickUp(bool isRaised)
    {
        _isRaised = isRaised;
    }
}
