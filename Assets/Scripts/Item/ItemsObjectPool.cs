using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Item;


    public class ItemsObjectPool : MonoBehaviour
    {
        [SerializeField] private ItemScenePresenter _itemScenePresenter;
        
        private List<ItemScenePresenter> _available = new List<ItemScenePresenter>();
        private List<ItemScenePresenter> _inUse = new List<ItemScenePresenter>();

        public ItemScenePresenter Get(IItem item)
        {
            ItemScenePresenter presenter = null;
            if (_available.Count == 0)
            {
                presenter = Instantiate(_itemScenePresenter);
                presenter.Present(item);
                presenter.PickedUp += () => Release(presenter);
            }
            else
            {
                presenter = _available[0];
                _available.Remove(presenter);
                presenter.gameObject.SetActive(true);
            }
            
            _inUse.Add(presenter);
            return presenter;

            void Release(ItemScenePresenter presenter)
            {
                if (_inUse.Remove(presenter) == false)
                {
                    return;
                }
                
                presenter.gameObject.SetActive(false);
                _available.Add(presenter);
            }
        }
    }
