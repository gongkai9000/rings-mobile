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
    public partial class view_ringcare: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string productNo
        {
            get { return _productNo; }
            set
            {
                if (_productNo != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“productNo”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _productNo = value;
                    OnPropertyChanged("productNo");
                }
            }
        }
        private string _productNo;
    
        [DataMember]
        public int productTypeId
        {
            get { return _productTypeId; }
            set
            {
                if (_productTypeId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“productTypeId”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _productTypeId = value;
                    OnPropertyChanged("productTypeId");
                }
            }
        }
        private int _productTypeId;
    
        [DataMember]
        public string title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“title”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _title = value;
                    OnPropertyChanged("title");
                }
            }
        }
        private string _title;
    
        [DataMember]
        public string p_content
        {
            get { return _p_content; }
            set
            {
                if (_p_content != value)
                {
                    _p_content = value;
                    OnPropertyChanged("p_content");
                }
            }
        }
        private string _p_content;
    
        [DataMember]
        public System.DateTime addtime
        {
            get { return _addtime; }
            set
            {
                if (_addtime != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“addtime”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _addtime = value;
                    OnPropertyChanged("addtime");
                }
            }
        }
        private System.DateTime _addtime;
    
        [DataMember]
        public Nullable<decimal> MemberPrice
        {
            get { return _memberPrice; }
            set
            {
                if (_memberPrice != value)
                {
                    _memberPrice = value;
                    OnPropertyChanged("MemberPrice");
                }
            }
        }
        private Nullable<decimal> _memberPrice;
    
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
    
        [DataMember]
        public Nullable<int> pSort
        {
            get { return _pSort; }
            set
            {
                if (_pSort != value)
                {
                    _pSort = value;
                    OnPropertyChanged("pSort");
                }
            }
        }
        private Nullable<int> _pSort;
    
        [DataMember]
        public Nullable<int> salecount
        {
            get { return _salecount; }
            set
            {
                if (_salecount != value)
                {
                    _salecount = value;
                    OnPropertyChanged("salecount");
                }
            }
        }
        private Nullable<int> _salecount;
    
        [DataMember]
        public Nullable<int> oldId
        {
            get { return _oldId; }
            set
            {
                if (_oldId != value)
                {
                    _oldId = value;
                    OnPropertyChanged("oldId");
                }
            }
        }
        private Nullable<int> _oldId;
    
        [DataMember]
        public string CollectionId
        {
            get { return _collectionId; }
            set
            {
                if (_collectionId != value)
                {
                    _collectionId = value;
                    OnPropertyChanged("CollectionId");
                }
            }
        }
        private string _collectionId;
    
        [DataMember]
        public Nullable<int> DiamondId
        {
            get { return _diamondId; }
            set
            {
                if (_diamondId != value)
                {
                    _diamondId = value;
                    OnPropertyChanged("DiamondId");
                }
            }
        }
        private Nullable<int> _diamondId;
    
        [DataMember]
        public Nullable<int> fDiamondId
        {
            get { return _fDiamondId; }
            set
            {
                if (_fDiamondId != value)
                {
                    _fDiamondId = value;
                    OnPropertyChanged("fDiamondId");
                }
            }
        }
        private Nullable<int> _fDiamondId;
    
        [DataMember]
        public Nullable<int> TJLZ
        {
            get { return _tJLZ; }
            set
            {
                if (_tJLZ != value)
                {
                    _tJLZ = value;
                    OnPropertyChanged("TJLZ");
                }
            }
        }
        private Nullable<int> _tJLZ;
    
        [DataMember]
        public Nullable<bool> IsCustomDiamond
        {
            get { return _isCustomDiamond; }
            set
            {
                if (_isCustomDiamond != value)
                {
                    _isCustomDiamond = value;
                    OnPropertyChanged("IsCustomDiamond");
                }
            }
        }
        private Nullable<bool> _isCustomDiamond;
    
        [DataMember]
        public Nullable<int> IsCustomPink
        {
            get { return _isCustomPink; }
            set
            {
                if (_isCustomPink != value)
                {
                    _isCustomPink = value;
                    OnPropertyChanged("IsCustomPink");
                }
            }
        }
        private Nullable<int> _isCustomPink;
    
        [DataMember]
        public string isChoose
        {
            get { return _isChoose; }
            set
            {
                if (_isChoose != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“isChoose”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _isChoose = value;
                    OnPropertyChanged("isChoose");
                }
            }
        }
        private string _isChoose;
    
        [DataMember]
        public string productType
        {
            get { return _productType; }
            set
            {
                if (_productType != value)
                {
                    _productType = value;
                    OnPropertyChanged("productType");
                }
            }
        }
        private string _productType;

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
