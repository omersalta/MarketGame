using _Scripts.ContainerSystem;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts._Player
{
    public class Player : PlayerMovement
    {
        private IInteractable _selectedInteractable;
        public UnityEvent<IInteractable> OnSelectionInteractable; 
        
        private IHoldable _currentHoldable;
        public IHoldable CurrentHoldable => _currentHoldable;
        
        [SerializeField] private LayerMask _interactionLayers;
        
        [SerializeField] private BaseContainer _holdingPointContainer; 
        
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

        public void SetHoldingItem (IHoldable item)
        {
            if (CurrentHoldable == null)
            {
                _currentHoldable = item;
            }
            else
            {
                Debug.Log("player already has a item");
            }
        }

        
        
        public BaseContainer GetContainer ()
        {
            var currentHoldedContainer = CurrentHoldable as BaseContainer;
            if (currentHoldedContainer != null)
            {
                return currentHoldedContainer;
            }
            else
            {
                return _holdingPointContainer;
            }
            
        }
        
        
    }
}