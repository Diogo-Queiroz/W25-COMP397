using UnityEngine;

namespace Platformer397
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : Subject
    {
        [Header("Inputs")]
        [SerializeField] private InputReader input;
        [Tooltip("Variable Reference to the Player's Rigidbody To Be Assigned")]
        [SerializeField] private Rigidbody rb;
        private Vector3 movement;

        [Header("Stats")]
        [Tooltip("Speed of Movement of the Player")]
        [SerializeField] private float moveSpeed = 200f;
        [Tooltip("Speed of Rotation of the Player")]
        [SerializeField] private float rotationSpeed = 200f;

        [SerializeField] private Transform mainCam;

        private Inventory inventory;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            mainCam = Camera.main.transform;
            inventory = new Inventory();
        }
        private void Start()
        {
            input.EnablePlayerActions();
            NotifyObservers();
        }
        private void OnEnable()
        {
            input.Move += GetMovement;
            input.Interact += UseKey;
        }
        private void OnDisable()
        {
            input.Move -= GetMovement;
            input.Interact -= UseKey;
        }
        private void FixedUpdate()
        {
            UpdateMovement();
        }
        private void OnTriggerEnter(Collider other) {

            ItemCollectible collectible = other.gameObject.GetComponent<ItemCollectible>();

            if (collectible == null) { return; }

            switch(collectible.item.itemType) {

                case ItemBase.ItemType.Weapon:
                    inventory.Add(collectible.item); 
                    break;
                case ItemBase.ItemType.Coin:
                    inventory.Add(collectible.item); //Custom implementation here to add the value of the coins
                    Coin coin = collectible.item as Coin;
                    Debug.Log("Adding coin into inventory of value: " + coin.value);
                    break;
                case ItemBase.ItemType.Key:
                    inventory.Add(collectible.item); //Custom implementation to stack keys together 
                    Debug.Log("Adding key into inventory!");
                    break;
                default:
                    break;

            }
            Destroy(collectible.gameObject);
        }

        private void UpdateMovement()
        {
            var adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * movement;
            if (adjustedDirection.magnitude > 0f)
            {
                // Handle the rotation and movement
                HandleRotation(adjustedDirection);
                HandleMovement(adjustedDirection);
            }
            else
            {
                // not change the rotation or movement, but need to apply rigidbody Y movement for gravity
                rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            }
        }
        private void HandleMovement(Vector3 adjustedMovement)
        {
            var velocity = adjustedMovement * moveSpeed * Time.fixedDeltaTime;
            rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        }
        private void HandleRotation(Vector3 adjustedMovement)
        {
            var targetRotation = Quaternion.LookRotation(adjustedMovement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        private void GetMovement(Vector2 move)
        {
            movement.x = move.x;
            movement.z = move.y;
        }

        private void UseKey(bool status) {

            if (!status) { return; }

            Key keyItem = inventory.GetKey(out bool hasKey) as Key;

            if (hasKey) {

                inventory.Remove(keyItem);
                Debug.Log("Used A Key!");

            }

        }

    }
}
