using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager instance;

    private EntryInteraction.EntryToSpawnAt _entryToSpawnAt;
    private static bool _loadFromEntry;

    private GameObject _player;
    private Collider2D _playerCollider;
    private Vector3 _playerEntryPoint;
    private Collider2D _entryCollider;
    private CinemachineCamera vcam;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerCollider = _player.GetComponent<Collider2D>();
        vcam = GameObject.FindGameObjectWithTag("CinemachineCamera").GetComponent<CinemachineCamera>();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneFadeManager.instance.StartFadeIn();
        if (_loadFromEntry)
        {
            FindEntry(_entryToSpawnAt);
            Vector3 oldPosition = _player.transform.position;
            _player.transform.position = _playerEntryPoint;
            vcam.OnTargetObjectWarped(_player.transform, _playerEntryPoint - oldPosition);
            _loadFromEntry = false;
        }
    }

    public static void StartSceneChangeFromEntry(string scene, EntryInteraction.EntryToSpawnAt entryToSpawnAt)
    {
        _loadFromEntry = true;
        instance.StartCoroutine(instance.FadeToSceneChange(scene, entryToSpawnAt));
    }

    private IEnumerator FadeToSceneChange(string scene, EntryInteraction.EntryToSpawnAt entryToSpawnAt = EntryInteraction.EntryToSpawnAt.None)
    {
        SceneFadeManager.instance.StartFadeOut();

        while (SceneFadeManager.instance.isFadingOut)
        {
            yield return null;
        }

        _entryToSpawnAt = entryToSpawnAt;
        SceneManager.LoadScene(scene);
    }

    private void FindEntry(EntryInteraction.EntryToSpawnAt entryToSpawnAt)
    {
        EntryInteraction[] entries = GameObject.FindObjectsByType<EntryInteraction>(FindObjectsSortMode.None);
        {
            foreach (EntryInteraction entry in entries)
            {
                if (entry._thisEntryNumber == entryToSpawnAt)
                {
                    _entryCollider = entry.gameObject.GetComponent<Collider2D>();
                    _playerEntryPoint = _entryCollider.transform.position - new Vector3(0, _playerCollider.bounds.extents.y, 0);
                    return;
                }
            }
        }
    }
}
