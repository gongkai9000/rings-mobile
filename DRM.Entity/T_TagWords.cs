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
    public partial class T_TagWords: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string Tagname
        {
            get { return _tagname; }
            set
            {
                if (_tagname != value)
                {
                    _tagname = value;
                    OnPropertyChanged("Tagname");
                }
            }
        }
        private string _tagname;
    
        [DataMember]
        public string Tagurl
        {
            get { return _tagurl; }
            set
            {
                if (_tagurl != value)
                {
                    _tagurl = value;
                    OnPropertyChanged("Tagurl");
                }
            }
        }
        private string _tagurl;
    
        [DataMember]
        public Nullable<System.DateTime> Addtime
        {
            get { return _addtime; }
            set
            {
                if (_addtime != value)
                {
                    _addtime = value;
                    OnPropertyChanged("Addtime");
                }
            }
        }
        private Nullable<System.DateTime> _addtime;
    
        [DataMember]
        public Nullable<int> Artcleid
        {
            get { return _artcleid; }
            set
            {
                if (_artcleid != value)
                {
                    _artcleid = value;
                    OnPropertyChanged("Artcleid");
                }
            }
        }
        private Nullable<int> _artcleid;
    
        [DataMember]
        public string Flink
        {
            get { return _flink; }
            set
            {
                if (_flink != value)
                {
                    _flink = value;
                    OnPropertyChanged("Flink");
                }
            }
        }
        private string _flink;
    
        [DataMember]
        public string SEOTitle
        {
            get { return _sEOTitle; }
            set
            {
                if (_sEOTitle != value)
                {
                    _sEOTitle = value;
                    OnPropertyChanged("SEOTitle");
                }
            }
        }
        private string _sEOTitle;
    
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
        public string des
        {
            get { return _des; }
            set
            {
                if (_des != value)
                {
                    _des = value;
                    OnPropertyChanged("des");
                }
            }
        }
        private string _des;

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
