using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectBtn : MonoBehaviour
{
    [SerializeField] private GameObject chosenPlayer;
    private GameObject CanvasParent;
    private Button btn;

    
    private void Start()
    {
        btn = GetComponent<Button>();
        CanvasParent = transform.parent.parent.gameObject;
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameManager.Instance.SetCurrentPlayer(chosenPlayer);

        Destroy(CanvasParent);

        
    }
}
