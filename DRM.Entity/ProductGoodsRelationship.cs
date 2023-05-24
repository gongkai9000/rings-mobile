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
    [KnownType(typeof(Goods))]
    [KnownType(typeof(GoodsType))]
    [KnownType(typeof(ProductType))]
    public partial class ProductGoodsRelationship: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public int productId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    ChangeTracker.RecordOriginalValue("productId", _productId);
                    if (!IsDeserializing)
                    {
                        if (ProductType != null && ProductType.id != value)
                        {
                            ProductType = null;
                        }
                    }
                    _productId = value;
                    OnPropertyChanged("productId");
                }
            }
        }
        private int _productId;
    
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
        public Nullable<int> goodsId
        {
            get { return _goodsId; }
            set
            {
                if (_goodsId != value)
                {
                    ChangeTracker.RecordOriginalValue("goodsId", _goodsId);
                    if (!IsDeserializing)
                    {
                        if (Goods != null && Goods.id != value)
                        {
                            Goods = null;
                        }
                    }
                    _goodsId = value;
                    OnPropertyChanged("goodsId");
                }
            }
        }
        private Nullable<int> _goodsId;

        #endregion

        #region 导航属性
    
        [DataMember]
        public Goods Goods
        {
            get { return _goods; }
            set
            {
                if (!ReferenceEquals(_goods, value))
                {
                    var previousValue = _goods;
                    _goods = value;
                    FixupGoods(previousValue);
                    OnNavigationPropertyChanged("Goods");
                }
            }
        }
        private Goods _goods;
    
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
        public ProductType ProductType
        {
            get { return _productType; }
            set
            {
                if (!ReferenceEquals(_productType, value))
                {
                    var previousValue = _productType;
                    _productType = value;
                    FixupProductType(previousValue);
                    OnNavigationPropertyChanged("ProductType");
                }
            }
        }
        private ProductType _productType;

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
            Goods = null;
            GoodsType = null;
            ProductType = null;
        }

        #endregion

        #region 关联修复
    
        private void FixupGoods(Goods previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ProductGoodsRelationship.Contains(this))
            {
                previousValue.ProductGoodsRelationship.Remove(this);
            }
    
            if (Goods != null)
            {
                if (!Goods.ProductGoodsRelationship.Contains(this))
                {
                    Goods.ProductGoodsRelationship.Add(this);
                }
    
                goodsId = Goods.id;
            }
            else if (!skipKeys)
            {
                goodsId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Goods")
                    && (ChangeTracker.OriginalValues["Goods"] == Goods))
                {
                    ChangeTracker.OriginalValues.Remove("Goods");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Goods", previousValue);
                }
                if (Goods != null && !Goods.ChangeTracker.ChangeTrackingEnabled)
                {
                    Goods.StartTracking();
                }
            }
        }
    
        private void FixupGoodsType(GoodsType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ProductGoodsRelationship.Contains(this))
            {
                previousValue.ProductGoodsRelationship.Remove(this);
            }
    
            if (GoodsType != null)
            {
                if (!GoodsType.ProductGoodsRelationship.Contains(this))
                {
                    GoodsType.ProductGoodsRelationship.Add(this);
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
    
        private void FixupProductType(ProductType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ProductGoodsRelationship.Contains(this))
            {
                previousValue.ProductGoodsRelationship.Remove(this);
            }
    
            if (ProductType != null)
            {
                if (!ProductType.ProductGoodsRelationship.Contains(this))
                {
                    ProductType.ProductGoodsRelationship.Add(this);
                }
    
                productId = ProductType.id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ProductType")
                    && (ChangeTracker.OriginalValues["ProductType"] == ProductType))
                {
                    ChangeTracker.OriginalValues.Remove("ProductType");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ProductType", previousValue);
                }
                if (ProductType != null && !ProductType.ChangeTracker.ChangeTrackingEnabled)
                {
                    ProductType.StartTracking();
                }
            }
        }

        #endregion

    }
}
