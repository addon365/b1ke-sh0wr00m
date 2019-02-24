using addon365.Database.Entity;
using addon365.Database.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace addon365.UI.ViewModel
{
    public abstract class ViewModelBaseEn<T> : ViewModelBase
        where T : BaseEntityWithLogFields
    {
        public IBaseService<T> Service { get; set; }
        private T _model;
        public Result OnResult
        {
            get;
            set;
        }
        protected ViewModelBaseEn(IBaseService<T> baseService,
            Result onResult = null)
        {
            this.Service = baseService;
            this.OnResult = onResult;
            
            WireCommands();
            InitModel();
        }
        public virtual void InitModel()
        {

        }
        public virtual void WireCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }
        public T Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged("Model");
                    SaveCommand.IsEnabled = true;
                }
            }
        }
        public virtual void Find()
        {
            throw new NotImplementedException();
        }

        public virtual void FindAll()
        {
            throw new NotImplementedException();
        }
       
        public virtual void Save()
        {
            if (!Validate()) return;
            IsProgressBarVisible = true;
            try
            {
                Model=Service.Save(Model);
                
                SayMessage(true, "Successfully Saved..");
            }
            catch(Exception exception)
            {
                SayMessage(false, exception.Message);
            }
            IsProgressBarVisible = false;
        }
        public virtual void SayMessage(bool isSuccess,string message)
        {
            if(isSuccess) InitModel();
            if (OnResult != null)
            {
                OnResult(isSuccess, message);
            }
            Message = message;
        }

        public virtual bool Validate()
        {
            return true;
        }
    }
}
