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
    public partial class T_EmailResult: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string SendType
        {
            get { return _sendType; }
            set
            {
                if (_sendType != value)
                {
                    _sendType = value;
                    OnPropertyChanged("SendType");
                }
            }
        }
        private string _sendType;
    
        [DataMember]
        public string OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    _orderId = value;
                    OnPropertyChanged("OrderId");
                }
            }
        }
        private string _orderId;
    
        [DataMember]
        public string OrderAccept
        {
            get { return _orderAccept; }
            set
            {
                if (_orderAccept != value)
                {
                    _orderAccept = value;
                    OnPropertyChanged("OrderAccept");
                }
            }
        }
        private string _orderAccept;
    
        [DataMember]
        public string OrderCus
        {
            get { return _orderCus; }
            set
            {
                if (_orderCus != value)
                {
                    _orderCus = value;
                    OnPropertyChanged("OrderCus");
                }
            }
        }
        private string _orderCus;
    
        [DataMember]
        public string knowDr
        {
            get { return _knowDr; }
            set
            {
                if (_knowDr != value)
                {
                    _knowDr = value;
                    OnPropertyChanged("knowDr");
                }
            }
        }
        private string _knowDr;
    
        [DataMember]
        public string satisfiedCus
        {
            get { return _satisfiedCus; }
            set
            {
                if (_satisfiedCus != value)
                {
                    _satisfiedCus = value;
                    OnPropertyChanged("satisfiedCus");
                }
            }
        }
        private string _satisfiedCus;
    
        [DataMember]
        public string satisfiedWeb
        {
            get { return _satisfiedWeb; }
            set
            {
                if (_satisfiedWeb != value)
                {
                    _satisfiedWeb = value;
                    OnPropertyChanged("satisfiedWeb");
                }
            }
        }
        private string _satisfiedWeb;
    
        [DataMember]
        public string satisfiedPro
        {
            get { return _satisfiedPro; }
            set
            {
                if (_satisfiedPro != value)
                {
                    _satisfiedPro = value;
                    OnPropertyChanged("satisfiedPro");
                }
            }
        }
        private string _satisfiedPro;
    
        [DataMember]
        public string satisfiedTra
        {
            get { return _satisfiedTra; }
            set
            {
                if (_satisfiedTra != value)
                {
                    _satisfiedTra = value;
                    OnPropertyChanged("satisfiedTra");
                }
            }
        }
        private string _satisfiedTra;
    
        [DataMember]
        public string OtherSug
        {
            get { return _otherSug; }
            set
            {
                if (_otherSug != value)
                {
                    _otherSug = value;
                    OnPropertyChanged("OtherSug");
                }
            }
        }
        private string _otherSug;
    
        [DataMember]
        public Nullable<System.DateTime> AddTime
        {
            get { return _addTime; }
            set
            {
                if (_addTime != value)
                {
                    _addTime = value;
                    OnPropertyChanged("AddTime");
                }
            }
        }
        private Nullable<System.DateTime> _addTime;

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
