using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace addon365.UI.ViewModel
{
    public class PagingViewModel<T> : ViewModelBase
    {
        private ObservableCollection<T> _data;
        private Func<addon365.Domain.Entity.Paging.PagingParams, Threenine.Data.Paging.IPaginate<T>>  _RequestMethod;

        private int start = 0;
        private int itemCount = 30;
        private int totalItems = 0;
        private int totalPages = 0;
        private readonly List<int> count;

        private ICommand _firstCommand;
        private ICommand _previousCommand;
        private ICommand _nextCommand;
        private ICommand _lastCommand;
        private ICommand _countchangedCommand;

        public ObservableCollection<T> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged("Data");
                }
            }
        }

        public PagingViewModel(Func<addon365.Domain.Entity.Paging.PagingParams, Threenine.Data.Paging.IPaginate<T>> RequestMethod)
        {
            count = new List<int> { 30,40,50,60 };
            this._RequestMethod = RequestMethod;
            RefreshData();
        }

        public int Start { get { return start + 1; } }

        public int End { get { return start + itemCount < totalItems ? start + itemCount : totalItems; } }

        public int TotalItems { get { return totalItems; } }
        public int TotalPages { get { return totalPages; } set { totalPages = value; } }

        public List<int> Count { get { return count; } }

        public int ItemCount { get { return itemCount; } set { itemCount = value; OnPropertyChanged("ItemCount"); } }

        public ICommand FirstCommand
        {
            get
            {
                if (_firstCommand == null)
                {
                    _firstCommand = new OtherRelayCommand
                    (
                        param =>
                        {
                            start = 0;
                            RefreshData();
                        },
                        param =>
                        {
                            return  TotalPages >= 0 ? true : false;
                        }
                    );
                }

                return _firstCommand;
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                if (_previousCommand == null)
                {
                    _previousCommand = new OtherRelayCommand
                    (
                        param =>
                        {
                            if(start>0)
                            { 
                                start -= 1;
                                RefreshData();
                            }
                        },
                        param =>
                        {
                            return start  >=0 ? true : false;
                        }
                    );
                }

                return _previousCommand;
            }
        }

        public ICommand NextCommand
        {
            get
            {
                if (_nextCommand == null)
                {
                    _nextCommand = new OtherRelayCommand
                    (
                        param =>
                        {
                            if(Start<TotalPages)
                            { 
                                start += 1;
                                RefreshData();
                            }
                        },
                        param =>
                        {
                            return start< TotalPages ? true : false;
                        }
                    );
                }

                return _nextCommand;
            }
        }

        public ICommand LastCommand
        {
            get
            {
                if (_lastCommand == null)
                {
                    _lastCommand = new OtherRelayCommand
                    (
                        param =>
                        {
                            if(TotalPages>0)
                            start =TotalPages-1;
                            RefreshData();
                        },
                        param =>
                        {
                            return start<TotalPages ? true : false;
                        }
                    );
                }

                return _lastCommand;
            }
        }

        public ICommand CountChangedCommand
        {
            get
            {
                if (_countchangedCommand == null)
                {
                    _countchangedCommand = new OtherRelayCommand
                    (
                        param =>
                        {
                            start = 0;
                            RefreshData();
                        },
                        param =>
                        {
                            return ItemCount>0 ? true : false;
                        }
                    );
                }

                return _countchangedCommand;
            }
        }

        addon365.Domain.Entity.Paging.PagingParams param = new addon365.Domain.Entity.Paging.PagingParams();
        public void RefreshData()
        {
            if (param.PageNumber == start && param.PageSize == itemCount)
                return;

            param.PageNumber = start;
            param.PageSize = itemCount;
            Threenine.Data.Paging.IPaginate<T> paginate = _RequestMethod(param);
            TotalPages = paginate.Pages;
            Data =new ObservableCollection<T>(paginate.Items);
            //_data = GetData(start, itemCount, out totalItems);
            //DataViewModel vm = new DataViewModel(this);

            OnPropertyChanged("Start");
            OnPropertyChanged("TotalPages");
            OnPropertyChanged("TotalItems");
        }
    }

}
