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
    public partial class T_thekey: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string pic
        {
            get { return _pic; }
            set
            {
                if (_pic != value)
                {
                    _pic = value;
                    OnPropertyChanged("pic");
                }
            }
        }
        private string _pic;
    
        [DataMember]
        public string lbpic1
        {
            get { return _lbpic1; }
            set
            {
                if (_lbpic1 != value)
                {
                    _lbpic1 = value;
                    OnPropertyChanged("lbpic1");
                }
            }
        }
        private string _lbpic1;
    
        [DataMember]
        public string lbpic2
        {
            get { return _lbpic2; }
            set
            {
                if (_lbpic2 != value)
                {
                    _lbpic2 = value;
                    OnPropertyChanged("lbpic2");
                }
            }
        }
        private string _lbpic2;
    
        [DataMember]
        public string lbpic3
        {
            get { return _lbpic3; }
            set
            {
                if (_lbpic3 != value)
                {
                    _lbpic3 = value;
                    OnPropertyChanged("lbpic3");
                }
            }
        }
        private string _lbpic3;
    
        [DataMember]
        public string smpic
        {
            get { return _smpic; }
            set
            {
                if (_smpic != value)
                {
                    _smpic = value;
                    OnPropertyChanged("smpic");
                }
            }
        }
        private string _smpic;
    
        [DataMember]
        public string keyword
        {
            get { return _keyword; }
            set
            {
                if (_keyword != value)
                {
                    _keyword = value;
                    OnPropertyChanged("keyword");
                }
            }
        }
        private string _keyword;
    
        [DataMember]
        public string desctitle
        {
            get { return _desctitle; }
            set
            {
                if (_desctitle != value)
                {
                    _desctitle = value;
                    OnPropertyChanged("desctitle");
                }
            }
        }
        private string _desctitle;
    
        [DataMember]
        public string title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged("title");
                }
            }
        }
        private string _title;
    
        [DataMember]
        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public string tpro
        {
            get { return _tpro; }
            set
            {
                if (_tpro != value)
                {
                    _tpro = value;
                    OnPropertyChanged("tpro");
                }
            }
        }
        private string _tpro;
    
        [DataMember]
        public string hpro
        {
            get { return _hpro; }
            set
            {
                if (_hpro != value)
                {
                    _hpro = value;
                    OnPropertyChanged("hpro");
                }
            }
        }
        private string _hpro;
    
        [DataMember]
        public string url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    OnPropertyChanged("url");
                }
            }
        }
        private string _url;
    
        [DataMember]
        public string artId
        {
            get { return _artId; }
            set
            {
                if (_artId != value)
                {
                    _artId = value;
                    OnPropertyChanged("artId");
                }
            }
        }
        private string _artId;
    
        [DataMember]
        public string ztId
        {
            get { return _ztId; }
            set
            {
                if (_ztId != value)
                {
                    _ztId = value;
                    OnPropertyChanged("ztId");
                }
            }
        }
        private string _ztId;

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
