//------------------------------------------------------------------------------
// <auto-generated>
//     此代码是根据模板生成的。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace DRM.Entity
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(GoodsType))]
    [KnownType(typeof(GoodsPropertyValue))]
    [KnownType(typeof(Inventory))]
    [KnownType(typeof(ProductGoodsRelationship))]
    public partial class Goods: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region 基元属性
    
        [DataMember]
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“id”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public string goodsNo
        {
            get { return _goodsNo; }
            set
            {
                if (_goodsNo != value)
                {
                    _goodsNo = value;
                    OnPropertyChanged("goodsNo");
                }
            }
        }
        private string _goodsNo;
    
        [DataMember]
        public string goodsName
        {
            get { return _goodsName; }
            set
            {
                if (_goodsName != value)
                {
                    _goodsName = value;
                    OnPropertyChanged("goodsName");
                }
            }
        }
        private string _goodsName;
    
        [DataMember]
        public int goodsTypeId
        {
            get { return _goodsTypeId; }
            set
            {
                if (_goodsTypeId != value)
                {
                    ChangeTracker.RecordOriginalValue("goodsTypeId", _goodsTypeId);
                    if (!IsDeserializing)
                    {
                        if (GoodsType != null && GoodsType.id != value)
                        {
                            GoodsType = null;
                        }
                    }
                    _goodsTypeId = value;
                    OnPropertyChanged("goodsTypeId");
                }
            }
        }
        private int _goodsTypeId;
    
        [DataMember]
        public Nullable<decimal> price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("price");
                }
            }
        }
        private Nullable<decimal> _price;

        #endregion

        #region 导航属性
    
        [DataMember]
        public GoodsType GoodsType
        {
            get { return _goodsType; }
            set
            {
                if (!ReferenceEquals(_goodsType, value))
                {
                    var previousValue = _goodsType;
                    _goodsType = value;
                    FixupGoodsType(previousValue);
                    OnNavigationPropertyChanged("GoodsType");
                }
            }
        }
        private GoodsType _goodsType;
    
        [DataMember]
        public TrackableCollection<GoodsPropertyValue> GoodsPropertyValue
        {
            get
            {
                if (_goodsPropertyValue == null)
                {
                    _goodsPropertyValue = new TrackableCollection<GoodsPropertyValue>();
                    _goodsPropertyValue.CollectionChanged += FixupGoodsPropertyValue;
                }
                return _goodsPropertyValue;
            }
            set
            {
                if (!ReferenceEquals(_goodsPropertyValue, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("当启用 ChangeTracking 时，无法设置 FixupChangeTrackingCollection");
                    }
                    if (_goodsPropertyValue != null)
                    {
                        _goodsPropertyValue.CollectionChanged -= FixupGoodsPropertyValue;
                    }
                    _goodsPropertyValue = value;
                    if (_goodsPropertyValue != null)
                    {
                        _goodsPropertyValue.CollectionChanged += FixupGoodsPropertyValue;
                    }
                    OnNavigationPropertyChanged("GoodsPropertyValue");
                }
            }
        }
        private TrackableCollection<GoodsPropertyValue> _goodsPropertyValue;
    
        [DataMember]
        public TrackableCollection<Inventory> Inventory
        {
            get
            {
                if (_inventory == null)
                {
                    _inventory = new TrackableCollection<Inventory>();
                    _inventory.CollectionChanged += FixupInventory;
                }
                return _inventory;
            }
            set
            {
                if (!ReferenceEquals(_inventory, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("当启用 ChangeTracking 时，无法设置 FixupChangeTrackingCollection");
                    }
                    if (_inventory != null)
                    {
                        _inventory.CollectionChanged -= FixupInventory;
                    }
                    _inventory = value;
                    if (_inventory != null)
                    {
                        _inventory.CollectionChanged += FixupInventory;
                    }
                    OnNavigationPropertyChanged("Inventory");
                }
            }
        }
        private TrackableCollection<Inventory> _inventory;
    
        [DataMember]
        public TrackableCollection<ProductGoodsRelationship> ProductGoodsRelationship
        {
            get
            {
                if (_productGoodsRelationship == null)
                {
                    _productGoodsRelationship = new TrackableCollection<ProductGoodsRelationship>();
                    _productGoodsRelationship.CollectionChanged += FixupProductGoodsRelationship;
                }
                return _productGoodsRelationship;
            }
            set
            {
                if (!ReferenceEquals(_productGoodsRelationship, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("当启用 ChangeTracking 时，无法设置 FixupChangeTrackingCollection");
                    }
                    if (_productGoodsRelationship != null)
                    {
                        _productGoodsRelationship.CollectionChanged -= FixupProductGoodsRelationship;
                    }
                    _productGoodsRelationship = value;
                    if (_productGoodsRelationship != null)
                    {
                        _productGoodsRelationship.CollectionChanged += FixupProductGoodsRelationship;
                    }
                    OnNavigationPropertyChanged("ProductGoodsRelationship");
                }
            }
        }
        private TrackableCollection<ProductGoodsRelationship> _productGoodsRelationship;

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            GoodsType = null;
            GoodsPropertyValue.Clear();
            Inventory.Clear();
            ProductGoodsRelationship.Clear();
        }

        #endregion

        #region 关联修复
    
        private void FixupGoodsType(GoodsType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Goods.Contains(this))
            {
                previousValue.Goods.Remove(this);
            }
    
            if (GoodsType != null)
            {
                if (!GoodsType.Goods.Contains(this))
                {
                    GoodsType.Goods.Add(this);
                }
    
                goodsTypeId = GoodsType.id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("GoodsType")
                    && (ChangeTracker.OriginalValues["GoodsType"] == GoodsType))
                {
                    ChangeTracker.OriginalValues.Remove("GoodsType");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("GoodsType", previousValue);
                }
                if (GoodsType != null && !GoodsType.ChangeTracker.ChangeTrackingEnabled)
                {
                    GoodsType.StartTracking();
                }
            }
        }
    
        private void FixupGoodsPropertyValue(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (GoodsPropertyValue item in e.NewItems)
                {
                    item.Goods = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("GoodsPropertyValue", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (GoodsPropertyValue item in e.OldItems)
                {
                    if (ReferenceEquals(item.Goods, this))
                    {
                        item.Goods = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("GoodsPropertyValue", item);
                    }
                }
            }
        }
    
        private void FixupInventory(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Inventory item in e.NewItems)
                {
                    item.Goods = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Inventory", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Inventory item in e.OldItems)
                {
                    if (ReferenceEquals(item.Goods, this))
                    {
                        item.Goods = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Inventory", item);
                    }
                }
            }
        }
    
        private void FixupProductGoodsRelationship(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ProductGoodsRelationship item in e.NewItems)
                {
                    item.Goods = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ProductGoodsRelationship", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProductGoodsRelationship item in e.OldItems)
                {
                    if (ReferenceEquals(item.Goods, this))
                    {
                        item.Goods = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ProductGoodsRelationship", item);
                    }
                }
            }
        }

        #endregion

    }
}
