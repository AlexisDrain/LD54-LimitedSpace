using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameObject gameManagerObject;

    public static LayerMask worldLayer;
    public static LayerMask entityLayer;

    private static Pool pool_LoudAudioSource;

    public static Transform playerTrans;
    public static PlayerUse playerUse;
    public static GameObject canvasTutorial;
    public static GameObject canvasDeath;
    public static GameObject canvasMainMenu;
    
    public static Text hintText;
    public static Text mainUseText;


    // Start is called before the first frame update
    void Awake()
    {
        gameManagerObject = gameObject;

        worldLayer = LayerMask.NameToLayer("World");
        entityLayer = LayerMask.NameToLayer("Entity");
        pool_LoudAudioSource = transform.Find("Pool_LoudAudioSource").GetComponent<Pool>();

        playerTrans = GameObject.Find("Player").transform;
        playerUse = GameObject.Find("Player/PlayerCameraRoot/MainCamera").GetComponent<PlayerUse>();
        canvasTutorial = GameObject.Find("Canvas/Tutorial");
        canvasTutorial.SetActive(false);
        canvasDeath = GameObject.Find("Canvas/Death");
        canvasDeath.SetActive(false);
        canvasMainMenu = GameObject.Find("Canvas/MainMenu");
        hintText = GameObject.Find("Canvas/HintText").GetComponent<Text>();
        mainUseText = GameObject.Find("Canvas/MainUseText").GetComponent<Text>();

        Time.timeScale = 0f;
    }

    public static void NewGame() {
        canvasTutorial.SetActive(true);
        canvasMainMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerTrans.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        playerTrans.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        Time.timeScale = 1.0f;
    }
    public static void ResumeGame() {
        canvasMainMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerTrans.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        playerTrans.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        Time.timeScale = 1.0f;
    }
    public static void PauseGame() {
        canvasMainMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        playerTrans.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        playerTrans.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        Time.timeScale = 0f;
    }
    public void ExplodeVessel() {
        canvasDeath.SetActive(true);
        canvasDeath.GetComponent<Animator>().SetTrigger("Die");
        Time.timeScale = 0f;
        StartCoroutine(ExplodeRestartGameCountDown());
    }
    private IEnumerator ExplodeRestartGameCountDown() {
        yield return new WaitForSecondsRealtime(10f);
        RestartGameScene();
    }
    public static void RestartGameScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update() {
        if(Input.GetButtonDown("Pause")) {
            GameManager.PauseGame();
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha3)) {
            ExplodeVessel();
        }
    }

    // hidden inside PlayerUse.cs
    public static void HideTutorial() {
        canvasTutorial.SetActive(false);
    }
    public static AudioSource SpawnLoudAudio(AudioClip newAudioClip, Vector2 pitch = new Vector2(), float newVolume = 1f) {

        float sfxPitch;
        if (pitch.x <= 0.1f) {
            sfxPitch = 1;
        } else {
            sfxPitch = Random.Range(pitch.x, pitch.y);
        }

        AudioSource audioObject = pool_LoudAudioSource.Spawn(new Vector3(0f, 0f, 0f)).GetComponent<AudioSource>();
        audioObject.GetComponent<AudioSource>().pitch = sfxPitch;
        audioObject.PlayWebGL(newAudioClip, newVolume);
        return audioObject;
        // audio object will set itself to inactive after done playing.
    }
}
