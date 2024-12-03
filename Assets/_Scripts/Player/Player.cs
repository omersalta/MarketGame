using _Scripts.ContainerSystem;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts._Player
{
    public class Player : PlayerMovement
    {
        private IInteractable _selectedInteractable;
        public UnityEvent<IInteractable> OnSelectionInteractable; 
        
        private IHoldable _currentHolded;
        public IHoldable CurrentHolded => _currentHolded;
        
        [SerializeField] private LayerMask _interactionLayers;
        
        [SerializeField] private PlayerHandContainer _holdingPointContainer;

        private void Start()
        {
            _holdingPointContainer.Initialize(2);
        }

        private void CheckInteraction()
        {
            float interactDistance = 1f;
            SetSelectedInteractable(null);
            
            RaycastHit2D raycastHit2D = Physics2D.Raycast(bodyTransform.position, lastMoveDir, interactDistance, _interactionLayers);
            if (raycastHit2D.collider != null) // Çarpışma kontrolü
            {
                if (raycastHit2D.transform.TryGetComponent(out IInteractable container))
                {
                    SetSelectedInteractable(container);
                    Debug.Log(container);
                }
            }
            
            void SetSelectedInteractable(IInteractable interactable)
            {
                _selectedInteractable = interactable;
                OnSelectionInteractable.Invoke(_selectedInteractable);
                
            }
            
        }
        
        protected new void Update()
        {
            base.Update();
            CheckInteraction();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interaction();
            }
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractionAlternate();
            }
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                Drop();
            }
        }
        
        private void Drop()
        {
            if (CurrentHolded != null)
            {
                if (CurrentHolded.HasHolder())
                {
                    CurrentHolded.SetHolder(null);
                    _currentHolded = null;
                }
                else
                {
                    Debug.LogWarning("CurrentHolded already has not a holder");
                }
            }
        }
        
        private void Interaction()
        {
            if (_selectedInteractable != null)
            {
                if (_selectedInteractable.IsEnable())
                {
                    _selectedInteractable.Interact(this);
                }
            }
        }
        
        private void InteractionAlternate()
        {
            if (_selectedInteractable != null)
            {
                if (_selectedInteractable.IsEnable())
                {
                    _selectedInteractable.InteractAlternate(this);
                }
            }
        }
        
        public BaseContainer GetContainer ()
        {
            if (CurrentHolded != null)
            {
                var currentHoldedContainer = CurrentHolded as BaseContainer;
                if (currentHoldedContainer != null)
                {
                    return currentHoldedContainer;
                }
                else
                {
                    return _holdingPointContainer;
                }
            }
            else
            {
                return _holdingPointContainer;
            }
            
        }
        
        public Transform GetHolderAsParent()
        {
            return _holdingPointContainer.transform;
        }
    }
}