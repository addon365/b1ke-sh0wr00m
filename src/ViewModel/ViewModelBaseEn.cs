using Api.Database.Entity;
using Swc.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public abstract class ViewModelBaseEn<T> : ViewModelBase
        where T : BaseEntity
    {
        public IBaseService<T> Service { get; set; }

        protected ViewModelBaseEn(IBaseService<T> baseService)
        {
            this.Service = baseService;
        }

        private void WireCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }
        public T Model { get; set; }

        public abstract void Find();

        public abstract void FindAll();

        public abstract void Save();

    }
}
