using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//made by Amrit Chatha

public class InteractableButtonBase : MonoBehaviour
{

    [HideInInspector] public bool interactPressed;
    private bool playerInTrigger;
    private OwnPlayer playerInput;
    private GameObject player;

    [Header("Initializers")]
    [SerializeField] private InteractableButton interactableButton;
    [SerializeField] private CameraCutsceneBase cameraCutsceneBase;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image interactionImage;
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private GameObject playerInteractPosition;

    [Header("Design & Text")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private string description;

    void Awake()
    {
        playerInput = new OwnPlayer();
        player = GameObject.FindWithTag("Player");


        playerInput.Player.ActionInteract.started += OnInteractInput;
        playerInput.Player.ActionInteract.canceled += OnInteractInput;
    }

    void Start()
    {
        canvas.enabled = false;
    }
    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private void Update()
    {
        StartCoroutine(PlayerInteract());
    }

    void OnInteractInput(InputAction.CallbackContext context)
    {
        interactPressed = context.ReadValueAsButton();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
            canvas.enabled = true;
            interactionText.text = description;
            interactionImage.sprite = sprite;
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerInTrigger = false;
        canvas.enabled = false;
    }

    private IEnumerator PlayerInteract()
    {
        if (playerInTrigger)
        {
            if (interactPressed)
            {
                playerInTrigger = false;

                cameraCutsceneBase.playerCamera.enabled = false;
                cameraCutsceneBase.cutsceneCamera.enabled = true;

                player.GetComponent<BetterPlayerMovement>().enabled = false;
                player.transform.SetPositionAndRotation(playerInteractPosition.transform.position, Quaternion.LookRotation(playerInteractPosition.transform.right));

                canvas.enabled = false;
                Destroy(gameObject.GetComponent<SphereCollider>());

            }
        }

        if (cameraCutsceneBase.cutsceneCamera.enabled)
        {
            yield return new WaitForSeconds(4);
            cameraCutsceneBase.doorButtonTransition = true;
        }

        if (cameraCutsceneBase.gameObject.transform.position == cameraCutsceneBase.endTarget.transform.position)
        {
            interactableButton.ApplyEffects();
            cameraCutsceneBase.doorButtonTransition = false;
            yield return new WaitForSeconds(4);
            cameraCutsceneBase.cutsceneCamera.enabled = false;
            cameraCutsceneBase.playerCamera.enabled = true;
            player.GetComponent<BetterPlayerMovement>().enabled = true;
            Destroy(gameObject.GetComponent<InteractableButtonBase>());
        }
    }
}
