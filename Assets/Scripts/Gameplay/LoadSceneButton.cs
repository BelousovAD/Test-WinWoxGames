using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Button))]
    internal class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private string _sceneToLoad;
        
        private Button _button;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(HandleClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(HandleClick);

        private void HandleClick() =>
            SceneManager.LoadScene(_sceneToLoad);
    }
}