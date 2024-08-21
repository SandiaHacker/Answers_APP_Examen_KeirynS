using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Answers_APP_Examen_KeirynS.ViewModel
{
    public class BaseViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //variable de control de uso

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return IsBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action? onChange = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;

            backingStore = value;
            onChange?.Invoke();
            OnPropertuChanged(propertyName);
            return true;
        }

        protected void OnPropertuChanged([CallerMemberName] string properrtyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null) return;

            changed.Invoke(this, new PropertyChangedEventArgs(properrtyName));
        }
    }
}

