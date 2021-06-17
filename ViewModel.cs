using SimpleResturantSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleResturantSystem
{
    public class ViewModel : INotifyPropertyChanged
    {
        private IList<Dish> dishes;
        private int total;
        
        public IList<Dish> Dishes { 
            get => dishes;
            set { dishes = value; 
                OnPropertyChanged();
            } 
        }
        public int Total { 
            get => total;
            set { total = value;
                OnPropertyChanged();
            }
        }

        public void Reset()
        {
            Total = 0;
            foreach (var item in dishes)
            {
                item.Count = 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
