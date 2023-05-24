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
    public partial class View_AfterServiceOrder: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region 基元属性
    
        [DataMember]
        public int AfterServiceId
        {
            get { return _afterServiceId; }
            set
            {
                if (_afterServiceId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“AfterServiceId”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _afterServiceId = value;
                    OnPropertyChanged("AfterServiceId");
                }
            }
        }
        private int _afterServiceId;
    
        [DataMember]
        public Nullable<int> AfterServiceUserId
        {
            get { return _afterServiceUserId; }
            set
            {
                if (_afterServiceUserId != value)
                {
                    _afterServiceUserId = value;
                    OnPropertyChanged("AfterServiceUserId");
                }
            }
        }
        private Nullable<int> _afterServiceUserId;
    
        [DataMember]
        public string TypeService
        {
            get { return _typeService; }
            set
            {
                if (_typeService != value)
                {
                    _typeService = value;
                    OnPropertyChanged("TypeService");
                }
            }
        }
        private string _typeService;
    
        [DataMember]
        public string KRemarks
        {
            get { return _kRemarks; }
            set
            {
                if (_kRemarks != value)
                {
                    _kRemarks = value;
                    OnPropertyChanged("KRemarks");
                }
            }
        }
        private string _kRemarks;
    
        [DataMember]
        public string KDeliveryType
        {
            get { return _kDeliveryType; }
            set
            {
                if (_kDeliveryType != value)
                {
                    _kDeliveryType = value;
                    OnPropertyChanged("KDeliveryType");
                }
            }
        }
        private string _kDeliveryType;
    
        [DataMember]
        public string KDeliveryName
        {
            get { return _kDeliveryName; }
            set
            {
                if (_kDeliveryName != value)
                {
                    _kDeliveryName = value;
                    OnPropertyChanged("KDeliveryName");
                }
            }
        }
        private string _kDeliveryName;
    
        [DataMember]
        public string KDeliveryNumbers
        {
            get { return _kDeliveryNumbers; }
            set
            {
                if (_kDeliveryNumbers != value)
                {
                    _kDeliveryNumbers = value;
                    OnPropertyChanged("KDeliveryNumbers");
                }
            }
        }
        private string _kDeliveryNumbers;
    
        [DataMember]
        public string DRemarks
        {
            get { return _dRemarks; }
            set
            {
                if (_dRemarks != value)
                {
                    _dRemarks = value;
                    OnPropertyChanged("DRemarks");
                }
            }
        }
        private string _dRemarks;
    
        [DataMember]
        public string DDeliveryType
        {
            get { return _dDeliveryType; }
            set
            {
                if (_dDeliveryType != value)
                {
                    _dDeliveryType = value;
                    OnPropertyChanged("DDeliveryType");
                }
            }
        }
        private string _dDeliveryType;
    
        [DataMember]
        public string DDeliveryName
        {
            get { return _dDeliveryName; }
            set
            {
                if (_dDeliveryName != value)
                {
                    _dDeliveryName = value;
                    OnPropertyChanged("DDeliveryName");
                }
            }
        }
        private string _dDeliveryName;
    
        [DataMember]
        public string DDeliveryNumbers
        {
            get { return _dDeliveryNumbers; }
            set
            {
                if (_dDeliveryNumbers != value)
                {
                    _dDeliveryNumbers = value;
                    OnPropertyChanged("DDeliveryNumbers");
                }
            }
        }
        private string _dDeliveryNumbers;
    
        [DataMember]
        public string AfterServiceState
        {
            get { return _afterServiceState; }
            set
            {
                if (_afterServiceState != value)
                {
                    _afterServiceState = value;
                    OnPropertyChanged("AfterServiceState");
                }
            }
        }
        private string _afterServiceState;
    
        [DataMember]
        public Nullable<System.DateTime> AfterServiceDate
        {
            get { return _afterServiceDate; }
            set
            {
                if (_afterServiceDate != value)
                {
                    _afterServiceDate = value;
                    OnPropertyChanged("AfterServiceDate");
                }
            }
        }
        private Nullable<System.DateTime> _afterServiceDate;
    
        [DataMember]
        public string Orderid
        {
            get { return _orderid; }
            set
            {
                if (_orderid != value)
                {
                    _orderid = value;
                    OnPropertyChanged("Orderid");
                }
            }
        }
        private string _orderid;
    
        [DataMember]
        public Nullable<int> SellerId
        {
            get { return _sellerId; }
            set
            {
                if (_sellerId != value)
                {
                    _sellerId = value;
                    OnPropertyChanged("SellerId");
                }
            }
        }
        private Nullable<int> _sellerId;
    
        [DataMember]
        public string email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("email");
                }
            }
        }
        private string _email;
    
        [DataMember]
        public string realname
        {
            get { return _realname; }
            set
            {
                if (_realname != value)
                {
                    _realname = value;
                    OnPropertyChanged("realname");
                }
            }
        }
        private string _realname;
    
        [DataMember]
        public string nickname
        {
            get { return _nickname; }
            set
            {
                if (_nickname != value)
                {
                    _nickname = value;
                    OnPropertyChanged("nickname");
                }
            }
        }
        private string _nickname;

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
        }

        #endregion

    }
}
