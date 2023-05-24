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
    [KnownType(typeof(GoodsTypeProperty))]
    public partial class GoodsPropertyValue: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public int goodsId
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
        private int _goodsId;
    
        [DataMember]
        public int goodsTypePropertyId
        {
            get { return _goodsTypePropertyId; }
            set
            {
                if (_goodsTypePropertyId != value)
                {
                    ChangeTracker.RecordOriginalValue("goodsTypePropertyId", _goodsTypePropertyId);
                    if (!IsDeserializing)
                    {
                        if (GoodsTypeProperty != null && GoodsTypeProperty.Id != value)
                        {
                            GoodsTypeProperty = null;
                        }
                    }
                    _goodsTypePropertyId = value;
                    OnPropertyChanged("goodsTypePropertyId");
                }
            }
        }
        private int _goodsTypePropertyId;
    
        [DataMember]
        public string value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged("value");
                }
            }
        }
        private string _value;

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
        public GoodsTypeProperty GoodsTypeProperty
        {
            get { return _goodsTypeProperty; }
            set
            {
                if (!ReferenceEquals(_goodsTypeProperty, value))
                {
                    var previousValue = _goodsTypeProperty;
                    _goodsTypeProperty = value;
                    FixupGoodsTypeProperty(previousValue);
                    OnNavigationPropertyChanged("GoodsTypeProperty");
                }
            }
        }
        private GoodsTypeProperty _goodsTypeProperty;

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
            GoodsTypeProperty = null;
        }

        #endregion

        #region 关联修复
    
        private void FixupGoods(Goods previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.GoodsPropertyValue.Contains(this))
            {
                previousValue.GoodsPropertyValue.Remove(this);
            }
    
            if (Goods != null)
            {
                if (!Goods.GoodsPropertyValue.Contains(this))
                {
                    Goods.GoodsPropertyValue.Add(this);
                }
    
                goodsId = Goods.id;
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
    
        private void FixupGoodsTypeProperty(GoodsTypeProperty previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.GoodsPropertyValue.Contains(this))
            {
                previousValue.GoodsPropertyValue.Remove(this);
            }
    
            if (GoodsTypeProperty != null)
            {
                if (!GoodsTypeProperty.GoodsPropertyValue.Contains(this))
                {
                    GoodsTypeProperty.GoodsPropertyValue.Add(this);
                }
    
                goodsTypePropertyId = GoodsTypeProperty.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("GoodsTypeProperty")
                    && (ChangeTracker.OriginalValues["GoodsTypeProperty"] == GoodsTypeProperty))
                {
                    ChangeTracker.OriginalValues.Remove("GoodsTypeProperty");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("GoodsTypeProperty", previousValue);
                }
                if (GoodsTypeProperty != null && !GoodsTypeProperty.ChangeTracker.ChangeTrackingEnabled)
                {
                    GoodsTypeProperty.StartTracking();
                }
            }
        }

        #endregion

    }
}