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
    public partial class T_Hodliday: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string descation
        {
            get { return _descation; }
            set
            {
                if (_descation != value)
                {
                    _descation = value;
                    OnPropertyChanged("descation");
                }
            }
        }
        private string _descation;
    
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
        public string backimg
        {
            get { return _backimg; }
            set
            {
                if (_backimg != value)
                {
                    _backimg = value;
                    OnPropertyChanged("backimg");
                }
            }
        }
        private string _backimg;
    
        [DataMember]
        public string banner
        {
            get { return _banner; }
            set
            {
                if (_banner != value)
                {
                    _banner = value;
                    OnPropertyChanged("banner");
                }
            }
        }
        private string _banner;
    
        [DataMember]
        public string adpic
        {
            get { return _adpic; }
            set
            {
                if (_adpic != value)
                {
                    _adpic = value;
                    OnPropertyChanged("adpic");
                }
            }
        }
        private string _adpic;
    
        [DataMember]
        public string zt
        {
            get { return _zt; }
            set
            {
                if (_zt != value)
                {
                    _zt = value;
                    OnPropertyChanged("zt");
                }
            }
        }
        private string _zt;
    
        [DataMember]
        public string arttitle
        {
            get { return _arttitle; }
            set
            {
                if (_arttitle != value)
                {
                    _arttitle = value;
                    OnPropertyChanged("arttitle");
                }
            }
        }
        private string _arttitle;
    
        [DataMember]
        public string artdesc
        {
            get { return _artdesc; }
            set
            {
                if (_artdesc != value)
                {
                    _artdesc = value;
                    OnPropertyChanged("artdesc");
                }
            }
        }
        private string _artdesc;
    
        [DataMember]
        public string proId
        {
            get { return _proId; }
            set
            {
                if (_proId != value)
                {
                    _proId = value;
                    OnPropertyChanged("proId");
                }
            }
        }
        private string _proId;
    
        [DataMember]
        public string zx1
        {
            get { return _zx1; }
            set
            {
                if (_zx1 != value)
                {
                    _zx1 = value;
                    OnPropertyChanged("zx1");
                }
            }
        }
        private string _zx1;
    
        [DataMember]
        public string zx2
        {
            get { return _zx2; }
            set
            {
                if (_zx2 != value)
                {
                    _zx2 = value;
                    OnPropertyChanged("zx2");
                }
            }
        }
        private string _zx2;
    
        [DataMember]
        public string zx3
        {
            get { return _zx3; }
            set
            {
                if (_zx3 != value)
                {
                    _zx3 = value;
                    OnPropertyChanged("zx3");
                }
            }
        }
        private string _zx3;
    
        [DataMember]
        public string zx4
        {
            get { return _zx4; }
            set
            {
                if (_zx4 != value)
                {
                    _zx4 = value;
                    OnPropertyChanged("zx4");
                }
            }
        }
        private string _zx4;
    
        [DataMember]
        public string link
        {
            get { return _link; }
            set
            {
                if (_link != value)
                {
                    _link = value;
                    OnPropertyChanged("link");
                }
            }
        }
        private string _link;

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
