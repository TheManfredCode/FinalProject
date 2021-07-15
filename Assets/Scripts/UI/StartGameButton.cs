using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    private Button _startButton;

    private void Start()
    {
        _startButton = GetComponent<Button>();
        _startButton.onClick.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed()
    {
        GameScene.Load();
    }
}
