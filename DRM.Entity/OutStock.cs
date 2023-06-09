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
    public partial class OutStock: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string OutCode
        {
            get { return _outCode; }
            set
            {
                if (_outCode != value)
                {
                    _outCode = value;
                    OnPropertyChanged("OutCode");
                }
            }
        }
        private string _outCode;
    
        [DataMember]
        public Nullable<int> GoodId
        {
            get { return _goodId; }
            set
            {
                if (_goodId != value)
                {
                    _goodId = value;
                    OnPropertyChanged("GoodId");
                }
            }
        }
        private Nullable<int> _goodId;
    
        [DataMember]
        public Nullable<int> GoodTypeId
        {
            get { return _goodTypeId; }
            set
            {
                if (_goodTypeId != value)
                {
                    _goodTypeId = value;
                    OnPropertyChanged("GoodTypeId");
                }
            }
        }
        private Nullable<int> _goodTypeId;
    
        [DataMember]
        public Nullable<int> StockNum
        {
            get { return _stockNum; }
            set
            {
                if (_stockNum != value)
                {
                    _stockNum = value;
                    OnPropertyChanged("StockNum");
                }
            }
        }
        private Nullable<int> _stockNum;
    
        [DataMember]
        public string StockType
        {
            get { return _stockType; }
            set
            {
                if (_stockType != value)
                {
                    _stockType = value;
                    OnPropertyChanged("StockType");
                }
            }
        }
        private string _stockType;
    
        [DataMember]
        public string create_by
        {
            get { return _create_by; }
            set
            {
                if (_create_by != value)
                {
                    _create_by = value;
                    OnPropertyChanged("create_by");
                }
            }
        }
        private string _create_by;
    
        [DataMember]
        public Nullable<System.DateTime> create_date
        {
            get { return _create_date; }
            set
            {
                if (_create_date != value)
                {
                    _create_date = value;
                    OnPropertyChanged("create_date");
                }
            }
        }
        private Nullable<System.DateTime> _create_date;
    
        [DataMember]
        public string modify_by
        {
            get { return _modify_by; }
            set
            {
                if (_modify_by != value)
                {
                    _modify_by = value;
                    OnPropertyChanged("modify_by");
                }
            }
        }
        private string _modify_by;
    
        [DataMember]
        public Nullable<System.DateTime> modify_date
        {
            get { return _modify_date; }
            set
            {
                if (_modify_date != value)
                {
                    _modify_date = value;
                    OnPropertyChanged("modify_date");
                }
            }
        }
        private Nullable<System.DateTime> _modify_date;

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
