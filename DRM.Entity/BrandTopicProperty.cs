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
    [KnownType(typeof(BrandTopic))]
    public partial class BrandTopicProperty: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public int brandTopicId
        {
            get { return _brandTopicId; }
            set
            {
                if (_brandTopicId != value)
                {
                    ChangeTracker.RecordOriginalValue("brandTopicId", _brandTopicId);
                    if (!IsDeserializing)
                    {
                        if (BrandTopic != null && BrandTopic.id != value)
                        {
                            BrandTopic = null;
                        }
                    }
                    _brandTopicId = value;
                    OnPropertyChanged("brandTopicId");
                }
            }
        }
        private int _brandTopicId;
    
        [DataMember]
        public string spaceType
        {
            get { return _spaceType; }
            set
            {
                if (_spaceType != value)
                {
                    _spaceType = value;
                    OnPropertyChanged("spaceType");
                }
            }
        }
        private string _spaceType;
    
        [DataMember]
        public int spaceId
        {
            get { return _spaceId; }
            set
            {
                if (_spaceId != value)
                {
                    _spaceId = value;
                    OnPropertyChanged("spaceId");
                }
            }
        }
        private int _spaceId;
    
        [DataMember]
        public Nullable<int> itemId
        {
            get { return _itemId; }
            set
            {
                if (_itemId != value)
                {
                    _itemId = value;
                    OnPropertyChanged("itemId");
                }
            }
        }
        private Nullable<int> _itemId;
    
        [DataMember]
        public string key
        {
            get { return _key; }
            set
            {
                if (_key != value)
                {
                    _key = value;
                    OnPropertyChanged("key");
                }
            }
        }
        private string _key;
    
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
    
        [DataMember]
        public int sortId
        {
            get { return _sortId; }
            set
            {
                if (_sortId != value)
                {
                    _sortId = value;
                    OnPropertyChanged("sortId");
                }
            }
        }
        private int _sortId;

        #endregion

        #region 导航属性
    
        [DataMember]
        public BrandTopic BrandTopic
        {
            get { return _brandTopic; }
            set
            {
                if (!ReferenceEquals(_brandTopic, value))
                {
                    var previousValue = _brandTopic;
                    _brandTopic = value;
                    FixupBrandTopic(previousValue);
                    OnNavigationPropertyChanged("BrandTopic");
                }
            }
        }
        private BrandTopic _brandTopic;

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
            BrandTopic = null;
        }

        #endregion

        #region 关联修复
    
        private void FixupBrandTopic(BrandTopic previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BrandTopicProperty.Contains(this))
            {
                previousValue.BrandTopicProperty.Remove(this);
            }
    
            if (BrandTopic != null)
            {
                if (!BrandTopic.BrandTopicProperty.Contains(this))
                {
                    BrandTopic.BrandTopicProperty.Add(this);
                }
    
                brandTopicId = BrandTopic.id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BrandTopic")
                    && (ChangeTracker.OriginalValues["BrandTopic"] == BrandTopic))
                {
                    ChangeTracker.OriginalValues.Remove("BrandTopic");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BrandTopic", previousValue);
                }
                if (BrandTopic != null && !BrandTopic.ChangeTracker.ChangeTrackingEnabled)
                {
                    BrandTopic.StartTracking();
                }
            }
        }

        #endregion

    }
}
