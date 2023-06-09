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
    [KnownType(typeof(Product))]
    public partial class T_Diamonds: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public Nullable<decimal> price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("price");
                }
            }
        }
        private Nullable<decimal> _price;
    
        [DataMember]
        public Nullable<decimal> memberprice
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
        private Nullable<decimal> _memberprice;
    
        [DataMember]
        public string shape
        {
            get { return _shape; }
            set
            {
                if (_shape != value)
                {
                    _shape = value;
                    OnPropertyChanged("shape");
                }
            }
        }
        private string _shape;
    
        [DataMember]
        public string code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged("code");
                }
            }
        }
        private string _code;
    
        [DataMember]
        public string d_type
        {
            get { return _d_type; }
            set
            {
                if (_d_type != value)
                {
                    _d_type = value;
                    OnPropertyChanged("d_type");
                }
            }
        }
        private string _d_type;
    
        [DataMember]
        public string d_code
        {
            get { return _d_code; }
            set
            {
                if (_d_code != value)
                {
                    _d_code = value;
                    OnPropertyChanged("d_code");
                }
            }
        }
        private string _d_code;
    
        [DataMember]
        public Nullable<double> carat
        {
            get { return _carat; }
            set
            {
                if (_carat != value)
                {
                    _carat = value;
                    OnPropertyChanged("carat");
                }
            }
        }
        private Nullable<double> _carat;
    
        [DataMember]
        public string clarity
        {
            get { return _clarity; }
            set
            {
                if (_clarity != value)
                {
                    _clarity = value;
                    OnPropertyChanged("clarity");
                }
            }
        }
        private string _clarity;
    
        [DataMember]
        public string color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged("color");
                }
            }
        }
        private string _color;
    
        [DataMember]
        public string polish
        {
            get { return _polish; }
            set
            {
                if (_polish != value)
                {
                    _polish = value;
                    OnPropertyChanged("polish");
                }
            }
        }
        private string _polish;
    
        [DataMember]
        public string symmetry
        {
            get { return _symmetry; }
            set
            {
                if (_symmetry != value)
                {
                    _symmetry = value;
                    OnPropertyChanged("symmetry");
                }
            }
        }
        private string _symmetry;
    
        [DataMember]
        public string cut
        {
            get { return _cut; }
            set
            {
                if (_cut != value)
                {
                    _cut = value;
                    OnPropertyChanged("cut");
                }
            }
        }
        private string _cut;
    
        [DataMember]
        public string measurements
        {
            get { return _measurements; }
            set
            {
                if (_measurements != value)
                {
                    _measurements = value;
                    OnPropertyChanged("measurements");
                }
            }
        }
        private string _measurements;
    
        [DataMember]
        public string d_table
        {
            get { return _d_table; }
            set
            {
                if (_d_table != value)
                {
                    _d_table = value;
                    OnPropertyChanged("d_table");
                }
            }
        }
        private string _d_table;
    
        [DataMember]
        public string depth
        {
            get { return _depth; }
            set
            {
                if (_depth != value)
                {
                    _depth = value;
                    OnPropertyChanged("depth");
                }
            }
        }
        private string _depth;
    
        [DataMember]
        public string girdle
        {
            get { return _girdle; }
            set
            {
                if (_girdle != value)
                {
                    _girdle = value;
                    OnPropertyChanged("girdle");
                }
            }
        }
        private string _girdle;
    
        [DataMember]
        public string culet
        {
            get { return _culet; }
            set
            {
                if (_culet != value)
                {
                    _culet = value;
                    OnPropertyChanged("culet");
                }
            }
        }
        private string _culet;
    
        [DataMember]
        public string fluorescence
        {
            get { return _fluorescence; }
            set
            {
                if (_fluorescence != value)
                {
                    _fluorescence = value;
                    OnPropertyChanged("fluorescence");
                }
            }
        }
        private string _fluorescence;
    
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
        public Nullable<int> protype
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
        private Nullable<int> _protype;
    
        [DataMember]
        public string batch
        {
            get { return _batch; }
            set
            {
                if (_batch != value)
                {
                    _batch = value;
                    OnPropertyChanged("batch");
                }
            }
        }
        private string _batch;
    
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
        public Nullable<int> stocknumber
        {
            get { return _stocknumber; }
            set
            {
                if (_stocknumber != value)
                {
                    _stocknumber = value;
                    OnPropertyChanged("stocknumber");
                }
            }
        }
        private Nullable<int> _stocknumber;

        #endregion

        #region 导航属性
    
        [DataMember]
        public TrackableCollection<Product> Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new TrackableCollection<Product>();
                    _product.CollectionChanged += FixupProduct;
                }
                return _product;
            }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("当启用 ChangeTracking 时，无法设置 FixupChangeTrackingCollection");
                    }
                    if (_product != null)
                    {
                        _product.CollectionChanged -= FixupProduct;
                    }
                    _product = value;
                    if (_product != null)
                    {
                        _product.CollectionChanged += FixupProduct;
                    }
                    OnNavigationPropertyChanged("Product");
                }
            }
        }
        private TrackableCollection<Product> _product;

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
            Product.Clear();
        }

        #endregion

        #region 关联修复
    
        private void FixupProduct(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Product item in e.NewItems)
                {
                    item.T_Diamonds = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Product", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Product item in e.OldItems)
                {
                    if (ReferenceEquals(item.T_Diamonds, this))
                    {
                        item.T_Diamonds = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Product", item);
                    }
                }
            }
        }

        #endregion

    }
}
