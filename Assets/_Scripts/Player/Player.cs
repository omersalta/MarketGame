using System;
using _Scripts.Market;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Player
{
    public class Player : PlayerMovement
    {
        private BaseContainer _selectedContainer;
        
        private BaseContainer _currentContainer;
        public BaseContainer CurrentContainer => _currentContainer;
        
        [SerializeField] private LayerMask _interactionLayers;
        
        public UnityEvent<BaseContainer> OnSelectionContainer; 
        
        public void Interaction()
        {
            if (_selectedContainer != null)
            {
                _selectedContainer.Interact(this);
            }
        }

        public void SetContainer(OrderBox orderBox)
        {
            _currentContainer = orderBox;
        }
        
        private void CheckInteraction()
        {
            float interactDistance = 1f;
            SetSelectedCounter(null);
            
            RaycastHit2D raycastHit2D = Physics2D.Raycast(bodyTransform.position, lastMoveDir, interactDistance, _interactionLayers);
            if (raycastHit2D.collider != null) // Çarpışma kontrolü
            {
                if (raycastHit2D.transform.TryGetComponent(out BaseContainer container))
                {
                    SetSelectedCounter(container);
                }
            }
        }
        
        private void SetSelectedCounter(BaseContainer baseContainer)
        {
            
            _selectedContainer = baseContainer;
            OnSelectionContainer.Invoke(_selectedContainer);
        }

        protected new void Update()
        {
            base.Update();
            CheckInteraction();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interaction();
            }
        }
    }
}