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
    [KnownType(typeof(GoodsPropertyValue))]
    [KnownType(typeof(GoodsType))]
    [KnownType(typeof(PropertyType))]
    public partial class GoodsTypeProperty: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region 基元属性
    
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“Id”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public int GoodsTypeId
        {
            get { return _goodsTypeId; }
            set
            {
                if (_goodsTypeId != value)
                {
                    ChangeTracker.RecordOriginalValue("GoodsTypeId", _goodsTypeId);
                    if (!IsDeserializing)
                    {
                        if (GoodsType != null && GoodsType.id != value)
                        {
                            GoodsType = null;
                        }
                    }
                    _goodsTypeId = value;
                    OnPropertyChanged("GoodsTypeId");
                }
            }
        }
        private int _goodsTypeId;
    
        [DataMember]
        public string Property
        {
            get { return _property; }
            set
            {
                if (_property != value)
                {
                    _property = value;
                    OnPropertyChanged("Property");
                }
            }
        }
        private string _property;
    
        [DataMember]
        public Nullable<int> PropertyTypeId
        {
            get { return _propertyTypeId; }
            set
            {
                if (_propertyTypeId != value)
                {
                    ChangeTracker.RecordOriginalValue("PropertyTypeId", _propertyTypeId);
                    if (!IsDeserializing)
                    {
                        if (PropertyType != null && PropertyType.id != value)
                        {
                            PropertyType = null;
                        }
                    }
                    _propertyTypeId = value;
                    OnPropertyChanged("PropertyTypeId");
                }
            }
        }
        private Nullable<int> _propertyTypeId;
    
        [DataMember]
        public bool isNULL
        {
            get { return _isNULL; }
            set
            {
                if (_isNULL != value)
                {
                    _isNULL = value;
                    OnPropertyChanged("isNULL");
                }
            }
        }
        private bool _isNULL;

        #endregion

        #region 导航属性
    
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
        public PropertyType PropertyType
        {
            get { return _propertyType; }
            set
            {
                if (!ReferenceEquals(_propertyType, value))
                {
                    var previousValue = _propertyType;
                    _propertyType = value;
                    FixupPropertyType(previousValue);
                    OnNavigationPropertyChanged("PropertyType");
                }
            }
        }
        private PropertyType _propertyType;

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
            GoodsPropertyValue.Clear();
            GoodsType = null;
            PropertyType = null;
        }

        #endregion

        #region 关联修复
    
        private void FixupGoodsType(GoodsType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.GoodsTypeProperty.Contains(this))
            {
                previousValue.GoodsTypeProperty.Remove(this);
            }
    
            if (GoodsType != null)
            {
                if (!GoodsType.GoodsTypeProperty.Contains(this))
                {
                    GoodsType.GoodsTypeProperty.Add(this);
                }
    
                GoodsTypeId = GoodsType.id;
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
    
        private void FixupPropertyType(PropertyType previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.GoodsTypeProperty.Contains(this))
            {
                previousValue.GoodsTypeProperty.Remove(this);
            }
    
            if (PropertyType != null)
            {
                if (!PropertyType.GoodsTypeProperty.Contains(this))
                {
                    PropertyType.GoodsTypeProperty.Add(this);
                }
    
                PropertyTypeId = PropertyType.id;
            }
            else if (!skipKeys)
            {
                PropertyTypeId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PropertyType")
                    && (ChangeTracker.OriginalValues["PropertyType"] == PropertyType))
                {
                    ChangeTracker.OriginalValues.Remove("PropertyType");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PropertyType", previousValue);
                }
                if (PropertyType != null && !PropertyType.ChangeTracker.ChangeTrackingEnabled)
                {
                    PropertyType.StartTracking();
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
                    item.GoodsTypeProperty = this;
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
                    if (ReferenceEquals(item.GoodsTypeProperty, this))
                    {
                        item.GoodsTypeProperty = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("GoodsPropertyValue", item);
                    }
                }
            }
        }

        #endregion

    }
}
