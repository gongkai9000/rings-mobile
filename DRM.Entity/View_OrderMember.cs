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
    public partial class View_OrderMember: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged("gender");
                }
            }
        }
        private string _gender;
    
        [DataMember]
        public Nullable<bool> isbill
        {
            get { return _isbill; }
            set
            {
                if (_isbill != value)
                {
                    _isbill = value;
                    OnPropertyChanged("isbill");
                }
            }
        }
        private Nullable<bool> _isbill;
    
        [DataMember]
        public string address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged("address");
                }
            }
        }
        private string _address;
    
        [DataMember]
        public string GName
        {
            get { return _gName; }
            set
            {
                if (_gName != value)
                {
                    _gName = value;
                    OnPropertyChanged("GName");
                }
            }
        }
        private string _gName;
    
        [DataMember]
        public string GCard
        {
            get { return _gCard; }
            set
            {
                if (_gCard != value)
                {
                    _gCard = value;
                    OnPropertyChanged("GCard");
                }
            }
        }
        private string _gCard;
    
        [DataMember]
        public string GMobile
        {
            get { return _gMobile; }
            set
            {
                if (_gMobile != value)
                {
                    _gMobile = value;
                    OnPropertyChanged("GMobile");
                }
            }
        }
        private string _gMobile;
    
        [DataMember]
        public string GirlfriendName
        {
            get { return _girlfriendName; }
            set
            {
                if (_girlfriendName != value)
                {
                    _girlfriendName = value;
                    OnPropertyChanged("GirlfriendName");
                }
            }
        }
        private string _girlfriendName;
    
        [DataMember]
        public string postcode
        {
            get { return _postcode; }
            set
            {
                if (_postcode != value)
                {
                    _postcode = value;
                    OnPropertyChanged("postcode");
                }
            }
        }
        private string _postcode;
    
        [DataMember]
        public string mobile
        {
            get { return _mobile; }
            set
            {
                if (_mobile != value)
                {
                    _mobile = value;
                    OnPropertyChanged("mobile");
                }
            }
        }
        private string _mobile;
    
        [DataMember]
        public string telephone
        {
            get { return _telephone; }
            set
            {
                if (_telephone != value)
                {
                    _telephone = value;
                    OnPropertyChanged("telephone");
                }
            }
        }
        private string _telephone;
    
        [DataMember]
        public Nullable<decimal> ordertotal
        {
            get { return _ordertotal; }
            set
            {
                if (_ordertotal != value)
                {
                    _ordertotal = value;
                    OnPropertyChanged("ordertotal");
                }
            }
        }
        private Nullable<decimal> _ordertotal;
    
        [DataMember]
        public string XmlFilePath
        {
            get { return _xmlFilePath; }
            set
            {
                if (_xmlFilePath != value)
                {
                    _xmlFilePath = value;
                    OnPropertyChanged("XmlFilePath");
                }
            }
        }
        private string _xmlFilePath;
    
        [DataMember]
        public string orderid
        {
            get { return _orderid; }
            set
            {
                if (_orderid != value)
                {
                    _orderid = value;
                    OnPropertyChanged("orderid");
                }
            }
        }
        private string _orderid;
    
        [DataMember]
        public int status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“status”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _status = value;
                    OnPropertyChanged("status");
                }
            }
        }
        private int _status;
    
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
        public string ordernote
        {
            get { return _ordernote; }
            set
            {
                if (_ordernote != value)
                {
                    _ordernote = value;
                    OnPropertyChanged("ordernote");
                }
            }
        }
        private string _ordernote;
    
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
        public string postip
        {
            get { return _postip; }
            set
            {
                if (_postip != value)
                {
                    _postip = value;
                    OnPropertyChanged("postip");
                }
            }
        }
        private string _postip;
    
        [DataMember]
        public string qq
        {
            get { return _qq; }
            set
            {
                if (_qq != value)
                {
                    _qq = value;
                    OnPropertyChanged("qq");
                }
            }
        }
        private string _qq;
    
        [DataMember]
        public string sitenote
        {
            get { return _sitenote; }
            set
            {
                if (_sitenote != value)
                {
                    _sitenote = value;
                    OnPropertyChanged("sitenote");
                }
            }
        }
        private string _sitenote;
    
        [DataMember]
        public string kdgs
        {
            get { return _kdgs; }
            set
            {
                if (_kdgs != value)
                {
                    _kdgs = value;
                    OnPropertyChanged("kdgs");
                }
            }
        }
        private string _kdgs;
    
        [DataMember]
        public string kdid
        {
            get { return _kdid; }
            set
            {
                if (_kdid != value)
                {
                    _kdid = value;
                    OnPropertyChanged("kdid");
                }
            }
        }
        private string _kdid;
    
        [DataMember]
        public string kdtype
        {
            get { return _kdtype; }
            set
            {
                if (_kdtype != value)
                {
                    _kdtype = value;
                    OnPropertyChanged("kdtype");
                }
            }
        }
        private string _kdtype;
    
        [DataMember]
        public string paytype
        {
            get { return _paytype; }
            set
            {
                if (_paytype != value)
                {
                    _paytype = value;
                    OnPropertyChanged("paytype");
                }
            }
        }
        private string _paytype;
    
        [DataMember]
        public string payid
        {
            get { return _payid; }
            set
            {
                if (_payid != value)
                {
                    _payid = value;
                    OnPropertyChanged("payid");
                }
            }
        }
        private string _payid;
    
        [DataMember]
        public string SMSphone
        {
            get { return _sMSphone; }
            set
            {
                if (_sMSphone != value)
                {
                    _sMSphone = value;
                    OnPropertyChanged("SMSphone");
                }
            }
        }
        private string _sMSphone;
    
        [DataMember]
        public string deliverytime
        {
            get { return _deliverytime; }
            set
            {
                if (_deliverytime != value)
                {
                    _deliverytime = value;
                    OnPropertyChanged("deliverytime");
                }
            }
        }
        private string _deliverytime;
    
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
        public Nullable<System.DateTime> latetime
        {
            get { return _latetime; }
            set
            {
                if (_latetime != value)
                {
                    _latetime = value;
                    OnPropertyChanged("latetime");
                }
            }
        }
        private Nullable<System.DateTime> _latetime;
    
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
