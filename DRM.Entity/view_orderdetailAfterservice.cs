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
    public partial class view_orderdetailAfterservice: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region 基元属性
    
        [DataMember]
        public string orderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    _orderId = value;
                    OnPropertyChanged("orderId");
                }
            }
        }
        private string _orderId;
    
        [DataMember]
        public Nullable<int> ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }
        private Nullable<int> _productId;
    
        [DataMember]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        private string _title;
    
        [DataMember]
        public Nullable<int> Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
        private Nullable<int> _quantity;
    
        [DataMember]
        public Nullable<decimal> Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        private Nullable<decimal> _price;
    
        [DataMember]
        public string memberprice
        {
            get { return _memberprice; }
            set
            {
                if (_memberprice != value)
                {
                    _memberprice = value;
                    OnPropertyChanged("memberprice");
                }
            }
        }
        private string _memberprice;
    
        [DataMember]
        public string protype
        {
            get { return _protype; }
            set
            {
                if (_protype != value)
                {
                    _protype = value;
                    OnPropertyChanged("protype");
                }
            }
        }
        private string _protype;
    
        [DataMember]
        public string handsize
        {
            get { return _handsize; }
            set
            {
                if (_handsize != value)
                {
                    _handsize = value;
                    OnPropertyChanged("handsize");
                }
            }
        }
        private string _handsize;
    
        [DataMember]
        public string fontstyle
        {
            get { return _fontstyle; }
            set
            {
                if (_fontstyle != value)
                {
                    _fontstyle = value;
                    OnPropertyChanged("fontstyle");
                }
            }
        }
        private string _fontstyle;
    
        [DataMember]
        public string Material
        {
            get { return _material; }
            set
            {
                if (_material != value)
                {
                    _material = value;
                    OnPropertyChanged("Material");
                }
            }
        }
        private string _material;
    
        [DataMember]
        public bool isNewWeb
        {
            get { return _isNewWeb; }
            set
            {
                if (_isNewWeb != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“isNewWeb”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _isNewWeb = value;
                    OnPropertyChanged("isNewWeb");
                }
            }
        }
        private bool _isNewWeb;
    
        [DataMember]
        public Nullable<int> diamondId
        {
            get { return _diamondId; }
            set
            {
                if (_diamondId != value)
                {
                    _diamondId = value;
                    OnPropertyChanged("diamondId");
                }
            }
        }
        private Nullable<int> _diamondId;
    
        [DataMember]
        public Nullable<int> fdiamondId
        {
            get { return _fdiamondId; }
            set
            {
                if (_fdiamondId != value)
                {
                    _fdiamondId = value;
                    OnPropertyChanged("fdiamondId");
                }
            }
        }
        private Nullable<int> _fdiamondId;
    
        [DataMember]
        public Nullable<int> AfterServiceId
        {
            get { return _afterServiceId; }
            set
            {
                if (_afterServiceId != value)
                {
                    _afterServiceId = value;
                    OnPropertyChanged("AfterServiceId");
                }
            }
        }
        private Nullable<int> _afterServiceId;
    
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
        public Nullable<int> AddressId
        {
            get { return _addressId; }
            set
            {
                if (_addressId != value)
                {
                    _addressId = value;
                    OnPropertyChanged("AddressId");
                }
            }
        }
        private Nullable<int> _addressId;
    
        [DataMember]
        public string AfterServiceNo
        {
            get { return _afterServiceNo; }
            set
            {
                if (_afterServiceNo != value)
                {
                    _afterServiceNo = value;
                    OnPropertyChanged("AfterServiceNo");
                }
            }
        }
        private string _afterServiceNo;
    
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
        public Nullable<int> userid
        {
            get { return _userid; }
            set
            {
                if (_userid != value)
                {
                    _userid = value;
                    OnPropertyChanged("userid");
                }
            }
        }
        private Nullable<int> _userid;
    
        [DataMember]
        public Nullable<System.DateTime> addtime
        {
            get { return _addtime; }
            set
            {
                if (_addtime != value)
                {
                    _addtime = value;
                    OnPropertyChanged("addtime");
                }
            }
        }
        private Nullable<System.DateTime> _addtime;
    
        [DataMember]
        public string imgurl
        {
            get { return _imgurl; }
            set
            {
                if (_imgurl != value)
                {
                    _imgurl = value;
                    OnPropertyChanged("imgurl");
                }
            }
        }
        private string _imgurl;
    
        [DataMember]
        public string productNo
        {
            get { return _productNo; }
            set
            {
                if (_productNo != value)
                {
                    _productNo = value;
                    OnPropertyChanged("productNo");
                }
            }
        }
        private string _productNo;
    
        [DataMember]
        public Nullable<int> status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("status");
                }
            }
        }
        private Nullable<int> _status;

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